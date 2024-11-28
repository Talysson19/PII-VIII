using Neo4j.Driver;
using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class EndEscola : Form
    {
        private Button sairbtn;
        private readonly Neo4jConnection _connection;
        private Panel headerPanel;
        private PictureBox logoPic;
        private System.Windows.Forms.Label titleLabel;
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
                BackColor = Color.FromArgb(60, 60, 60),
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

            titleLabel = new System.Windows.Forms.Label
            {
                Text = "Cadastro Endereço Escola",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
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
            //INICIO EXPANSÃO
            System.Windows.Forms.Label lblEs = new System.Windows.Forms.Label
            {
                Text = "Endereço Escola",
                ForeColor = Color.Black,
                BackColor = Color.FromArgb(211, 211, 211),
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new System.Drawing.Point(505, 220),
                Size = new Size(170, 60)
            };

            Panel panelEsc = new Panel
            {
                Name = "panelAluno",
                Size = new Size(90, 90),
                BackColor = Color.FromArgb(60, 60, 60),
                Location = new System.Drawing.Point(550, 270),
            };

            PictureBox pictureEsc = new PictureBox
            {
                Size = new Size(90, 90),
                Location = new System.Drawing.Point(0, 0),
                Image = Image.FromFile("C:\\Users\\Pichau\\OneDrive\\Área de Trabalho\\Documentos\\Área de Trabalho\\PII-VIII-master\\PII-VIII\\PII VIII\\Resources\\eEscola.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.FromArgb(211, 211, 211)
            };

            panelEsc.Controls.Add(pictureEsc);
            this.Controls.Add(panelEsc);
            this.Controls.Add(lblEs);
            bool isAlunoExpanded = false;

            pictureEsc.Click += (s, e) =>
            {
                if (!isAlunoExpanded)
                {
                    panelEsc.Size = new Size(300, 400);
                    panelEsc.AutoScroll = true;
                    pictureEsc.Visible = false;
                }

                isAlunoExpanded = !isAlunoExpanded;
            };

            panelEsc.Click += (s, e) =>
            {
                if (isAlunoExpanded)
                {
                    panelEsc.Size = new Size(80, 80);
                    panelEsc.AutoScroll = false;
                    pictureEsc.Visible = true;
                }

                isAlunoExpanded = !isAlunoExpanded;
            };
            label1.Location = new System.Drawing.Point(10, 10);
            label1.ForeColor = Color.White;
            txtNomeEndE.Location = new System.Drawing.Point(10, 40);

            label2.Location = new System.Drawing.Point(10, 80);
            label2.ForeColor = Color.White;
            txtNumEndE.Location = new System.Drawing.Point(10, 110);

            label3.Location = new System.Drawing.Point(10, 150);
            label3.ForeColor = Color.White;
            txtCEPEndE.Location = new System.Drawing.Point(10, 180);

            label4.Location = new System.Drawing.Point(10, 220);
            label4.ForeColor = Color.White;
            txtBairroEndE.Location = new System.Drawing.Point(10, 250);

            label5.Location = new System.Drawing.Point(10, 290);
            label5.ForeColor = Color.White;
            txtCidadeEndE.Location = new System.Drawing.Point(10, 320);

            label6.Location = new System.Drawing.Point(10, 360);
            label6.ForeColor = Color.White;
            txtEstadoEndE.Location = new System.Drawing.Point(10, 390);

            label7.Location = new System.Drawing.Point(10, 430);
            label7.ForeColor = Color.White;
            txtEndEID.Location = new System.Drawing.Point(10, 460);

            btnSalvarEndE.Location = new System.Drawing.Point(10, 500);
            btnSalvarEndE.FlatStyle = FlatStyle.Flat;
            btnSalvarEndE.BackColor = Color.White;
            
            panelEsc.Controls.Add(label1);
            panelEsc.Controls.Add(txtNomeEndE);
            panelEsc.Controls.Add(label2);
            panelEsc.Controls.Add(txtNumEndE);
            panelEsc.Controls.Add(label3);
            panelEsc.Controls.Add(txtCEPEndE);
            panelEsc.Controls.Add(label4);
            panelEsc.Controls.Add(txtBairroEndE);
            panelEsc.Controls.Add(label5);
            panelEsc.Controls.Add(txtCidadeEndE);
            panelEsc.Controls.Add(label6);
            panelEsc.Controls.Add(txtEstadoEndE);
            panelEsc.Controls.Add(label7);
            panelEsc.Controls.Add(label6);
            panelEsc.Controls.Add(txtEndEID);
            panelEsc.Controls.Add(btnSalvarEndE);
            //TERMINO EXPANSÃO

            ApplyStyles(panelEsc);

            sairbtn = new Button
            {
                Text = "Voltar",
                Size = new Size(100, 40),
                Location = new System.Drawing.Point(this.ClientSize.Width - 120, this.ClientSize.Height - 60),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
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


        private void ApplyStyles(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is System.Windows.Forms.Label lbl)
                {
                    lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    lbl.ForeColor = Color.White;
                }
                else if (ctrl is ComboBox cmbBox)
                {
                    cmbBox.BackColor = Color.White;
                    cmbBox.FlatStyle = FlatStyle.Flat;
                    cmbBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    cmbBox.ForeColor = Color.FromArgb(60, 60, 60);
                }
                else if (ctrl is TextBox txtBox)
                {
                    txtBox.BorderStyle = BorderStyle.FixedSingle;
                    txtBox.BackColor = Color.FromArgb(245, 245, 245);
                    txtBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    txtBox.ForeColor = Color.FromArgb(60, 60, 60);
                }
                else if (ctrl is Button button)
                {

                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.White;
                    button.ForeColor = Color.FromArgb(60, 60, 60);
                    button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = Color.White;
                }


                if (ctrl.HasChildren)
                {
                    ApplyStyles(ctrl);
                }
            }
        }

        private void AddPlaceholderEvents(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.FromArgb(60, 60, 60);

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
                    textBox.ForeColor = Color.FromArgb(60, 60, 60);
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

                CustomMessageBox.Show("Dados salvos com sucesso!");
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
