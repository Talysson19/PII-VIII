using Neo4j.Driver;
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

            // Configurando os TextBox com alinhamento central
            txtIDEndAluno.TextAlign = HorizontalAlignment.Center;
            txtRua.TextAlign = HorizontalAlignment.Center;
            txtNum.TextAlign = HorizontalAlignment.Center;
            txtCep.TextAlign = HorizontalAlignment.Center;
            txtBairro.TextAlign = HorizontalAlignment.Center;
            txtCidade.TextAlign = HorizontalAlignment.Center;
            txtEstado.TextAlign = HorizontalAlignment.Center;

            // Adicionando placeholders aos TextBox
            AddPlaceholders();
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
                    textBox.BackColor = Color.WhiteSmoke;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.Margin = new Padding(10);
                    textBox.ForeColor = Color.Gray; // Definindo a cor do texto como cinza para placeholders
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = Color.WhiteSmoke;
                    comboBox.Padding = new Padding(10);
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
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

        // Método para adicionar os eventos de placeholder
        private void AddPlaceholderEvents(TextBox textBox, string placeholder)
        {
            // Inicializa o TextBox com o placeholder
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
            }

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        // Método para configurar os placeholders
        private void AddPlaceholders()
        {
            AddPlaceholderEvents(txtIDEndAluno, "Digite o ID...");
            AddPlaceholderEvents(txtRua, "Digite a rua...");
            AddPlaceholderEvents(txtNum, "Digite o número...");
            AddPlaceholderEvents(txtCep, "Digite o CEP...");
            AddPlaceholderEvents(txtBairro, "Digite o bairro...");
            AddPlaceholderEvents(txtCidade, "Digite a cidade...");
            AddPlaceholderEvents(txtEstado, "Digite o estado...");
        }
    }
}