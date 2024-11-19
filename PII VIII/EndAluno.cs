﻿using Neo4j.Driver;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class EndAluno : Form
    {
        private readonly Neo4jConnection _connection;

        public EndAluno()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            _connection = new Neo4jConnection("bolt://localhost:7687", "neo4j", "EscolaCC");
            ApplyFadeInTransition();
            ApplyStyles();
        }

        private void ApplyFadeInTransition()
        {
            this.Opacity = 0;
            Timer fadeInTimer = new Timer { Interval = 10 };
            fadeInTimer.Tick += (s, e) =>
            {
                if (this.Opacity < 1)
                {
                    this.Opacity += 0.04;
                }
                else
                {
                    fadeInTimer.Stop();
                }
            };
            fadeInTimer.Start();
        }

        private void ApplyStyles()
        {
            this.BackColor = Color.FromArgb(211, 211, 211);

            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.FromArgb(31, 31, 31, 12);
                    button.ForeColor = Color.Black;
                    button.Font = new Font("Arial", 10, FontStyle.Bold);
                    button.FlatAppearance.BorderSize = 2; 
                    button.FlatAppearance.BorderColor = Color.Black; 
                    button.FlatAppearance.MouseOverBackColor = Color.AntiqueWhite;
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Font = new Font("Arial", 10);
                    textBox.BackColor = Color.WhiteSmoke;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.Margin = new Padding(10); 
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.Font = new Font("Arial", 10);
                    comboBox.BackColor = Color.WhiteSmoke;
                    comboBox.Padding = new Padding(10); 
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList; 
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    label.Font = new Font("Arial", 8);
                    label.ForeColor = Color.Black;
                }
            }
        }

        private void EndEscola_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(211, 211, 211);
        }

        private async void btnSalvarEndAluno_Click(object sender, EventArgs e)
        {
            string rua = txtRua.Text.Trim();
            int numero;
            string cep = txtCep.Text.Trim();
            string bairro = txtBairro.Text.Trim();
            string cidade = txtCidade.Text.Trim();
            string estado = txtEstado.Text.Trim();

            if (!int.TryParse(txtIDEndAluno.Text, out int idEndAluno))
            {
                MessageBox.Show("ID do Endereço Aluno deve ser um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtNum.Text, out numero))
            {
                MessageBox.Show("Número deve ser um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                await _connection.ExecuteWriteAsync(async tx =>
                {
                    var query = "CREATE (e:EnderecoAluno {idEnderecoAluno: $idEnderecoAluno, Rua: $Rua, Numero: $Numero, CEP: $Cep, Bairro: $Bairro, Cidade: $Cidade, Estado: $Estado})";
                    var parameters = new
                    {
                        idEnderecoAluno = idEndAluno,
                        Rua = rua,
                        Numero = numero.ToString(),
                        Cep = cep,
                        Bairro = bairro,
                        Cidade = cidade,
                        Estado = estado
                    };
                    await tx.RunAsync(query, parameters);
                });

                MessageBox.Show("Dados salvos com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastroAlunoDesempenhoDisciplina cadA = new CadastroAlunoDesempenhoDisciplina();
            cadA.ShowDialog();
        }
    }
}
