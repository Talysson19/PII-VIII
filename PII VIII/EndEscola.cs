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
    public partial class EndEscola : Form
    {
        private readonly Neo4jConnection _connection;
        public EndEscola()
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

        private async void btnSalvarEndE_Click(object sender, EventArgs e)
        {
            string nome = txtNomeEndE.Text;
            int numero = int.Parse(txtNumEndE.Text);
            string cep = txtCEPEndE.Text;
            string bairro = txtBairroEndE.Text;
            string cidade = txtCidadeEndE.Text;
            string estado = txtEstadoEndE.Text;
            int idescola = int.Parse(txtEndEID.Text);

            try
            {
                await _connection.ExecuteWriteAsync(async tx =>
                {
                    var query = "CREATE (p:enderecoEscola {nome: $nome, numero: $numero, cep: $cep, bairro: $bairro, cidade: $cidade , estado: $estado, idescola: $idescola})";
                    var parameters = new
                    {
                        nome,
                        numero,
                        cep,
                        bairro,
                        cidade,
                        estado,
                        idescola
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
            CadastroEscolaRec cadE = new CadastroEscolaRec();
            cadE.ShowDialog();
        }
    }
}
