using Neo4j.Driver;
using System;
using System.Drawing;
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
            // Cor de fundo do formulário
            this.BackColor = Color.FromArgb(211, 211, 211);

            // Estilizar botões
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.FromArgb(31, 31, 31, 12); ;
                    button.ForeColor = Color.Black;
                    button.Font = new Font("Arial", 10, FontStyle.Bold);
                    button.FlatAppearance.BorderSize = 2; // Borda preta
                    button.FlatAppearance.BorderColor = Color.Black; // Cor da borda
                    button.FlatAppearance.MouseOverBackColor = Color.AntiqueWhite;
                }
            }

            // Estilizar TextBoxes
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Font = new Font("Arial", 10);
                    textBox.BackColor = Color.WhiteSmoke;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.Margin = new Padding(10); // Adiciona espaço interno
                }
            }

            // Estilizar ComboBoxes
            foreach (Control control in this.Controls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.Font = new Font("Arial", 10);
                    comboBox.BackColor = Color.WhiteSmoke;
                    comboBox.Padding = new Padding(10); // Adiciona espaço interno
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList; // Previne edição no combo
                }
            }

            // Estilizar Labels
            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    label.Font = new Font("Arial", 10);
                    label.ForeColor = Color.Black;
                }
            }
        }

        private void EndEscola_Load(object sender, EventArgs e)
        {
            // Aplique o fundo novamente ao carregar
            this.BackColor = Color.FromArgb(211, 211, 211);
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
