using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neo4j.Driver;

namespace PII_VIII
{
    public partial class Form1 : Form
    {
        private string connectionString =
            @"Server=DESKTOP-DIFT32I\SQLEXPRESS;Database=EscolaCC;Integrated Security=True;";

        private bool isDragging = false;
        private System.Drawing.Point lastCursor;
        private System.Drawing.Point lastMenuStrip;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            menuStrip1.BackColor = this.BackColor;

            SetMenuStripColor(menuStrip1);

            ConectarSqlServer();
            await ConectarNeo4jAsync();
            MessageBox.Show("Conexão com SQL Server e Neo4j realizada com sucesso!");
        }

        private void SetMenuStripColor(MenuStrip menuStrip)
        {
            foreach (ToolStripItem item in menuStrip.Items)
            {
                item.BackColor = this.BackColor; 
                SetSubItemColor(item);
            }
        }

        private void SetSubItemColor(ToolStripItem item)
        {
            if (item is ToolStripDropDownItem dropDownItem)
            {
                foreach (ToolStripItem subItem in dropDownItem.DropDownItems)
                {
                    subItem.BackColor = this.BackColor; // Cor de fundo dos subitens
                    SetSubItemColor(subItem); // Verifica se há subitens e aplica a cor
                }
            }
        }

        private void ConectarSqlServer()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
            }
        }

        private async Task ConectarNeo4jAsync()
        {
            var uri = "bolt://localhost:7687";
            var user = "neo4j";
            var password = "EscolaCC";

            var driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
            var session = driver.AsyncSession();

            try
            {
                await session.ExecuteReadAsync(tx => tx.RunAsync("RETURN 1"));
            }
            finally
            {
                await session.CloseAsync();
                await driver.CloseAsync();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_MouseEnter(object sender, EventArgs e)
        {
            // Quando o mouse entra no MenuStrip, manter a cor de fundo
            menuStrip1.BackColor = this.BackColor;
            SetMenuStripColor(menuStrip1);
        }

        private void menuStrip1_MouseLeave(object sender, EventArgs e)
        {
            // Ao sair do MenuStrip, manter a cor de fundo
            menuStrip1.BackColor = this.BackColor;
            SetMenuStripColor(menuStrip1);
        }

        private void informaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoAluno infoAluno = new infoAluno(); // Supondo que Form2 seja o segundo formulário
            infoAluno.ShowDialog();

        }

        private void endereçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EndAluno endAluno = new EndAluno();
            endAluno.ShowDialog();
        }

        private void informaçõesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            infoEscola infoEscola = new infoEscola();
            infoEscola.ShowDialog();
        }

        private void endereçoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EndEscola endEscola = new EndEscola();
            endEscola.ShowDialog();
        }

        private void informaçõesToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            infoProfessores infoProf  = new infoProfessores();
            infoProf.ShowDialog();
        }

        private void informaçõesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            infoDisciplinas infoDisciplinas = new infoDisciplinas();
            infoDisciplinas.ShowDialog();
        }

        private void informaçõesToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            infoRecursosEdu infoRec = new infoRecursosEdu();
            infoRec.ShowDialog();
        }

        private void informaçõesToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            infoDesempenhoAca infoDesem = new infoDesempenhoAca();
            infoDesem.ShowDialog();
        }

        private void relatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatórios rel = new Relatórios();
            rel.ShowDialog();
        }

       
    }
}
