﻿using Neo4j.Driver;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class EndAluno : Form
    {
        private Button sairbtn;
        private Button button1;
        private readonly Neo4jConnection _connection;
        private Panel headerPanel;
        private PictureBox logoPic;
        private Label titleLabel;
        private Panel contentPanel;

        public EndAluno()
        {
            this.FormBorderStyle = FormBorderStyle.None; ;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _connection = new Neo4jConnection("bolt://localhost:7687", "neo4j", "EscolaCC");
            InicializarCabecalho();
            InicializarConteudo();
            ApplyFadeInTransition();
            ApplyStyles();

            txtIDEndAluno.TextAlign = HorizontalAlignment.Center;
            txtRua.TextAlign = HorizontalAlignment.Center;
            txtNum.TextAlign = HorizontalAlignment.Center;
            txtCep.TextAlign = HorizontalAlignment.Center;
            txtBairro.TextAlign = HorizontalAlignment.Center;
            txtCidade.TextAlign = HorizontalAlignment.Center;
            txtEstado.TextAlign = HorizontalAlignment.Center;

            AddPlaceholders();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CadastroAlunoDesempenhoDisciplina cada = new CadastroAlunoDesempenhoDisciplina();
            cada.ShowDialog();
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

        private void InicializarCabecalho()
        {
            headerPanel = new Panel
            {
                Size = new Size(this.ClientSize.Width, 120),
                BackColor = Color.FromArgb(31, 31, 31),
                Dock = DockStyle.Top
            };

            try
            {
                logoPic = new PictureBox
                {
                    Image = Image.FromFile("images/unifenas1.logo.png"),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(280, 80),
                    Location = new System.Drawing.Point(10, 10)
                };
                headerPanel.Controls.Add(logoPic);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar a imagem da logo: " + ex.Message);
            }

            titleLabel = new Label
            {
                Text = "Cadastro Endereço Aluno",
                ForeColor = Color.White,
                Font = new Font("Arial", 20, FontStyle.Bold),
                AutoSize = true
            };
            headerPanel.Controls.Add(titleLabel);

            titleLabel.Location = new System.Drawing.Point((headerPanel.Width - titleLabel.Width) / 2, (headerPanel.Height - titleLabel.Height) / 2);

            this.Controls.Add(headerPanel);

            this.Resize += (s, e) =>
            {
                titleLabel.Location = new System.Drawing.Point((headerPanel.Width - titleLabel.Width) / 2, (headerPanel.Height - titleLabel.Height) / 2);
            };
        }


        private void VoltarParaForm1()
        {
            Timer fadeOutTimer = new Timer { Interval = 10 };
            fadeOutTimer.Tick += (s, ev) =>
            {
                if (this.Opacity > 0)
                {
                    this.Opacity -= 0.04;
                }
                else
                {
                    fadeOutTimer.Stop();
                    this.Close();
                }
            };
            fadeOutTimer.Start();
        }
        private void InicializarConteudo()
        {
            sairbtn = new Button
            {
                Text = "Voltar",
                Size = new Size(100, 40),
                Location = new System.Drawing.Point(this.ClientSize.Width - 120, this.ClientSize.Height - 60),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            sairbtn.FlatAppearance.BorderSize = 0;
            sairbtn.Click += (sender, e) => VoltarParaForm1();
            this.Controls.Add(sairbtn);

            button1 = new Button
            {
                Text = "Cadastro Aluno",
                Size = new Size(100, 50),
                Location = new System.Drawing.Point(this.ClientSize.Width - 250, this.ClientSize.Height - 60),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font("Arial", 9, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };

            this.Controls.Add(button1);

            button1.Click += Button1_Click;

            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(211, 211, 211)
            };

            FlowLayoutPanel buttonLayout = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(10)
            };

            var exampleButton = new Button
            {
                Text = "Salvar Endereço",
                Size = new Size(150, 40),
                Margin = new Padding(5)
            };
            exampleButton.Click += btnSalvarEndAluno_Click;
            buttonLayout.Controls.Add(exampleButton);

            var cadastroAlunoButton = new Button
            {
                Text = "Cadastrar Aluno",
                Size = new Size(150, 40),
                Margin = new Padding(5)
            };
            cadastroAlunoButton.Click += button1_Click;
            buttonLayout.Controls.Add(cadastroAlunoButton);

            contentPanel.Controls.Add(buttonLayout);
            this.Controls.Add(contentPanel);
        }

        private void ApplyStyles()
        {
            this.BackColor = Color.FromArgb(211, 211, 211);
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.Black;
                    button.ForeColor = Color.White;
                    button.Font = new Font("Arial", 10, FontStyle.Bold);
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = Color.White;
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
                    label.Font = new Font("Arial", 10);
                    label.ForeColor = Color.Black;
                }
            }
        }


        private void EndEscola_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(211, 211, 211);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            CadastroAlunoDesempenhoDisciplina cadA = new CadastroAlunoDesempenhoDisciplina();
            cadA.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Timer fadeOutTimer = new Timer { Interval = 10 };
            fadeOutTimer.Tick += (s, ev) =>
            {
                if (this.Opacity > 0)
                {
                    this.Opacity -= 0.04;
                }
                else
                {
                    fadeOutTimer.Stop();
                    this.Close();
                }
            };
            fadeOutTimer.Start();
        }
        private void AddPlaceholderEvents(TextBox textBox, string placeholder)
        {
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
    }
}
        