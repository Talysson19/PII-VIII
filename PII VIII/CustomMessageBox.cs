using System;
using System.Drawing;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string message, string title = "Mensagem")
        {
            InitializeComponent();

            this.Text = title;
            this.BackColor = Color.FromArgb(60, 60, 60);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(400, 200);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblMessage = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(lblMessage);

            Button btnOk = new Button
            {
                Text = "OK",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(60, 60, 60),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 40),
                Anchor = AnchorStyles.Bottom,
                Dock = DockStyle.Bottom
            };

            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            btnOk.Click += (sender, e) => this.Close();

            this.Controls.Add(btnOk);
        }

        public static void Show(string message, string title = "Mensagem")
        {
            using (CustomMessageBox msgBox = new CustomMessageBox(message, title))
            {
                msgBox.ShowDialog();
            }
        }
    }
}
