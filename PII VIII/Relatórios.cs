using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class Relatórios : Form
    {
        private DatabaseService databaseService;
        private DataGridView dataGridView;
        private CheckBox chkAlunos, chkDesempenho, chkDisciplinas, chkEscola, chkProfessores, chkRecursos, chkEnderecoEscola, chkEnderecoAluno;
        private Button btnProcessar;

        public Relatórios()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            databaseService = new DatabaseService();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            // Adicionar DataGridView
            dataGridView = new DataGridView
            {
                Dock = DockStyle.Bottom,
                Height = this.ClientSize.Height / 2,
                BackgroundColor = Color.White,
                ForeColor = Color.Black,
                ReadOnly = true,
                AllowUserToAddRows = false
            };
            this.Controls.Add(dataGridView);

            // Adicionar Checkboxes
            int posY = 20;
            int posX = 10;

            chkAlunos = CreateCheckBox("chkAlunos", "Alunos", posX, posY);
            chkDesempenho = CreateCheckBox("chkDesempenho", "Desempenho Acadêmico", posX, posY += 30);
            chkDisciplinas = CreateCheckBox("chkDisciplinas", "Disciplinas", posX, posY += 30);
            chkEscola = CreateCheckBox("chkEscola", "Escola", posX, posY += 30);
            chkProfessores = CreateCheckBox("chkProfessores", "Professores", posX, posY += 30);
            chkRecursos = CreateCheckBox("chkRecursos", "Recursos Educacionais", posX, posY += 30);
            chkEnderecoEscola = CreateCheckBox("chkEnderecoEscola", "Endereço Escola (Neo4j)", posX, posY += 30);
            chkEnderecoAluno = CreateCheckBox("chkEnderecoAluno", "Endereço Aluno (Neo4j)", posX, posY += 30);

            // Adicionar Botão Processar
            btnProcessar = new Button
            {
                Text = "Processar Seleção",
                Location = new Point(10, posY += 40),
                Size = new Size(150, 30),
                BackColor = Color.FromArgb(31, 31, 31),
                ForeColor = Color.White
            };
            btnProcessar.Click += BtnProcessar_Click;
            this.Controls.Add(btnProcessar);
        }

        private CheckBox CreateCheckBox(string name, string text, int x, int y)
        {
            var checkBox = new CheckBox
            {
                Name = name,
                Text = text,
                Location = new Point(x, y),
                ForeColor = Color.Black
            };
            this.Controls.Add(checkBox);
            return checkBox;
        }

        private async void BtnProcessar_Click(object sender, EventArgs e)
        {
            DataTable combinedTable = new DataTable();
            combinedTable.Columns.Add("Fonte", typeof(string));
            combinedTable.Columns.Add("Dados", typeof(string));

            if (chkAlunos.Checked)
                AddTableToCombined(combinedTable, "Alunos", databaseService.GetSchoolsFromSQL());
            if (chkDesempenho.Checked)
                AddTableToCombined(combinedTable, "Desempenho Acadêmico", databaseService.GetSchoolsFromSQL()); 
            if (chkDisciplinas.Checked)
                AddTableToCombined(combinedTable, "Disciplinas", databaseService.GetSchoolsFromSQL()); 

            if (chkEnderecoEscola.Checked)
                await AddNeo4jDataToCombined(combinedTable, "Endereço Escola", await databaseService.GetSchoolAddressesFromNeo4j());

            dataGridView.DataSource = combinedTable;
        }

        private void AddTableToCombined(DataTable combinedTable, string source, DataTable data)
        {
            foreach (DataRow row in data.Rows)
            {
                combinedTable.Rows.Add(source, string.Join(", ", row.ItemArray));
            }
        }

        private async Task AddNeo4jDataToCombined(DataTable combinedTable, string source, Dictionary<int, string> data)
        {
            foreach (var item in data)
            {
                combinedTable.Rows.Add(source, $"{item.Key}: {item.Value}");
            }
        }
    }
}
