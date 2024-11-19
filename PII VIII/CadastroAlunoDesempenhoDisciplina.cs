using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class CadastroAlunoDesempenhoDisciplina : Form
    {
        private Button sairbtn;
        public CadastroAlunoDesempenhoDisciplina()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Cadastro de Aluno e Desempenho"; 
            ApplyFadeInTransition();
            ApplyStyles();
            InicializarBotaoSair();
            AddHeader();
        }

        private void AddHeader()
        {
            Panel panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(31, 31, 31),
                Height = 120
            };

            PictureBox pictureBox = new PictureBox
            {
                Image = Image.FromFile("images/unifenas1.logo.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(280, 80),
                Location = new Point(10, 20)
            };
            panelHeader.Controls.Add(pictureBox);

            Label lblTitle = new Label
            {
                Text = "Cadastro de Aluno e Desempenho",
                Font = new Font("Arial", 20, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true
            };
            lblTitle.Location = new Point(
                (panelHeader.Width - lblTitle.Width) / 2,
                (panelHeader.Height - lblTitle.Height) / 2
            );
            panelHeader.Controls.Add(lblTitle);

            this.Resize += (s, e) =>
            {
                lblTitle.Location = new Point(
                    (panelHeader.Width - lblTitle.Width) / 2,
                    (panelHeader.Height - lblTitle.Height) / 2
                );
            };

            

            this.Controls.Add(panelHeader);
        }

        private void InicializarBotaoSair()
        {
            sairbtn = new Button
            {
                Text = "Endereço Aluno",
                Size = new Size(100, 40),
                Location = new Point(this.ClientSize.Width - 120, this.ClientSize.Height - 60),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            sairbtn.FlatAppearance.BorderSize = 0;
            sairbtn.Click += (sender, e) => VoltarParaForm1();
            this.Controls.Add(sairbtn);
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

        private void ApplyStyles()
        {
            this.BackColor = Color.FromArgb(245, 245, 245); 

            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.FromArgb(31, 31, 31, 12);
                    button.ForeColor = Color.Black;
                    button.Font = new Font("Arial", 10, FontStyle.Bold);
                    button.FlatAppearance.BorderSize = 1; 
                    button.FlatAppearance.BorderColor = Color.Black; 
                    button.FlatAppearance.MouseOverBackColor = Color.AntiqueWhite;
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
        }

        private async Task MostrarComTransicaoAsync(CadastroAlunoDesempenhoDisciplina form)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new System.Drawing.Point(this.Location.X + this.Width, this.Location.Y);
            form.BackColor = Color.FromArgb(224, 224, 224);
            form.Opacity = 0;
            form.Show();

            for (double i = 0; i <= 1; i += 0.02)
            {
                form.Opacity = i;
                await Task.Delay(10);
            }

            for (int i = this.Location.X + this.Width; i >= this.Location.X; i -= 10)
            {
                form.Location = new System.Drawing.Point(i, form.Location.Y);
                await Task.Delay(1);
            }
        }

        private void CadastroAlunoDesempenhoDisciplina_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(224, 224, 224);
        }


        private void btnCadastrarEndA_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSalvarDisc_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
    
        }

        private void button3_Click(object sender, EventArgs e)
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
