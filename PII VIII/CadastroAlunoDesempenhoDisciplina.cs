using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class CadastroAlunoDesempenhoDisciplina : Form
    {
        public CadastroAlunoDesempenhoDisciplina()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Cadastro de Aluno e Desempenho"; 
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
            // Código para cadastrar aluno
        }

        private void btnSalvarDisc_Click(object sender, EventArgs e)
        {
            // Código para cadastrar disciplina
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EndAluno endAluno = new EndAluno();
            endAluno.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Código para cadastro de desempenho acadêmico
        }
    }
}
