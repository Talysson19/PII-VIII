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
    public partial class Relatórios : Form
    {
        public Relatórios()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void Relatórios_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }
    }
}
