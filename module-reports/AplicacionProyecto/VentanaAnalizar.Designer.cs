namespace AplicacionProyecto
{
    partial class VentanaAnalizar
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
            this.butCompare = new System.Windows.Forms.Button();
            this.comboTri = new System.Windows.Forms.ComboBox();
            this.comboBi = new System.Windows.Forms.ComboBox();
            this.comboMes = new System.Windows.Forms.ComboBox();
            this.radTrimestral = new System.Windows.Forms.RadioButton();
            this.radBimestral = new System.Windows.Forms.RadioButton();
            this.radMensual = new System.Windows.Forms.RadioButton();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // butCompare
            // 
            this.butCompare.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.butCompare.BackColor = System.Drawing.Color.Gold;
            this.butCompare.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCompare.Location = new System.Drawing.Point(346, 435);
            this.butCompare.Name = "butCompare";
            this.butCompare.Size = new System.Drawing.Size(293, 53);
            this.butCompare.TabIndex = 19;
            this.butCompare.Text = "Analizar Periodos";
            this.butCompare.UseVisualStyleBackColor = false;
            this.butCompare.Click += new System.EventHandler(this.butCompare_Click);
            // 
            // comboTri
            // 
            this.comboTri.BackColor = System.Drawing.SystemColors.Highlight;
            this.comboTri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTri.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboTri.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTri.FormattingEnabled = true;
            this.comboTri.Items.AddRange(new object[] {
            "Enero-Febrero-Marzo",
            "Febrero-Marzo-Abril",
            "Marzo-Abril-Mayo",
            "Abril-Mayo-Junio"});
            this.comboTri.Location = new System.Drawing.Point(647, 292);
            this.comboTri.MaxDropDownItems = 12;
            this.comboTri.Name = "comboTri";
            this.comboTri.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboTri.Size = new System.Drawing.Size(222, 36);
            this.comboTri.TabIndex = 14;
            // 
            // comboBi
            // 
            this.comboBi.BackColor = System.Drawing.Color.GreenYellow;
            this.comboBi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBi.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBi.FormattingEnabled = true;
            this.comboBi.Items.AddRange(new object[] {
            "Enero-Febrero",
            "Febrero-Marzo",
            "Marzo-Abril",
            "Abril-Mayo",
            "Mayo-Junio"});
            this.comboBi.Location = new System.Drawing.Point(368, 292);
            this.comboBi.MaxDropDownItems = 12;
            this.comboBi.Name = "comboBi";
            this.comboBi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBi.Size = new System.Drawing.Size(173, 36);
            this.comboBi.TabIndex = 16;
            // 
            // comboMes
            // 
            this.comboMes.BackColor = System.Drawing.SystemColors.Highlight;
            this.comboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboMes.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMes.FormattingEnabled = true;
            this.comboMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio"});
            this.comboMes.Location = new System.Drawing.Point(116, 292);
            this.comboMes.MaxDropDownItems = 12;
            this.comboMes.Name = "comboMes";
            this.comboMes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboMes.Size = new System.Drawing.Size(158, 36);
            this.comboMes.TabIndex = 18;
            // 
            // radTrimestral
            // 
            this.radTrimestral.AutoSize = true;
            this.radTrimestral.Font = new System.Drawing.Font("Forte", 15.75F);
            this.radTrimestral.Location = new System.Drawing.Point(658, 190);
            this.radTrimestral.Name = "radTrimestral";
            this.radTrimestral.Size = new System.Drawing.Size(135, 48);
            this.radTrimestral.TabIndex = 12;
            this.radTrimestral.TabStop = true;
            this.radTrimestral.Text = "Analisis de\r\nun Trimestre";
            this.radTrimestral.UseVisualStyleBackColor = true;
            this.radTrimestral.CheckedChanged += new System.EventHandler(this.radTrimestral_CheckedChanged);
            // 
            // radBimestral
            // 
            this.radBimestral.AutoSize = true;
            this.radBimestral.Font = new System.Drawing.Font("Forte", 15.75F);
            this.radBimestral.Location = new System.Drawing.Point(379, 190);
            this.radBimestral.Name = "radBimestral";
            this.radBimestral.Size = new System.Drawing.Size(132, 48);
            this.radBimestral.TabIndex = 11;
            this.radBimestral.TabStop = true;
            this.radBimestral.Text = "Analisis de\r\nun Bimestre";
            this.radBimestral.UseVisualStyleBackColor = true;
            this.radBimestral.CheckedChanged += new System.EventHandler(this.radBimestral_CheckedChanged);
            // 
            // radMensual
            // 
            this.radMensual.AutoSize = true;
            this.radMensual.Font = new System.Drawing.Font("Forte", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMensual.Location = new System.Drawing.Point(127, 190);
            this.radMensual.Name = "radMensual";
            this.radMensual.Size = new System.Drawing.Size(131, 48);
            this.radMensual.TabIndex = 10;
            this.radMensual.TabStop = true;
            this.radMensual.Text = "Analisis de\r\nun Mes";
            this.radMensual.UseVisualStyleBackColor = true;
            this.radMensual.CheckedChanged += new System.EventHandler(this.radMensual_CheckedChanged);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.PaleGreen;
            this.richTextBox2.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox2.Location = new System.Drawing.Point(127, 39);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox2.Size = new System.Drawing.Size(730, 80);
            this.richTextBox2.TabIndex = 9;
            this.richTextBox2.Text = "Primero seleccione el tipo de periodos que desea comparar.\nLuego, mediante las li" +
    "stas desplegables seleccione los 2 periodos.";
            // 
            // VentanaAnalizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(984, 522);
            this.Controls.Add(this.butCompare);
            this.Controls.Add(this.comboTri);
            this.Controls.Add(this.comboBi);
            this.Controls.Add(this.comboMes);
            this.Controls.Add(this.radTrimestral);
            this.Controls.Add(this.radBimestral);
            this.Controls.Add(this.radMensual);
            this.Controls.Add(this.richTextBox2);
            this.MaximizeBox = false;
            this.Name = "VentanaAnalizar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventana de Analisis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butCompare;
        private System.Windows.Forms.ComboBox comboTri;
        private System.Windows.Forms.ComboBox comboBi;
        private System.Windows.Forms.ComboBox comboMes;
        private System.Windows.Forms.RadioButton radTrimestral;
        private System.Windows.Forms.RadioButton radBimestral;
        private System.Windows.Forms.RadioButton radMensual;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}