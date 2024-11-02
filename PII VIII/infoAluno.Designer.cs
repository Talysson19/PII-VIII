namespace PII_VIII
{
    partial class infoAluno
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
            this.btnCadastrarEndA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCadastrarEndA
            // 
            this.btnCadastrarEndA.Location = new System.Drawing.Point(11, 11);
            this.btnCadastrarEndA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCadastrarEndA.Name = "btnCadastrarEndA";
            this.btnCadastrarEndA.Size = new System.Drawing.Size(79, 50);
            this.btnCadastrarEndA.TabIndex = 0;
            this.btnCadastrarEndA.Text = "Cadastrar Endereço do Aluno";
            this.btnCadastrarEndA.UseVisualStyleBackColor = true;
            this.btnCadastrarEndA.Click += new System.EventHandler(this.btnCadastrarEndA_Click);
            // 
            // infoAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 422);
            this.Controls.Add(this.btnCadastrarEndA);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "infoAluno";
            this.Text = "infoAluno";
            this.Load += new System.EventHandler(this.infoAluno_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCadastrarEndA;
    }
}