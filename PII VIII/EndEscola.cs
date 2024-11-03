using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class EndEscola : Form
    {
        public EndEscola()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            ApplyFadeInTransition();
        }

        private void ApplyFadeInTransition()
        {
            this.Opacity = 0; // Define a opacidade inicial como 0
            Timer fadeInTimer = new Timer { Interval = 10 }; // Cria um timer para controle da opacidade
            fadeInTimer.Tick += (s, e) =>
            {
                if (this.Opacity < 1)
                {
                    this.Opacity += 0.04; // Aumenta a opacidade gradualmente
                }
                else
                {
                    fadeInTimer.Stop(); // Para o timer quando a opacidade atinge 1
                }
            };
            fadeInTimer.Start(); // Inicia o timer para começar o efeito
        }

        private void EndEscola_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }
    }
}
