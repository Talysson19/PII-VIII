using Neo4j.Driver;
using System;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class EndAluno : Form
    {
        private readonly IDriver _driver;


        public EndAluno()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            _driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "EscolaCC"));
            ApplyFadeInTransition();
        }

        private void ApplyFadeInTransition()
        {
            this.Opacity = 0; // Define a opacidade inicial como 0
            Timer fadeInTimer = new Timer { Interval = 10 }; // Cria um timer para controle da opacidade
            fadeInTimer.Tick += (s, e) =>
            {
                if (this.Opacity < 1)
                {
                    this.Opacity += 0.04; // Aumenta a opacidade gradualmente
                }
                else
                {
                    fadeInTimer.Stop(); // Para o timer quando a opacidade atinge 1
                }
            };
            fadeInTimer.Start(); // Inicia o timer para começar o efeito
        }

        private void EndAluno_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(211, 211, 211);

        }

        private async void btnSalvarEndA_Click(object sender, EventArgs e)
        {
            string nome = txtNomeEndA.Text;
            int numero = int.Parse(txtNumEndA.Text);
            string cep = txtCEPEndA.Text;
            string bairro = txtBairroEndA.Text;
            string cidade = txtCidadeEndA.Text;
            string estado = txtEstadoEndA.Text;

            using (var session = _driver.AsyncSession())
            {
                try
                {
                    await session.ExecuteWriteAsync(async tx =>
                    {
                        // Query para inserir o nó no Neo4j
                        var query = "CREATE (p:enderecoAluno {nome: $nome, numero: $numero, cep: $cep, bairro: $bairro, cidade: $cidade , estado: $estado})";
                        var parameters = new
                        {
                            nome = nome,
                            numero = numero,
                            cep = cep,
                            bairro = bairro,
                            cidade = cidade,
                            estado = estado
                        };
                        await tx.RunAsync(query, parameters);
                    });

                    MessageBox.Show("Dados salvos com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }
    }
}

