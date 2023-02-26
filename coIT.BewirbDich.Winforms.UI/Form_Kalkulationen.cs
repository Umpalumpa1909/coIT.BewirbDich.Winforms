using ApiClient;

namespace coIT.BewirbDich.Winforms.UI;

public partial class Form_Kalkulationen : Form
{
    private BindingSource _kalkulationen;

    private List<VersicherungsVorgangResponse> abgeschlosseneVersicherungsvorgaenge
        = new List<VersicherungsVorgangResponse>();

    private VersicherungsVorgangClient client;

    public Form_Kalkulationen()
    {
        client = new VersicherungsVorgangClient("https://localhost:7089", new HttpClient());
        InitializeComponent();
    }

    private VersicherungsVorgangResponse? AuswahlEinlesen()
    {
        var rowsCount = ctrl_ListeKalkulationen.SelectedRows.Count;
        if (rowsCount == 0 || rowsCount > 1) return null;
        var zeile = ctrl_ListeKalkulationen.SelectedRows[0];
        if (zeile?.DataBoundItem == null) return null;
        var kalkulation = (VersicherungsVorgangResponse)zeile.DataBoundItem;
        return kalkulation;
    }

    private async Task CreateNewCalculation(Form_NeueKalkulation neueKalkulationForm)
    {
        try
        {
            var neueKalkulation = neueKalkulationForm.createVersicherungsVorgangCommand;
            var result = await client.CreateVersicherungsVorgangAsync(neueKalkulation);
            var kalkulation = await client.GetVersicherungsvorgangAsync(result);

            _kalkulationen.List.Add(kalkulation);
            _kalkulationen.ResetBindings(true);
        }
        catch (Exception error)
        {
            MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void ctr_NeueKalkulation_Click(object sender, EventArgs e)
    {
        var neueKalkulationForm = new Form_NeueKalkulation();
        var dialog = neueKalkulationForm.ShowDialog();
        if (dialog == DialogResult.OK)
        {
            await CreateNewCalculation(neueKalkulationForm);
        }
    }

    private async void ctrl_Aktualisieren_Click(object sender, EventArgs e)
    {
        await LadeVersicherungsVorgaenge();
    }

    private async void ctrl_AngebotAnnehmen_Click(object sender, EventArgs e)
    {
        var kalkulation = AuswahlEinlesen();
        if (kalkulation == null)
            return;
        await client.AngebotAkzeptierenAsync(kalkulation.Id);
        var calc = await client.GetVersicherungsvorgangAsync(kalkulation.Id);
        kalkulation.VorgangsStatus = calc.VorgangsStatus;

        _kalkulationen.ResetBindings(false);
        OptionenAnzeigen(kalkulation);
        await Task.Run(async () =>
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(20000);
                calc = await client.GetVersicherungsvorgangAsync(kalkulation.Id);
                if (calc.VorgangsStatus != kalkulation.VorgangsStatus)
                {
                    kalkulation.VorgangsStatus = calc.VorgangsStatus;
                    this.BeginInvoke(() =>
                    {
                        _kalkulationen.ResetBindings(false);
                        OptionenAnzeigen(kalkulation);
                    });
                    return;
                }
            }
        });
    }

    private async void ctrl_AngebotLoeschen_Click(object sender, EventArgs e)
    {
        var kalkulation = AuswahlEinlesen();
        if (kalkulation == null)
            return;
        try
        {
            await client.VersicherungsVorgangLoeschenAsync(kalkulation.Id);
            _kalkulationen.Remove(kalkulation);
            OptionenAnzeigen(kalkulation);
        }
        catch (Exception error)
        {
            MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw;
        }
    }

    private void ctrl_ListeKalkulationen_SelectionChanged(object sender, EventArgs e)
    {
        var kalkulation = AuswahlEinlesen();

        if (kalkulation == null)
            return;

        OptionenAnzeigen(kalkulation);
    }

