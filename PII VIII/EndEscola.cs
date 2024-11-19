﻿using Neo4j.Driver;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class EndEscola : Form
    {
        private readonly Neo4jConnection _connection;
        private Panel headerPanel;
        private PictureBox logoPic;
        private Label titleLabel;
        private Panel contentPanel;

        public EndEscola()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _connection = new Neo4jConnection("bolt://localhost:7687", "neo4j", "EscolaCC");
            ApplyFadeInTransition();
            InicializarCabecalho();
            InicializarConteudo();
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
                Text = "Cadastro Endereço Escola",
                ForeColor = Color.White,
                Font = new Font("Arial", 20, FontStyle.Bold),
                AutoSize = true
            };
            headerPanel.Controls.Add(titleLabel);

            CentralizarTitulo();

            this.Controls.Add(headerPanel);

            this.Resize += (s, e) =>
            {
                CentralizarTitulo();
            };
        }

        private void CentralizarTitulo()
        {
            titleLabel.Location = new System.Drawing.Point(
                (headerPanel.Width - titleLabel.Width) / 2,
                (headerPanel.Height - titleLabel.Height) / 2);
        }


        private void InicializarConteudo()
        {
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

            var salvarButton = new Button
            {
                Text = "Salvar Endereço",
                Size = new Size(150, 40),
                Margin = new Padding(5)
            };
            salvarButton.Click += btnSalvarEndE_Click;
            buttonLayout.Controls.Add(salvarButton);

            var cadastrarButton = new Button
            {
                Text = "Cadastrar Escola",
                Size = new Size(150, 40),
                Margin = new Padding(5)
            };
            cadastrarButton.Click += button1_Click;
            buttonLayout.Controls.Add(cadastrarButton);

            contentPanel.Controls.Add(buttonLayout);
            this.Controls.Add(contentPanel);
        }

        private void ApplyStyles()
        {
            this.BackColor = Color.FromArgb(211, 211, 211);

            foreach (Control control in contentPanel.Controls)
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
                else if (control is TextBox textBox)
                {
                    textBox.Font = new Font("Arial", 10);
                    textBox.BackColor = Color.WhiteSmoke;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.Margin = new Padding(10);
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.Font = new Font("Arial", 10);
                    comboBox.BackColor = Color.WhiteSmoke;
                    comboBox.Padding = new Padding(10);
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                else if (control is Label label)
                {
                    label.Font = new Font("Arial", 8);
                    label.ForeColor = Color.Black;
                }
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
