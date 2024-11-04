using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void EndEscola_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(211, 211, 211);
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
                this.Close();
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

