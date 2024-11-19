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
                Text = "Cadastro End Aluno",
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
            this.Close();
        }
    }
}