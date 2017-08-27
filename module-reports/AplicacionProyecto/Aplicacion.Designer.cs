namespace AplicacionProyecto
{
    partial class Aplicacion
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.butAnalizar = new System.Windows.Forms.Button();
            this.combo1 = new System.Windows.Forms.ComboBox();
            this.butComparar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Red;
            this.richTextBox1.Font = new System.Drawing.Font("Matura MT Script Capitals", 111.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.richTextBox1.Location = new System.Drawing.Point(97, 45);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(996, 185);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "Reportes la 14";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.PaleGreen;
            this.richTextBox2.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox2.Location = new System.Drawing.Point(193, 259);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox2.Size = new System.Drawing.Size(813, 87);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "Por Favor, a continuacion escoja con que sucursal desea trabajar.\nLuego presione " +
    "el boton deacuerdo al estudio que quiere realizar.";
            // 
            // butAnalizar
            // 
            this.butAnalizar.BackColor = System.Drawing.Color.Gold;
            this.butAnalizar.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAnalizar.Location = new System.Drawing.Point(529, 420);
            this.butAnalizar.Name = "butAnalizar";
            this.butAnalizar.Size = new System.Drawing.Size(238, 96);
            this.butAnalizar.TabIndex = 2;
            this.butAnalizar.Text = "Analizar";
            this.butAnalizar.UseVisualStyleBackColor = false;
            this.butAnalizar.Click += new System.EventHandler(this.butAnalizar_Click);
            // 
            // combo1
            // 
            this.combo1.BackColor = System.Drawing.SystemColors.Highlight;
            this.combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.combo1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo1.FormattingEnabled = true;
            this.combo1.Items.AddRange(new object[] {
            "101",
            "102",
            "103",
            "104",
            "105",
            "106",
            "107",
            "108",
            "109",
            "110",
            "111",
            "Todas"});
            this.combo1.Location = new System.Drawing.Point(193, 405);
            this.combo1.MaxDropDownItems = 12;
            this.combo1.Name = "combo1";
            this.combo1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.combo1.Size = new System.Drawing.Size(193, 36);
            this.combo1.TabIndex = 6;
            // 
            // butComparar
            // 
            this.butComparar.BackColor = System.Drawing.Color.Gold;
            this.butComparar.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butComparar.Location = new System.Drawing.Point(768, 584);
            this.butComparar.Name = "butComparar";
            this.butComparar.Size = new System.Drawing.Size(238, 96);
            this.butComparar.TabIndex = 7;
            this.butComparar.Text = "Comparar";
            this.butComparar.UseVisualStyleBackColor = false;
            this.butComparar.Click += new System.EventHandler(this.butComparar_Click);
            // 
            // Aplicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1184, 762);
            this.Controls.Add(this.butComparar);
            this.Controls.Add(this.combo1);
            this.Controls.Add(this.butAnalizar);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.MaximizeBox = false;
            this.Name = "Aplicacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplicacion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button butAnalizar;
        private System.Windows.Forms.ComboBox combo1;
        private System.Windows.Forms.Button butComparar;

    }
}

