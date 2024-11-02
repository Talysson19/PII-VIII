namespace PII_VIII
{
    partial class CadastroAlunoDesempenhoDisciplina
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
            this.txtDisciplina = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.btnSalvarDisc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDisciplina
            // 
            this.txtDisciplina.Location = new System.Drawing.Point(109, 27);
            this.txtDisciplina.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDisciplina.Name = "txtDisciplina";
            this.txtDisciplina.Size = new System.Drawing.Size(289, 26);
            this.txtDisciplina.TabIndex = 5;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(22, 31);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(76, 20);
            this.lblNome.TabIndex = 4;
            this.lblNome.Text = "Disciplina";
            // 
            // btnSalvarDisc
            // 
            this.btnSalvarDisc.Location = new System.Drawing.Point(64, 87);
            this.btnSalvarDisc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalvarDisc.Name = "btnSalvarDisc";
            this.btnSalvarDisc.Size = new System.Drawing.Size(243, 63);
            this.btnSalvarDisc.TabIndex = 3;
            this.btnSalvarDisc.Text = "Cadastrar Disciplina";
            this.btnSalvarDisc.UseVisualStyleBackColor = true;
            // 
            // CadastroAlunoDesempenhoDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1705, 970);
            this.Controls.Add(this.txtDisciplina);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.btnSalvarDisc);
            this.Name = "CadastroAlunoDesempenhoDisciplina";
            this.Text = "CadastroAlunoDesempenhoDisciplina";
            this.Load += new System.EventHandler(this.CadastroAlunoDesempenhoDisciplina_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDisciplina;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Button btnSalvarDisc;
    }
}