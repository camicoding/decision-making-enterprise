namespace AplicacionProyecto
{
    partial class VentanaComparar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.radMensual = new System.Windows.Forms.RadioButton();
            this.radBimestral = new System.Windows.Forms.RadioButton();
            this.radTrimestral = new System.Windows.Forms.RadioButton();
            this.comboMes1 = new System.Windows.Forms.ComboBox();
            this.comboBi1 = new System.Windows.Forms.ComboBox();
            this.comboTri1 = new System.Windows.Forms.ComboBox();
            this.comboMes2 = new System.Windows.Forms.ComboBox();
            this.comboBi2 = new System.Windows.Forms.ComboBox();
            this.comboTri2 = new System.Windows.Forms.ComboBox();
            this.butCompare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.PaleGreen;
            this.richTextBox2.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox2.Location = new System.Drawing.Point(135, 41);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox2.Size = new System.Drawing.Size(730, 80);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "Primero seleccione el tipo de periodos que desea comparar.\nLuego, mediante las li" +
    "stas desplegables seleccione los 2 periodos.";
            // 
            // radMensual
            // 
            this.radMensual.AutoSize = true;
            this.radMensual.Font = new System.Drawing.Font("Forte", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMensual.Location = new System.Drawing.Point(124, 178);
            this.radMensual.Name = "radMensual";
            this.radMensual.Size = new System.Drawing.Size(146, 48);
            this.radMensual.TabIndex = 3;
            this.radMensual.TabStop = true;
            this.radMensual.Text = "Comparacion\r\nMensual";
            this.radMensual.UseVisualStyleBackColor = true;
            this.radMensual.CheckedChanged += new System.EventHandler(this.radMensual_CheckedChanged);
            // 
            // radBimestral
            // 
            this.radBimestral.AutoSize = true;
            this.radBimestral.Font = new System.Drawing.Font("Forte", 15.75F);
            this.radBimestral.Location = new System.Drawing.Point(376, 178);
            this.radBimestral.Name = "radBimestral";
            this.radBimestral.Size = new System.Drawing.Size(146, 48);
            this.radBimestral.TabIndex = 4;
            this.radBimestral.TabStop = true;
            this.radBimestral.Text = "Comparacion\r\nBimestral";
            this.radBimestral.UseVisualStyleBackColor = true;
            this.radBimestral.CheckedChanged += new System.EventHandler(this.radBimestral_CheckedChanged);
            // 
            // radTrimestral
            // 
            this.radTrimestral.AutoSize = true;
            this.radTrimestral.Font = new System.Drawing.Font("Forte", 15.75F);
            this.radTrimestral.Location = new System.Drawing.Point(655, 178);
            this.radTrimestral.Name = "radTrimestral";
            this.radTrimestral.Size = new System.Drawing.Size(146, 48);
            this.radTrimestral.TabIndex = 5;
            this.radTrimestral.TabStop = true;
            this.radTrimestral.Text = "Comparacion\r\nTrimestral";
            this.radTrimestral.UseVisualStyleBackColor = true;
            this.radTrimestral.CheckedChanged += new System.EventHandler(this.radTrimestral_CheckedChanged);
            // 
            // comboMes1
            // 
            this.comboMes1.BackColor = System.Drawing.SystemColors.Highlight;
            this.comboMes1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMes1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboMes1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMes1.FormattingEnabled = true;
            this.comboMes1.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio"});
            this.comboMes1.Location = new System.Drawing.Point(124, 263);
            this.comboMes1.MaxDropDownItems = 12;
            this.comboMes1.Name = "comboMes1";
            this.comboMes1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboMes1.Size = new System.Drawing.Size(158, 36);
            this.comboMes1.TabIndex = 7;
            // 
            // comboBi1
            // 
            this.comboBi1.BackColor = System.Drawing.SystemColors.Highlight;
            this.comboBi1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBi1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBi1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBi1.FormattingEnabled = true;
            this.comboBi1.Items.AddRange(new object[] {
            "Enero-Febrero",
            "Marzo-Abril",
            "Mayo-Junio"});
            this.comboBi1.Location = new System.Drawing.Point(376, 263);
            this.comboBi1.MaxDropDownItems = 12;
            this.comboBi1.Name = "comboBi1";
            this.comboBi1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBi1.Size = new System.Drawing.Size(173, 36);
            this.comboBi1.TabIndex = 7;
            // 
            // comboTri1
            // 
            this.comboTri1.BackColor = System.Drawing.SystemColors.Highlight;
            this.comboTri1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTri1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboTri1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTri1.FormattingEnabled = true;
            this.comboTri1.Items.AddRange(new object[] {
            "Enero-Febrero-Marzo",
            "Abril-Mayo-Junio"});
            this.comboTri1.Location = new System.Drawing.Point(655, 263);
            this.comboTri1.MaxDropDownItems = 12;
            this.comboTri1.Name = "comboTri1";
            this.comboTri1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboTri1.Size = new System.Drawing.Size(222, 36);
            this.comboTri1.TabIndex = 7;
            // 
            // comboMes2
            // 
            this.comboMes2.BackColor = System.Drawing.Color.GreenYellow;
            this.comboMes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMes2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboMes2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMes2.FormattingEnabled = true;
            this.comboMes2.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio"});
            this.comboMes2.Location = new System.Drawing.Point(124, 366);
            this.comboMes2.MaxDropDownItems = 12;
            this.comboMes2.Name = "comboMes2";
            this.comboMes2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboMes2.Size = new System.Drawing.Size(158, 36);
            this.comboMes2.TabIndex = 7;
            // 
            // comboBi2
            // 
            this.comboBi2.BackColor = System.Drawing.Color.GreenYellow;
            this.comboBi2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBi2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBi2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBi2.FormattingEnabled = true;
            this.comboBi2.Items.AddRange(new object[] {
            "Enero-Febrero",
            "Marzo-Abril",
            "Mayo-Junio"});
            this.comboBi2.Location = new System.Drawing.Point(376, 366);
            this.comboBi2.MaxDropDownItems = 12;
            this.comboBi2.Name = "comboBi2";
            this.comboBi2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBi2.Size = new System.Drawing.Size(173, 36);
            this.comboBi2.TabIndex = 7;
            // 
            // comboTri2
            // 
            this.comboTri2.BackColor = System.Drawing.Color.GreenYellow;
            this.comboTri2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTri2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboTri2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTri2.FormattingEnabled = true;
            this.comboTri2.Items.AddRange(new object[] {
            "Enero-Febrero-Marzo",
            "Abril-Mayo-Junio"});
            this.comboTri2.Location = new System.Drawing.Point(655, 366);
            this.comboTri2.MaxDropDownItems = 12;
            this.comboTri2.Name = "comboTri2";
            this.comboTri2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboTri2.Size = new System.Drawing.Size(222, 36);
            this.comboTri2.TabIndex = 7;
            // 
            // butCompare
            // 
            this.butCompare.BackColor = System.Drawing.Color.Gold;
            this.butCompare.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCompare.Location = new System.Drawing.Point(348, 447);
            this.butCompare.Name = "butCompare";
            this.butCompare.Size = new System.Drawing.Size(293, 53);
            this.butCompare.TabIndex = 8;
            this.butCompare.Text = "Comparar Periodos";
            this.butCompare.UseVisualStyleBackColor = false;
            this.butCompare.Click += new System.EventHandler(this.butCompare_Click);
            // 
            // VentanaComparar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(984, 522);
            this.Controls.Add(this.butCompare);
            this.Controls.Add(this.comboTri2);
            this.Controls.Add(this.comboTri1);
            this.Controls.Add(this.comboBi2);
            this.Controls.Add(this.comboBi1);
            this.Controls.Add(this.comboMes2);
            this.Controls.Add(this.comboMes1);
            this.Controls.Add(this.radTrimestral);
            this.Controls.Add(this.radBimestral);
            this.Controls.Add(this.radMensual);
            this.Controls.Add(this.richTextBox2);
            this.MaximizeBox = false;
            this.Name = "VentanaComparar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventana de Comparacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RadioButton radMensual;
        private System.Windows.Forms.RadioButton radBimestral;
        private System.Windows.Forms.RadioButton radTrimestral;
        private System.Windows.Forms.ComboBox comboMes1;
        private System.Windows.Forms.ComboBox comboBi1;
        private System.Windows.Forms.ComboBox comboTri1;
        private System.Windows.Forms.ComboBox comboMes2;
        private System.Windows.Forms.ComboBox comboBi2;
        private System.Windows.Forms.ComboBox comboTri2;
        private System.Windows.Forms.Button butCompare;
    }
}