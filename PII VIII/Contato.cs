using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class Contato : Form
    {
        private Button sairbtn;

        public Contato()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            InicializarFormulario();
            InicializarBotaoSair();

        }

        private void InicializarFormulario()
        {
            this.Text = "Contatos dos Desenvolvedores";
            this.BackColor = Color.FromArgb(240, 240, 240);

            List<Desenvolvedor> desenvolvedores = new List<Desenvolvedor>
            {
                new Desenvolvedor { Nome = "João Gabriel", Email = "28090420joaogabriel@aluno.unifenas.br", Telefone = "(35) 98419-6098", LinkedIn = "https://www.linkedin.com/in/joão-gabriel-do-vale-souza-a99687306/", GitHub = "https://github.com/joaogabriel343" },
                new Desenvolvedor { Nome = "Lucas Silva Santos", Email = "lucas@example.com", Telefone = "(11) 88888-8888", LinkedIn = "", GitHub = "https://github.com/camilasouza" },
                new Desenvolvedor { Nome = "Talysson Moura", Email = "talysson@example.com", Telefone = "(11) 99999-9999", LinkedIn = "", GitHub = "https://github.com/joaogabriel" },
                new Desenvolvedor { Nome = "Gabriel Pacheco", Email = "gabriel@example.com", Telefone = "(11) 88888-8888", LinkedIn = "", GitHub = "https://github.com/camilasouza" }

            };

            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            int groupBoxHeight = (int)(formHeight * 0.25);
            int topPosition = (int)(formHeight * 0.1);

            foreach (var dev in desenvolvedores)
            {
                GroupBox groupBox = CriarGroupBoxParaDesenvolvedor(dev, topPosition, formWidth, groupBoxHeight);
                this.Controls.Add(groupBox);
                topPosition += groupBoxHeight + (int)(formHeight * 0.05);
            }
        }
        private void InicializarBotaoSair()
        {
            sairbtn = new Button
            {
                Text = "Sair",
                Size = new Size(100, 40),
                Location = new Point(this.ClientSize.Width - 120, this.ClientSize.Height - 60), // posição no canto inferior direito
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BackColor = Color.LightGray,
                ForeColor = Color.Black
            };
            sairbtn.Click += (sender, e) => VoltarParaForm1();
            this.Controls.Add(sairbtn);
        }

        private void VoltarParaForm1()
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }


        private GroupBox CriarGroupBoxParaDesenvolvedor(Desenvolvedor dev, int topPosition, int formWidth, int groupBoxHeight)
        {
            GroupBox groupBox = new GroupBox
            {
                Text = dev.Nome,
                Size = new Size(formWidth - 10, groupBoxHeight),
                Location = new Point(20, topPosition),
                BackColor = Color.White
            };

            int labelWidth = (int)(formWidth * 0.1);
            int textBoxWidth = (int)(formWidth * 0.3);
            int buttonWidth = (int)(formWidth * 0.1);
            int controlHeight = (int)(groupBoxHeight * 0.2);

            Label labelEmail = new Label { Text = "E-mail:", Location = new Point(10, 25), Size = new Size(labelWidth, controlHeight) };
            TextBox textBoxEmail = new TextBox { Text = dev.Email, Location = new Point(20 + labelWidth, 20), Width = textBoxWidth, ReadOnly = true };
            Button btnCopiarEmail = new Button { Text = "Copiar", Location = new Point(30 + labelWidth + textBoxWidth, 20), Size = new Size(buttonWidth, controlHeight) };
            btnCopiarEmail.Click += (sender, e) => CopiarParaAreaDeTransferencia(dev.Email);

            Label labelTelefone = new Label { Text = "Telefone:", Location = new Point(10, 25 + controlHeight + 10), Size = new Size(labelWidth, controlHeight) };
            TextBox textBoxTelefone = new TextBox { Text = dev.Telefone, Location = new Point(20 + labelWidth, 25 + controlHeight + 10), Width = textBoxWidth, ReadOnly = true };

            Button btnLinkedIn = new Button { Text = "LinkedIn", Location = new Point(formWidth - buttonWidth * 2 - 40, 20), Size = new Size(buttonWidth, controlHeight) };
            btnLinkedIn.Click += (sender, e) => System.Diagnostics.Process.Start(dev.LinkedIn);

            Button btnGitHub = new Button { Text = "GitHub", Location = new Point(formWidth - buttonWidth - 20, 20), Size = new Size(buttonWidth, controlHeight) };
            btnGitHub.Click += (sender, e) => System.Diagnostics.Process.Start(dev.GitHub);

            groupBox.Controls.Add(labelEmail);
            groupBox.Controls.Add(textBoxEmail);
            groupBox.Controls.Add(btnCopiarEmail);
            groupBox.Controls.Add(labelTelefone);
            groupBox.Controls.Add(textBoxTelefone);
            groupBox.Controls.Add(btnLinkedIn);
            groupBox.Controls.Add(btnGitHub);

            return groupBox;
        }

        private void CopiarParaAreaDeTransferencia(string texto)
        {
            Clipboard.SetText(texto);
            MessageBox.Show("E-mail copiado para a área de transferência!", "Copiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
