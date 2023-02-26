namespace coIT.BewirbDich.Winforms.UI;

partial class Form_Kalkulationen
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.ctr_NeueKalkulation = new System.Windows.Forms.Button();
            this.ctrl_ListeKalkulationen = new System.Windows.Forms.DataGridView();
            this.ctrl_AngebotAnnehmen = new System.Windows.Forms.Button();
            this.ctrl_VersicherungsscheinAusstellen = new System.Windows.Forms.Button();
            this.ctrl_AngebotLoeschen = new System.Windows.Forms.Button();
            this.ctrl_Aktualisieren = new System.Windows.Forms.Button();
            this.ctrl_VersicherungScheine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ctrl_ListeKalkulationen)).BeginInit();
            this.SuspendLayout();
            // 
            // ctr_NeueKalkulation
            // 
            this.ctr_NeueKalkulation.Location = new System.Drawing.Point(12, 12);
            this.ctr_NeueKalkulation.Name = "ctr_NeueKalkulation";
            this.ctr_NeueKalkulation.Size = new System.Drawing.Size(75, 41);
            this.ctr_NeueKalkulation.TabIndex = 0;
            this.ctr_NeueKalkulation.Text = "+ NEU";
            this.ctr_NeueKalkulation.UseVisualStyleBackColor = true;
            this.ctr_NeueKalkulation.Click += new System.EventHandler(this.ctr_NeueKalkulation_Click);
            // 
            // ctrl_ListeKalkulationen
            // 
            this.ctrl_ListeKalkulationen.AllowUserToAddRows = false;
            this.ctrl_ListeKalkulationen.AllowUserToDeleteRows = false;
            this.ctrl_ListeKalkulationen.AllowUserToOrderColumns = true;
            this.ctrl_ListeKalkulationen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrl_ListeKalkulationen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrl_ListeKalkulationen.Location = new System.Drawing.Point(12, 79);
            this.ctrl_ListeKalkulationen.Name = "ctrl_ListeKalkulationen";
            this.ctrl_ListeKalkulationen.ReadOnly = true;
            this.ctrl_ListeKalkulationen.RowTemplate.Height = 25;
            this.ctrl_ListeKalkulationen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctrl_ListeKalkulationen.Size = new System.Drawing.Size(1184, 359);
            this.ctrl_ListeKalkulationen.TabIndex = 1;
            this.ctrl_ListeKalkulationen.SelectionChanged += new System.EventHandler(this.ctrl_ListeKalkulationen_SelectionChanged);
            // 
            // ctrl_AngebotAnnehmen
            // 
            this.ctrl_AngebotAnnehmen.Enabled = false;
            this.ctrl_AngebotAnnehmen.Location = new System.Drawing.Point(93, 12);
            this.ctrl_AngebotAnnehmen.Name = "ctrl_AngebotAnnehmen";
            this.ctrl_AngebotAnnehmen.Size = new System.Drawing.Size(94, 41);
            this.ctrl_AngebotAnnehmen.TabIndex = 3;
            this.ctrl_AngebotAnnehmen.Text = "Annehmen 👍";
            this.ctrl_AngebotAnnehmen.UseVisualStyleBackColor = true;
            this.ctrl_AngebotAnnehmen.Click += new System.EventHandler(this.ctrl_AngebotAnnehmen_Click);
            // 
            // ctrl_VersicherungsscheinAusstellen
            // 
            this.ctrl_VersicherungsscheinAusstellen.Enabled = false;
            this.ctrl_VersicherungsscheinAusstellen.Location = new System.Drawing.Point(193, 12);
            this.ctrl_VersicherungsscheinAusstellen.Name = "ctrl_VersicherungsscheinAusstellen";
            this.ctrl_VersicherungsscheinAusstellen.Size = new System.Drawing.Size(94, 41);
            this.ctrl_VersicherungsscheinAusstellen.TabIndex = 4;
            this.ctrl_VersicherungsscheinAusstellen.Text = "Ausstellen 🖨";
            this.ctrl_VersicherungsscheinAusstellen.UseVisualStyleBackColor = true;
            this.ctrl_VersicherungsscheinAusstellen.Click += new System.EventHandler(this.ctrl_VersicherungsscheinAusstellen_Click);
            // 
            // ctrl_AngebotLoeschen
            // 
            this.ctrl_AngebotLoeschen.Enabled = false;
            this.ctrl_AngebotLoeschen.Location = new System.Drawing.Point(1102, 12);
            this.ctrl_AngebotLoeschen.Name = "ctrl_AngebotLoeschen";
            this.ctrl_AngebotLoeschen.Size = new System.Drawing.Size(94, 41);
            this.ctrl_AngebotLoeschen.TabIndex = 5;
            this.ctrl_AngebotLoeschen.Text = "Löschen";
            this.ctrl_AngebotLoeschen.UseVisualStyleBackColor = true;
            this.ctrl_AngebotLoeschen.Click += new System.EventHandler(this.ctrl_AngebotLoeschen_Click);
            // 
            // ctrl_Aktualisieren
            // 
            this.ctrl_Aktualisieren.Location = new System.Drawing.Point(293, 12);
            this.ctrl_Aktualisieren.Name = "ctrl_Aktualisieren";
            this.ctrl_Aktualisieren.Size = new System.Drawing.Size(94, 41);
            this.ctrl_Aktualisieren.TabIndex = 6;
            this.ctrl_Aktualisieren.Text = "Aktualisieren";
            this.ctrl_Aktualisieren.UseVisualStyleBackColor = true;
            this.ctrl_Aktualisieren.Click += new System.EventHandler(this.ctrl_Aktualisieren_Click);
            // 
            // ctrl_VersicherungScheine
            // 
            this.ctrl_VersicherungScheine.Location = new System.Drawing.Point(393, 12);
            this.ctrl_VersicherungScheine.Name = "ctrl_VersicherungScheine";
            this.ctrl_VersicherungScheine.Size = new System.Drawing.Size(187, 41);
            this.ctrl_VersicherungScheine.TabIndex = 7;
            this.ctrl_VersicherungScheine.Text = "Versicherungscheine";
            this.ctrl_VersicherungScheine.UseVisualStyleBackColor = true;
            this.ctrl_VersicherungScheine.Click += new System.EventHandler(this.ctrl_Versicherungsscheine_Click);
            // 
            // Form_Kalkulationen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 450);
            this.Controls.Add(this.ctrl_VersicherungScheine);
            this.Controls.Add(this.ctrl_Aktualisieren);
            this.Controls.Add(this.ctrl_AngebotLoeschen);
            this.Controls.Add(this.ctrl_VersicherungsscheinAusstellen);
            this.Controls.Add(this.ctrl_AngebotAnnehmen);
            this.Controls.Add(this.ctrl_ListeKalkulationen);
            this.Controls.Add(this.ctr_NeueKalkulation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Kalkulationen";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deine Bewerbung";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctrl_ListeKalkulationen)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private Button ctr_NeueKalkulation;
    private DataGridView ctrl_ListeKalkulationen;
    private Button ctrl_AngebotAnnehmen;
    private Button ctrl_VersicherungsscheinAusstellen;
    private Button ctrl_AngebotLoeschen;
    private Button ctrl_Aktualisieren;
    private Button ctrl_VersicherungScheine;
}