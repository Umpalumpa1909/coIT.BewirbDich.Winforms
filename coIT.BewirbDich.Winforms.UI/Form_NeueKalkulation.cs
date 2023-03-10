using ApiClient;
using System.ComponentModel;

namespace coIT.BewirbDich.Winforms.UI;

public partial class Form_NeueKalkulation : Form
{
    public Form_NeueKalkulation()
    {
        InitializeComponent();
    }

    public CreateVersicherungsVorgangCommand? createVersicherungsVorgangCommand { get; set; }

    private void ctrl_Abbrechen_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    /// <summary>
    /// Berechnungsart Umsatz => ,
    /// Berechnungsart Haushaltssumme => Haushaltssumme in Euro,
    /// Berechnungsart AnzahlMitarbeiter => Ganzzahl
    /// </summary>
    private void ctrl_Berechnungsart_SelectedValueChanged(object sender, EventArgs e)
    {
        switch ((Berechnungsart)ctrl_Berechnungsart.SelectedItem)
        {
            case Berechnungsart.Umsatz:
                label_EinheitBerechnungsGrundlage.Text = "Jahresumsatz in Euro";
                ctrl_EinheitBerechnungsGrundlage.Text = "100000";
                break;

            case Berechnungsart.Haushaltssumme:
                label_EinheitBerechnungsGrundlage.Text = "Haushaltssumme in Euro";
                ctrl_EinheitBerechnungsGrundlage.Text = "100000";
                break;

            case Berechnungsart.AnzahlMitarbeiter:
                label_EinheitBerechnungsGrundlage.Text = "Anzahl Mitarbeiter";
                ctrl_EinheitBerechnungsGrundlage.Text = "3";
                break;

            default:
                break;
        }
    }

    private void ctrl_Kalkuliere_Click(object sender, EventArgs e)
    {
        createVersicherungsVorgangCommand = new CreateVersicherungsVorgangCommand
        {
            Berechnungsart = (Berechnungsart)ctrl_Berechnungsart.SelectedItem,
            Risiko = (Risiko)ctrl_Risiko.SelectedItem,
            Zusatzschutz = (Zusatzschutz)ctrl_ZusatzschutzAufschlag.SelectedItem,
            HatWebshop = ctrl_HatWebshop.Checked,
        };
        switch (createVersicherungsVorgangCommand.Berechnungsart)
        {
            case Berechnungsart.AnzahlMitarbeiter:
                createVersicherungsVorgangCommand.AnzahlMitarbeiter = int.Parse(ctrl_EinheitBerechnungsGrundlage.Text);
                break;

            default:
                createVersicherungsVorgangCommand.Versicherungssumme = decimal.Parse(ctrl_EinheitBerechnungsGrundlage.Text);
                break;
        }
        DialogResult = DialogResult.OK;
        Close();
    }

    private void Form_NeueKalkulation_Load(object sender, EventArgs e)
    {
        ctrl_Berechnungsart.DataSource = Enum.GetValues(typeof(Berechnungsart));
        ctrl_Risiko.DataSource = Enum.GetValues(typeof(Risiko));
        ctrl_ZusatzschutzAufschlag.DataSource = Enum.GetValues(typeof(Zusatzschutz));
    }
}