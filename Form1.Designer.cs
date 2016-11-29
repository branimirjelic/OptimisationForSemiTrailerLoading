namespace Optimizacija
{
    partial class Form1
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
            this.Label1 = new System.Windows.Forms.Label();
            this.txtDuzina = new System.Windows.Forms.TextBox();
            this.btnUnos = new System.Windows.Forms.Button();
            this.lstDuzine = new System.Windows.Forms.ListBox();
            this.btnRačunaj = new System.Windows.Forms.Button();
            this.rtbPaketi = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBriši = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.SaddleBrown;
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(116, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Unesite dužinu paketa:";
            // 
            // txtDuzina
            // 
            this.txtDuzina.Location = new System.Drawing.Point(134, 6);
            this.txtDuzina.Name = "txtDuzina";
            this.txtDuzina.Size = new System.Drawing.Size(100, 20);
            this.txtDuzina.TabIndex = 1;
            this.txtDuzina.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDuzina_KeyDown);
            // 
            // btnUnos
            // 
            this.btnUnos.Location = new System.Drawing.Point(145, 32);
            this.btnUnos.Name = "btnUnos";
            this.btnUnos.Size = new System.Drawing.Size(75, 23);
            this.btnUnos.TabIndex = 2;
            this.btnUnos.Text = "Unos";
            this.btnUnos.UseVisualStyleBackColor = true;
            this.btnUnos.Click += new System.EventHandler(this.btnUnos_Click);
            // 
            // lstDuzine
            // 
            this.lstDuzine.FormattingEnabled = true;
            this.lstDuzine.Location = new System.Drawing.Point(46, 140);
            this.lstDuzine.Name = "lstDuzine";
            this.lstDuzine.Size = new System.Drawing.Size(82, 160);
            this.lstDuzine.TabIndex = 3;
            // 
            // btnRačunaj
            // 
            this.btnRačunaj.Location = new System.Drawing.Point(318, 6);
            this.btnRačunaj.Name = "btnRačunaj";
            this.btnRačunaj.Size = new System.Drawing.Size(75, 23);
            this.btnRačunaj.TabIndex = 4;
            this.btnRačunaj.Text = "Računaj";
            this.btnRačunaj.UseVisualStyleBackColor = true;
            this.btnRačunaj.Click += new System.EventHandler(this.btnRačunaj_Click);
            // 
            // rtbPaketi
            // 
            this.rtbPaketi.Location = new System.Drawing.Point(185, 140);
            this.rtbPaketi.Name = "rtbPaketi";
            this.rtbPaketi.Size = new System.Drawing.Size(355, 160);
            this.rtbPaketi.TabIndex = 5;
            this.rtbPaketi.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(43, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Neiskorišteni paketi:";
            this.label2.Visible = false;
            // 
            // btnBriši
            // 
            this.btnBriši.Location = new System.Drawing.Point(46, 111);
            this.btnBriši.Name = "btnBriši";
            this.btnBriši.Size = new System.Drawing.Size(75, 23);
            this.btnBriši.TabIndex = 7;
            this.btnBriši.Text = "Briši";
            this.btnBriši.UseVisualStyleBackColor = true;
            this.btnBriši.Click += new System.EventHandler(this.btnBriši_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Optimizacija.Properties.Resources.oakTexture;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(582, 325);
            this.Controls.Add(this.btnBriši);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbPaketi);
            this.Controls.Add(this.btnRačunaj);
            this.Controls.Add(this.lstDuzine);
            this.Controls.Add(this.btnUnos);
            this.Controls.Add(this.txtDuzina);
            this.Controls.Add(this.Label1);
            this.Name = "Form1";
            this.Text = "Optimizacija";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtDuzina;
        private System.Windows.Forms.Button btnUnos;
        private System.Windows.Forms.ListBox lstDuzine;
        private System.Windows.Forms.Button btnRačunaj;
        private System.Windows.Forms.RichTextBox rtbPaketi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBriši;
    }
}

