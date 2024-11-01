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
    public partial class EndAluno : Form
    {
        private readonly string uri = "bolt://localhost:7687";
        private readonly string user = "neo4j";
        private readonly string password = "EscolaCC";

        public EndAluno()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }
        private void EndAluno_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(211, 211, 211);
            this.WindowState = FormWindowState.Normal;
        }

        private void btnSalvarEndA_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNomeEndA.Text;
                int numero = int.Parse(txtNumEndA.Text);
                string cep = txtCEPEndA.Text;
                string bairro = txtBairroEndA.Text;
                string cidade = txtCidadeEndA.Text;
                string estado = txtEstadoEndA.Text;

                var db = new Neo4jDatabase(uri, user, password);
                await db.SaveAddressAsync(nome, numero, cep, bairro, cidade, estado);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