    private async void ctrl_VersicherungsscheinAusstellen_Click(object sender, EventArgs e)
    {
        var kalkulation = AuswahlEinlesen();
        if (kalkulation == null)
            return;
        await client.VersicherungsscheinAustellenAsync(kalkulation.Id);
        _kalkulationen.Remove(kalkulation);
        _kalkulationen.ResetBindings(true);
        OptionenAnzeigen(kalkulation);

        MessageBox.Show("Der Versicherungsschein wurde an den Versicherungsnehmer verschickt.",
            "Vorgang", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private async void ctrl_Versicherungsscheine_Click(object sender, EventArgs e)
    {
        int abrufAbNr = 0;
        if (abgeschlosseneVersicherungsvorgaenge.Any())
        {
            abrufAbNr = abgeschlosseneVersicherungsvorgaenge.Max(x => x.Versicherungsnummer!.Value);
        }
        var result = await client.GetBeendeteVersicherungsVorgaengeAsync(
            new GetBeendeteVersicherungsVorgaengeQuery()
            { AbVersicherungsnummer = abrufAbNr });
        abgeschlosseneVersicherungsvorgaenge.AddRange(result.Versicherungsvorgaenge.ToList());

        Form_Versicherungsscheine form_Versicherungsscheine = new Form_Versicherungsscheine(abgeschlosseneVersicherungsvorgaenge);
        form_Versicherungsscheine.Show();
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        await LadeVersicherungsVorgaenge();
    }

    private async Task LadeVersicherungsVorgaenge()
    {
        var result = await client.GetOffeneVersicherungsVorgaengeAsync();

        _kalkulationen = new BindingSource
        {
            DataSource = result.Versicherungsvorgaenge
        };

        ctrl_ListeKalkulationen.DataSource = _kalkulationen;
        ctrl_ListeKalkulationen.ColumnHeadersVisible = true;
        ctrl_ListeKalkulationen.AutoGenerateColumns = true;
        ctrl_ListeKalkulationen.Columns[nameof(VersicherungsVorgangResponse.Id)].Visible = false;
        ctrl_ListeKalkulationen.Columns[nameof(VersicherungsVorgangResponse.VersicherungsScheinErstellungsdatum)].Visible = false;
        ctrl_ListeKalkulationen.Columns[nameof(VersicherungsVorgangResponse.Versicherungsnummer)].Visible = false;
        ctrl_ListeKalkulationen.Columns[nameof(VersicherungsVorgangResponse.GesamtBeitrag)].DefaultCellStyle.Format = "c";
        ctrl_ListeKalkulationen.Columns[nameof(VersicherungsVorgangResponse.GrundBeitrag)].DefaultCellStyle.Format = "c";
        ctrl_ListeKalkulationen.Columns[nameof(VersicherungsVorgangResponse.RisikoAufschlag)].DefaultCellStyle.Format = "c";
        ctrl_ListeKalkulationen.Columns[nameof(VersicherungsVorgangResponse.WebShopAufschlag)].DefaultCellStyle.Format = "c";
        ctrl_ListeKalkulationen.Columns[nameof(VersicherungsVorgangResponse.ZusatzschutzAufschlag)].DefaultCellStyle.Format = "c";
        ctrl_ListeKalkulationen.AutoResizeColumns();
        ctrl_ListeKalkulationen.AutoSize = true;

        _kalkulationen.ResetBindings(false);
    }

    private void OptionenAnzeigen(VersicherungsVorgangResponse versicherungsvorgang)
    {
        ctrl_VersicherungsscheinAusstellen.Enabled = false;
        ctrl_AngebotAnnehmen.Enabled = false;
        ctrl_AngebotLoeschen.Enabled = false;

        switch (versicherungsvorgang.VorgangsStatus)
        {
            case VorgangsStatus.Angebot:
                ctrl_AngebotAnnehmen.Enabled = true;
                ctrl_AngebotLoeschen.Enabled = true;
                break;

            case VorgangsStatus.Bestellung:
            case VorgangsStatus.Versicherungsschein:
                break;

            case VorgangsStatus.Abgelehnt:
                ctrl_AngebotLoeschen.Enabled = true;
                break;

            case VorgangsStatus.Auftragsbestaetigung:
                ctrl_VersicherungsscheinAusstellen.Enabled = true;
                break;

            default: throw new InvalidDataException("Unbekannter Dokumenttyp");
        }
    }
}