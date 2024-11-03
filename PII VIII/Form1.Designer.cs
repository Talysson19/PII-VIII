namespace PII_VIII
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
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.sidebarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(48, 374);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(266, 68);
            this.button8.TabIndex = 11;
            this.button8.Text = "Cadastro Escolas";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(48, 490);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(266, 68);
            this.button7.TabIndex = 10;
            this.button7.Text = "Cadastro Alunos";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.AutoScrollMargin = new System.Drawing.Size(200, 0);
            this.sidebarPanel.Controls.Add(this.button8);
            this.sidebarPanel.Controls.Add(this.button7);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(365, 925);
            this.sidebarPanel.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScrollMargin = new System.Drawing.Size(200, 0);
            this.ClientSize = new System.Drawing.Size(1537, 925);
            this.Controls.Add(this.sidebarPanel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Página Principal";
            this.sidebarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel sidebarPanel;
    }
}

