namespace coIT.BewirbDich.Winforms.UI;

partial class Form_Lieferscheine
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
            this.ctrl_ListeKalkulationen = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ctrl_ListeKalkulationen)).BeginInit();
            this.SuspendLayout();
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
            this.ctrl_ListeKalkulationen.Location = new System.Drawing.Point(12, 14);
            this.ctrl_ListeKalkulationen.Name = "ctrl_ListeKalkulationen";
            this.ctrl_ListeKalkulationen.ReadOnly = true;
            this.ctrl_ListeKalkulationen.RowTemplate.Height = 25;
            this.ctrl_ListeKalkulationen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctrl_ListeKalkulationen.Size = new System.Drawing.Size(1184, 424);
            this.ctrl_ListeKalkulationen.TabIndex = 1;
            // 
            // Form_Lieferscheine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 450);
            this.Controls.Add(this.ctrl_ListeKalkulationen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Lieferscheine";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deine Bewerbung";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctrl_ListeKalkulationen)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion
    private DataGridView ctrl_ListeKalkulationen;
}