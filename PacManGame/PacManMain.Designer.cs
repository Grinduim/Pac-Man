namespace PacManGame
{
    partial class PacManMain
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
            this.Jogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Jogo)).BeginInit();
            this.SuspendLayout();
            // 
            // Jogo
            // 
            this.Jogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Jogo.Location = new System.Drawing.Point(0, 0);
            this.Jogo.Name = "Jogo";
            this.Jogo.Size = new System.Drawing.Size(800, 450);
            this.Jogo.TabIndex = 0;
            this.Jogo.TabStop = false;
            // 
            // PacManMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Jogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PacManMain";
            this.Text = "42";
            this.Load += new System.EventHandler(this.PacManMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReadKey);
            ((System.ComponentModel.ISupportInitialize)(this.Jogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Jogo;
    }
}

