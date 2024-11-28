using Neo4j.Driver;
using System;
using System.Drawing;
using System.Reflection.Emit;
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
        private System.Windows.Forms.Label titleLabel;
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



            btnSalvarEndAluno.FlatStyle = FlatStyle.Flat;
            btnSalvarEndAluno.BackColor = Color.White;

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
                Text = "Cadastro Endereço Aluno",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
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





        private void EndEscola_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(211, 211, 211);
            
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






        private void InicializarConteudo()
        {


            //INICIO EXPANSÃO 
            System.Windows.Forms.Label lblAl = new System.Windows.Forms.Label
            {
                Text = "Endereço Aluno",
                ForeColor = Color.Black,
                BackColor = Color.FromArgb(211, 211, 211),
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new System.Drawing.Point(505, 220),
                Size = new Size(170, 60)
            };

            Panel panelAluno = new Panel
            {
                Name = "panelAluno",
                Size = new Size(80, 80),
                BackColor = Color.FromArgb(60, 60, 60 ),
                Location = new System.Drawing.Point(550, 270),
            };

            PictureBox pictureAluno = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new System.Drawing.Point(0, 0),
                Image = Image.FromFile("C:\\Users\\Pichau\\OneDrive\\Área de Trabalho\\Documentos\\Área de Trabalho\\PII-VIII-master\\PII-VIII\\PII VIII\\Resources\\casa.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.FromArgb(211, 211, 211)
            };

            panelAluno.Controls.Add(pictureAluno);
            this.Controls.Add(panelAluno);
            this.Controls.Add(lblAl);
            bool isAlunoExpanded = false;

            pictureAluno.Click += (s, e) =>
            {
                if (!isAlunoExpanded)
                {
                    panelAluno.Size = new Size(300, 400);
                    panelAluno.AutoScroll = true;
                    pictureAluno.Visible = false;
                }

                isAlunoExpanded = !isAlunoExpanded;
            };

            panelAluno.Click += (s, e) =>
            {
                if (isAlunoExpanded)
                {
                    panelAluno.Size = new Size(80, 80);
                    panelAluno.AutoScroll = false;
                    pictureAluno.Visible = true;
                }

                isAlunoExpanded = !isAlunoExpanded;
            };


            label7.Location = new System.Drawing.Point(10, 10);
            label7.ForeColor = Color.White;
            txtIDEndAluno.Location = new System.Drawing.Point(10, 40);

            label1.Location = new System.Drawing.Point(10, 80);
            label1.ForeColor = Color.White;
            txtRua.Location = new System.Drawing.Point(10, 110);

            label2.Location = new System.Drawing.Point(10, 150);
            label2.ForeColor = Color.White;
            txtNum.Location = new System.Drawing.Point(10, 180);

            label3.Location = new System.Drawing.Point(10, 220);
            label3.ForeColor = Color.White;
            txtCep.Location = new System.Drawing.Point(10, 250);

            label4.Location = new System.Drawing.Point(10, 290);
            label4.ForeColor = Color.White;
            txtBairro.Location = new System.Drawing.Point(10, 320);

            label5.Location = new System.Drawing.Point(10, 360);
            label5.ForeColor = Color.White;
            txtCidade.Location = new System.Drawing.Point(10, 390);

            label6.Location = new System.Drawing.Point(10, 430);
            label6.ForeColor = Color.White;
            txtEstado.Location = new System.Drawing.Point(10, 460);

            btnSalvarEndAluno.Location = new System.Drawing.Point(10, 500);

            panelAluno.Controls.Add(label7);
            panelAluno.Controls.Add(txtIDEndAluno);
            panelAluno.Controls.Add(label1);
            panelAluno.Controls.Add(txtRua);
            panelAluno.Controls.Add(label3);
            panelAluno.Controls.Add(label2);
            panelAluno.Controls.Add(txtNum);
            panelAluno.Controls.Add(label3);
            panelAluno.Controls.Add(txtCep);
            panelAluno.Controls.Add(label4);
            panelAluno.Controls.Add(txtBairro);
            panelAluno.Controls.Add(label5);
            panelAluno.Controls.Add(txtCidade);
            panelAluno.Controls.Add(label6);
            panelAluno.Controls.Add(txtEstado);
            panelAluno.Controls.Add(btnSalvarEndAluno);
            //TERMINO EXPANSÃO








            ApplyStyles(panelAluno);


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


            btnSalvarEndAluno.FlatStyle = FlatStyle.Flat;

            button1 = new Button
            {
                Text = "Cadastro Aluno",
                Size = new Size(100, 50),
                Location = new System.Drawing.Point(this.ClientSize.Width - 250, this.ClientSize.Height - 60),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
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
                    textBox.ForeColor = Color.FromArgb(60, 60, 60);
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.FromArgb(60, 60,60 );
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

            btnSalvarEndAluno.FlatStyle = FlatStyle.Flat;

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


                CustomMessageBox.Show("Dados salvos com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
        