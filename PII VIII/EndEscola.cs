using Neo4j.Driver;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class EndEscola : Form
    {
        private Button sairbtn;
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


            AddPlaceholderEvents(txtNomeEndE, "Digite o nome da escola...");
            AddPlaceholderEvents(txtNumEndE, "Digite o número...");
            AddPlaceholderEvents(txtCEPEndE, "Digite o CEP...");
            AddPlaceholderEvents(txtBairroEndE, "Digite o bairro...");
            AddPlaceholderEvents(txtCidadeEndE, "Digite a cidade...");
            AddPlaceholderEvents(txtEstadoEndE, "Digite o estado...");
            AddPlaceholderEvents(txtEndEID, "Digite o ID...");
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

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    lbl.ForeColor = Color.FromArgb(31, 31, 31);
                }
            }


            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ComboBox cmbBox)
                {
                    cmbBox.BackColor = Color.White;
                    cmbBox.FlatStyle = FlatStyle.Flat;
                    cmbBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    cmbBox.ForeColor = Color.Black;
                }
            }

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txtBox)
                {
                    txtBox.BorderStyle = BorderStyle.FixedSingle;
                    txtBox.BackColor = Color.FromArgb(245, 245, 245);
                    txtBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    txtBox.ForeColor = Color.Black;
                }
            }

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
                    label.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    label.ForeColor = Color.FromArgb(31, 31, 31);
                    label.BackColor = Color.Transparent;
                    label.TextAlign = ContentAlignment.MiddleLeft;
                }
            }
        }

        private void AddPlaceholderEvents(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

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
    }
}
