using Neo4j.Driver;
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
                Size = new Size(100, 40),
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
                    textBox.BackColor
                    = Color.WhiteSmoke;
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

        private void EndEscola_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(211, 211, 211);
        }

        private async void btnSalvarEndAluno_Click(object sender, EventArgs e)
        {
            // Método de salvar endereço do aluno (sem alterações)
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
    }
}