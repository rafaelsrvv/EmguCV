namespace Novo_Emgucv
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.LIGAR = new System.Windows.Forms.Button();
            this.SalvarRosto = new System.Windows.Forms.Button();
            this.Nome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(96, 46);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(271, 185);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // LIGAR
            // 
            this.LIGAR.Location = new System.Drawing.Point(534, 69);
            this.LIGAR.Name = "LIGAR";
            this.LIGAR.Size = new System.Drawing.Size(127, 83);
            this.LIGAR.TabIndex = 3;
            this.LIGAR.Text = "DETECTAR E RECONHECER";
            this.LIGAR.UseVisualStyleBackColor = true;
            this.LIGAR.Click += new System.EventHandler(this.LIGAR_Click);
            // 
            // SalvarRosto
            // 
            this.SalvarRosto.Location = new System.Drawing.Point(534, 228);
            this.SalvarRosto.Name = "SalvarRosto";
            this.SalvarRosto.Size = new System.Drawing.Size(127, 80);
            this.SalvarRosto.TabIndex = 4;
            this.SalvarRosto.Text = "Salvar Rosto";
            this.SalvarRosto.UseVisualStyleBackColor = true;
            this.SalvarRosto.Click += new System.EventHandler(this.SalvarRosto_Click);
            // 
            // Nome
            // 
            this.Nome.Location = new System.Drawing.Point(534, 181);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(127, 20);
            this.Nome.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(480, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nome";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.SalvarRosto);
            this.Controls.Add(this.LIGAR);
            this.Controls.Add(this.imageBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button LIGAR;
        private System.Windows.Forms.Button SalvarRosto;
        private System.Windows.Forms.TextBox Nome;
        private System.Windows.Forms.Label label1;
    }
}

