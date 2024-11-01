namespace PII_VIII
{
    partial class infoDisciplinas
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
            this.btnSalvarDisc = new System.Windows.Forms.Button();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtDisciplina = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSalvarDisc
            // 
            this.btnSalvarDisc.Location = new System.Drawing.Point(76, 81);
            this.btnSalvarDisc.Name = "btnSalvarDisc";
            this.btnSalvarDisc.Size = new System.Drawing.Size(162, 41);
            this.btnSalvarDisc.TabIndex = 0;
            this.btnSalvarDisc.Text = "Cadastrar Disciplina";
            this.btnSalvarDisc.UseVisualStyleBackColor = true;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(48, 45);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(52, 13);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Disciplina";
            // 
            // txtDisciplina
            // 
            this.txtDisciplina.Location = new System.Drawing.Point(106, 42);
            this.txtDisciplina.Name = "txtDisciplina";
            this.txtDisciplina.Size = new System.Drawing.Size(194, 20);
            this.txtDisciplina.TabIndex = 2;
            // 
            // infoDisciplinas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.txtDisciplina);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.btnSalvarDisc);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "infoDisciplinas";
            this.Text = "infoDisciplinas";
            this.Load += new System.EventHandler(this.infoDisciplinas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalvarDisc;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtDisciplina;
    }
}