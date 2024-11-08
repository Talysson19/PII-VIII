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
            this.cmbClasseSocial = new System.Windows.Forms.ComboBox();
            this.cmbRaca = new System.Windows.Forms.ComboBox();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.dtpDataNascimento = new System.Windows.Forms.DateTimePicker();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCadastrarEndA = new System.Windows.Forms.Button();
            this.txtIDEscola = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEndAluno = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPcd = new System.Windows.Forms.TextBox();
            this.txtBolsa = new System.Windows.Forms.TextBox();
            this.txtAbandono = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.txtIDDisciplina = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtIDAluno = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDisciplina
            // 
            this.txtDisciplina.Location = new System.Drawing.Point(872, 60);
            this.txtDisciplina.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDisciplina.Name = "txtDisciplina";
            this.txtDisciplina.Size = new System.Drawing.Size(185, 26);
            this.txtDisciplina.TabIndex = 5;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(657, 56);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(207, 26);
            this.lblNome.TabIndex = 4;
            this.lblNome.Text = "Nome da Disciplina:";
            // 
            // btnSalvarDisc
            // 
            this.btnSalvarDisc.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSalvarDisc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarDisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSalvarDisc.Location = new System.Drawing.Point(859, 109);
            this.btnSalvarDisc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalvarDisc.Name = "btnSalvarDisc";
            this.btnSalvarDisc.Size = new System.Drawing.Size(198, 59);
            this.btnSalvarDisc.TabIndex = 3;
            this.btnSalvarDisc.Text = "Cadastrar Disciplina";
            this.btnSalvarDisc.UseVisualStyleBackColor = true;
            this.btnSalvarDisc.Click += new System.EventHandler(this.btnSalvarDisc_Click);
            // 
            // cmbClasseSocial
            // 
            this.cmbClasseSocial.AllowDrop = true;
            this.cmbClasseSocial.FormattingEnabled = true;
            this.cmbClasseSocial.Items.AddRange(new object[] {
            "Classe Alta",
            "Classe Média",
            "Classe Baixa"});
            this.cmbClasseSocial.Location = new System.Drawing.Point(263, 248);
            this.cmbClasseSocial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbClasseSocial.Name = "cmbClasseSocial";
            this.cmbClasseSocial.Size = new System.Drawing.Size(180, 28);
            this.cmbClasseSocial.TabIndex = 65;
            // 
            // cmbRaca
            // 
            this.cmbRaca.FormattingEnabled = true;
            this.cmbRaca.Items.AddRange(new object[] {
            "Negro",
            "Branco",
            "Pardo"});
            this.cmbRaca.Location = new System.Drawing.Point(263, 165);
            this.cmbRaca.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbRaca.Name = "cmbRaca";
            this.cmbRaca.Size = new System.Drawing.Size(180, 28);
            this.cmbRaca.TabIndex = 64;
            // 
            // cmbGenero
            // 
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "Masculino",
            "Feminino",
            "Outros"});
            this.cmbGenero.Location = new System.Drawing.Point(263, 122);
            this.cmbGenero.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(180, 28);
            this.cmbGenero.TabIndex = 63;
            // 
            // dtpDataNascimento
            // 
            this.dtpDataNascimento.Location = new System.Drawing.Point(263, 86);
            this.dtpDataNascimento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDataNascimento.Name = "dtpDataNascimento";
            this.dtpDataNascimento.Size = new System.Drawing.Size(298, 26);
            this.dtpDataNascimento.TabIndex = 62;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(263, 49);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(220, 26);
            this.txtNome.TabIndex = 61;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 443);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(225, 26);
            this.label8.TabIndex = 60;
            this.label8.Text = "Abandono de Escola?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(174, 344);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 26);
            this.label7.TabIndex = 59;
            this.label7.Text = "Bolsa:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(191, 294);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 26);
            this.label6.TabIndex = 58;
            this.label6.Text = "Pcd:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(96, 250);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 26);
            this.label5.TabIndex = 57;
            this.label5.Text = "Classe Social:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(122, 163);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 26);
            this.label4.TabIndex = 56;
            this.label4.Text = "Raça Etnia:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(157, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 26);
            this.label3.TabIndex = 55;
            this.label3.Text = "Genero:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 26);
            this.label2.TabIndex = 54;
            this.label2.Text = "Data De Nascimento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(170, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 26);
            this.label1.TabIndex = 53;
            this.label1.Text = "Nome:";
            // 
            // btnCadastrarEndA
            // 
            this.btnCadastrarEndA.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCadastrarEndA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrarEndA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCadastrarEndA.Location = new System.Drawing.Point(247, 502);
            this.btnCadastrarEndA.Name = "btnCadastrarEndA";
            this.btnCadastrarEndA.Size = new System.Drawing.Size(198, 59);
            this.btnCadastrarEndA.TabIndex = 52;
            this.btnCadastrarEndA.Text = "Cadastrar  Aluno";
            this.btnCadastrarEndA.UseVisualStyleBackColor = true;
            this.btnCadastrarEndA.Click += new System.EventHandler(this.btnCadastrarEndA_Click);
            // 
            // txtIDEscola
            // 
            this.txtIDEscola.Location = new System.Drawing.Point(265, 203);
            this.txtIDEscola.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIDEscola.Name = "txtIDEscola";
            this.txtIDEscola.Size = new System.Drawing.Size(180, 26);
            this.txtIDEscola.TabIndex = 70;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(141, 203);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 26);
            this.label9.TabIndex = 69;
            this.label9.Text = "IDEscola:";
            // 
            // txtEndAluno
            // 
            this.txtEndAluno.Location = new System.Drawing.Point(263, 390);
            this.txtEndAluno.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEndAluno.Name = "txtEndAluno";
            this.txtEndAluno.Size = new System.Drawing.Size(182, 26);
            this.txtEndAluno.TabIndex = 72;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(58, 388);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(189, 26);
            this.label10.TabIndex = 71;
            this.label10.Text = "IDEnderecoAluno:";
            // 
            // txtPcd
            // 
            this.txtPcd.Location = new System.Drawing.Point(263, 296);
            this.txtPcd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPcd.Name = "txtPcd";
            this.txtPcd.Size = new System.Drawing.Size(180, 26);
            this.txtPcd.TabIndex = 73;
            // 
            // txtBolsa
            // 
            this.txtBolsa.Location = new System.Drawing.Point(263, 346);
            this.txtBolsa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBolsa.Name = "txtBolsa";
            this.txtBolsa.Size = new System.Drawing.Size(180, 26);
            this.txtBolsa.TabIndex = 75;
            // 
            // txtAbandono
            // 
            this.txtAbandono.Location = new System.Drawing.Point(263, 445);
            this.txtAbandono.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAbandono.Name = "txtAbandono";
            this.txtAbandono.Size = new System.Drawing.Size(180, 26);
            this.txtAbandono.TabIndex = 76;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(676, 541);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 59);
            this.button1.TabIndex = 105;
            this.button1.Text = "Cadastro End Alunos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1182, 56);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 26);
            this.label11.TabIndex = 106;
            this.label11.Text = "Nota Média:";
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(1319, 58);
            this.txtNota.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(185, 26);
            this.txtNota.TabIndex = 107;
            // 
            // txtIDDisciplina
            // 
            this.txtIDDisciplina.Location = new System.Drawing.Point(1319, 203);
            this.txtIDDisciplina.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIDDisciplina.Name = "txtIDDisciplina";
            this.txtIDDisciplina.Size = new System.Drawing.Size(185, 26);
            this.txtIDDisciplina.TabIndex = 111;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1177, 201);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(134, 26);
            this.label13.TabIndex = 110;
            this.label13.Text = "IDDisciplina:";
            // 
            // txtIDAluno
            // 
            this.txtIDAluno.Location = new System.Drawing.Point(1319, 124);
            this.txtIDAluno.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIDAluno.Name = "txtIDAluno";
            this.txtIDAluno.Size = new System.Drawing.Size(185, 26);
            this.txtIDAluno.TabIndex = 113;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(1215, 124);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 26);
            this.label14.TabIndex = 112;
            this.label14.Text = "IDAluno:";
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button2.Location = new System.Drawing.Point(1297, 261);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 69);
            this.button2.TabIndex = 114;
            this.button2.Text = "Desempenho Acadêmico";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CadastroAlunoDesempenhoDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1728, 970);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtIDAluno);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtIDDisciplina);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtNota);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAbandono);
            this.Controls.Add(this.txtBolsa);
            this.Controls.Add(this.txtPcd);
            this.Controls.Add(this.txtEndAluno);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtIDEscola);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbClasseSocial);
            this.Controls.Add(this.cmbRaca);
            this.Controls.Add(this.cmbGenero);
            this.Controls.Add(this.dtpDataNascimento);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCadastrarEndA);
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
        private System.Windows.Forms.ComboBox cmbClasseSocial;
        private System.Windows.Forms.ComboBox cmbRaca;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.DateTimePicker dtpDataNascimento;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCadastrarEndA;
        private System.Windows.Forms.TextBox txtIDEscola;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEndAluno;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPcd;
        private System.Windows.Forms.TextBox txtBolsa;
        private System.Windows.Forms.TextBox txtAbandono;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.TextBox txtIDDisciplina;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtIDAluno;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button2;
    }
}