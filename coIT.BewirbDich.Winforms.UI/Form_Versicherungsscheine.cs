using ApiClient;

namespace coIT.BewirbDich.Winforms.UI;

public partial class Form_Versicherungsscheine : Form
{
    private readonly List<VersicherungsVorgangResponse> abgeschlosseneVersicherungsvorgaenge;
    private BindingSource versicherungsscheine;

    public Form_Versicherungsscheine(List<VersicherungsVorgangResponse> abgeschlosseneVersicherungsvorgaenge)
    {
        this.abgeschlosseneVersicherungsvorgaenge = abgeschlosseneVersicherungsvorgaenge;
        InitializeComponent();
    }

    public List<VersicherungsVorgangResponse> AbgeschlosseneVersicherungsvorgaenge { get; }

    private void Form1_Load(object sender, EventArgs e)
    {
        versicherungsscheine = new BindingSource
        {
            DataSource = abgeschlosseneVersicherungsvorgaenge
        };
        ctrl_ListeKalkulationen.DataSource = versicherungsscheine;
        ctrl_ListeKalkulationen.ColumnHeadersVisible = true;
        ctrl_ListeKalkulationen.AutoGenerateColumns = true;
        ctrl_ListeKalkulationen.Columns[nameof(VersicherungsVorgangResponse.Id)].Visible = false;
        ctrl_ListeKalkulationen.Columns[nameof(VersicherungsVorgangResponse.GesamtBeitrag)].DefaultCellStyle.Format = "c";
        ctrl_ListeKalkulationen.Columns[nameof(VersicherungsVorgangResponse.GrundBeitrag)].DefaultCellStyle.Format = "c";
        ctrl_ListeKalkulationen.Columns[nameof(VersicherungsVorgangResponse.RisikoAufschlag)].DefaultCellStyle.Format = "c";
        ctrl_ListeKalkulationen.Columns[nameof(VersicherungsVorgangResponse.WebShopAufschlag)].DefaultCellStyle.Format = "c";
        ctrl_ListeKalkulationen.Columns[nameof(VersicherungsVorgangResponse.ZusatzschutzAufschlag)].DefaultCellStyle.Format = "c";
        ctrl_ListeKalkulationen.AutoResizeColumns();
        ctrl_ListeKalkulationen.AutoSize = true;

        versicherungsscheine.ResetBindings(false);
    }
}