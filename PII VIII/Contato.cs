using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class Contato : Form
    {
        private Button sairbtn;
        private Panel headerPanel;
        private PictureBox logoPic;
        public Contato()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            InicializarCabecalho(); 
            InicializarBotaoSair();
            InicializarFormulario(); 
        }

        private void InicializarFormulario()
        {
            this.Text = "Contatos dos Desenvolvedores";
            this.BackColor = Color.FromArgb(240, 240, 240);

            List<Desenvolvedor> desenvolvedores = new List<Desenvolvedor>
            {
                new Desenvolvedor { Nome = "João Gabriel", Email = "28090420joaogabriel@gmail.com", Telefone = "(35) 98419-6098", LinkedIn = "https://www.linkedin.com/in/joão-gabriel-do-vale-souza-a99687306/", GitHub = "https://github.com/joaogabriel343" },
                new Desenvolvedor { Nome = "Lucas Silva Santos", Email = "lucassilvadossantos2005@gmail.com", Telefone = "(35) 98886-2172", LinkedIn = "https://www.linkedin.com/in/lucas-silva-dos-santos-31026726a/", GitHub = "https://github.com/lucas-s-santos" },
                new Desenvolvedor { Nome = "Talysson Moura", Email = "mouratalysson3@gmail.com", Telefone = "(35) 98822-4017", LinkedIn = "www.linkedin.com/in/talysson-moura-0231b5262", GitHub = "https://github.com/Talysson19" },
                new Desenvolvedor { Nome = "Gabriel Pacheco", Email = "gabriel@example.com", Telefone = "(11) 88888-8888", LinkedIn = "", GitHub = "https://github.com/camilasouza" }
            };

            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            int groupBoxHeight = (int)(formHeight * 0.25);
            int topPosition = headerPanel.Bottom + 20;

            foreach (var dev in desenvolvedores)
            {
                GroupBox groupBox = CriarGroupBoxParaDesenvolvedor(dev, topPosition, formWidth, groupBoxHeight);
                this.Controls.Add(groupBox);
                topPosition += groupBoxHeight + (int)(formHeight * 0.05);
            }
        }

        private void InicializarCabecalho()
        {
            headerPanel = new Panel
            {   
                Size = new Size(this.ClientSize.Width, 120),
                BackColor = Color.FromArgb(31, 31, 31),
                Dock = DockStyle.Top
            };

            logoPic = new PictureBox
            {
                Image = Image.FromFile("images/unifenas1.logo.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(280, 80),
                Location = new System.Drawing.Point(10, 10)
            };
            headerPanel.Controls.Add(logoPic);

            Label titulo = new Label
            {
                Text = "Contatos dos Desenvolvedores",
                ForeColor = Color.White,
                Font = new Font("Arial", 24, FontStyle.Bold),
                AutoSize = true,
                Location = new Point((headerPanel.Width - -80) / 2, 15), 
                TextAlign = ContentAlignment.MiddleCenter
            };

          

            headerPanel.Controls.Add(titulo);
            this.Controls.Add(headerPanel);
        }

        private void InicializarBotaoSair()
        {
            sairbtn = new Button
            {
                Text = "Voltar",
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

        private GroupBox CriarGroupBoxParaDesenvolvedor(Desenvolvedor dev, int topPosition, int formWidth, int groupBoxHeight)
        {
            GroupBox groupBox = new GroupBox
            {
                Text = dev.Nome,
                Size = new Size(formWidth - 0, groupBoxHeight),
                Location = new Point(20, topPosition),
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Arial", 8, FontStyle.Bold)
            };

            int labelWidth = (int)(formWidth * 0.1);
            int textBoxWidth = (int)(formWidth * 0.3);
            int buttonWidth = (int)(formWidth * 0.1);
            int controlHeight = (int)(groupBoxHeight * 0.2);

            Label labelEmail = new Label { Text = "E-mail:", Location = new Point(10, 25), Size = new Size(labelWidth, controlHeight), ForeColor = Color.Black };
            TextBox textBoxEmail = new TextBox { Text = dev.Email, Location = new Point(20 + labelWidth, 20), Width = textBoxWidth, ReadOnly = true };
            Button btnCopiarEmail = new Button { Text = "Copiar", Location = new Point(30 + labelWidth + textBoxWidth, 20), Size = new Size(buttonWidth, controlHeight) };
            btnCopiarEmail.Click += (sender, e) => CopiarParaAreaDeTransferencia(dev.Email);

            Label labelTelefone = new Label { Text = "Telefone:", Location = new Point(10, 25 + controlHeight + 10), Size = new Size(labelWidth, controlHeight), ForeColor = Color.Black };
            TextBox textBoxTelefone = new TextBox { Text = dev.Telefone, Location = new Point(20 + labelWidth, 25 + controlHeight + 10), Width = textBoxWidth, ReadOnly = true };

            Button btnLinkedIn = new Button { Text = "LinkedIn", Location = new Point(formWidth - buttonWidth * 2 - 40, 20), Size = new Size(buttonWidth, controlHeight) };
            btnLinkedIn.Click += (sender, e) => System.Diagnostics.Process.Start(dev.LinkedIn);

            Button btnGitHub = new Button { Text = "GitHub", Location = new Point(formWidth - buttonWidth - 20, 20), Size = new Size(buttonWidth, controlHeight) };
            btnGitHub.Click += (sender, e) => System.Diagnostics.Process.Start(dev.GitHub);

            EstilizarBotao(btnCopiarEmail);
            EstilizarBotao(btnLinkedIn);
            EstilizarBotao(btnGitHub);

            groupBox.Controls.Add(labelEmail);
            groupBox.Controls.Add(textBoxEmail);
            groupBox.Controls.Add(btnCopiarEmail);
            groupBox.Controls.Add(labelTelefone);
            groupBox.Controls.Add(textBoxTelefone);
            groupBox.Controls.Add(btnLinkedIn);
            groupBox.Controls.Add(btnGitHub);

            return groupBox;
        }

        private void EstilizarBotao(Button botao)
        {
            botao.BackColor = Color.FromArgb(31, 31, 31);
            botao.ForeColor = Color.White;
            botao.FlatStyle = FlatStyle.Flat;
            botao.FlatAppearance.BorderSize = 0;
            botao.Font = new Font("Arial", 8, FontStyle.Bold);
        }

        private void CopiarParaAreaDeTransferencia(string texto)
        {
            Clipboard.SetText(texto);
           // MessageBox.Show("E-mail copiado para a área de transferência!", "Copiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public class Desenvolvedor
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string LinkedIn { get; set; }
        public string GitHub { get; set; }
    }
}
