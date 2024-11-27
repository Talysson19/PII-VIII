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


        private Button Sair;
        private Panel headerPanel;
        private PictureBox logoPic;
        private Label toggleLabel;

        public Relatórios()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            databaseService = new DatabaseService();
            Customize();
            ApplyHoverEffect();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 119,
                BackColor = Color.FromArgb(31, 31, 31)
            };

            logoPic = new PictureBox
            {
                Image = Image.FromFile("images/unifenas1.logo.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(280, 80),
                Location = new System.Drawing.Point(10, 10)
            };
            headerPanel.Controls.Add(logoPic);

            Sair = new Button
            {
                Text = "Sair",
                Size = new Size(10, 10),
                Dock = DockStyle.Right,
                Width = 100,
                BackColor = Color.FromArgb(31, 31, 31),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            Sair.FlatAppearance.BorderSize = 0;
            Sair.Click += new EventHandler(Sair_Click);


            Label titleLabel = new Label
            {
                Text = "Relatórios de Escolas",
                ForeColor = Color.White,
                Font = new Font("Arial", 20, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };






            this.Resize += (s, e) =>
            {
                headerPanel.Width = this.ClientSize.Width;
                
            };

            logoPic = new PictureBox
            {
                Image = Image.FromFile("images/unifenas1.logo.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(280, 80),
                Location = new System.Drawing.Point(10, 10)
            };
            headerPanel.Controls.Add(logoPic);

            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(Sair);
            this.Controls.Add(headerPanel);

            Panel bodyPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(31, 31, 31, 12)
            };
            this.Controls.Add(bodyPanel);


            dataGridView = new DataGridView
            {
                Size = new Size(350, 265),
                Location = new Point(450, 200),
                BackgroundColor = Color.White,
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AllowUserToResizeRows = false,
                AllowUserToResizeColumns = false,
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.White },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(200, 200, 200),
                    ForeColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Bold)
                },
                RowHeadersVisible = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dataGridView.CellClick += (s, e) => dataGridView.ClearSelection();

            bodyPanel.Controls.Add(dataGridView);
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 webP = new Form1();
            webP.ShowDialog();
        }

        private void ApplyHoverEffect(params Button[] buttons)
        {
            foreach (var btn in buttons)
            {
                btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(btn.BackColor = Color.DarkGray, 0.2f);
                btn.MouseLeave += (s, e) => btn.BackColor = ControlPaint.Dark(btn.BackColor = Color.DarkGray, 0.2f);
            }
        }

        private void Customize()
        {
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

            int posY = 20;
            int posX = 10;

            chkAlunos = CreateCheckBox("chkAlunos", "Alunos", posX, posY += 130);
            chkDesempenho = CreateCheckBox("chkDesempenho", "Desempenho Acadêmico", posX, posY += 30);
            chkDisciplinas = CreateCheckBox("chkDisciplinas", "Disciplinas", posX, posY += 30);
            chkEscola = CreateCheckBox("chkEscola", "Escola", posX, posY += 30);
            chkProfessores = CreateCheckBox("chkProfessores", "Professores", posX, posY += 30);
            chkRecursos = CreateCheckBox("chkRecursos", "Recursos Educacionais", posX, posY += 30);
            chkEnderecoEscola = CreateCheckBox("chkEnderecoEscola", "Endereço Escola (Neo4j)", posX, posY += 30);
            chkEnderecoAluno = CreateCheckBox("chkEnderecoAluno", "Endereço Aluno (Neo4j)", posX, posY += 30);

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
                ForeColor = Color.Black,
                BackColor = Color.FromArgb(200, 200, 200),
                Font = new Font("Arial", 10),
                AutoSize = true
            };

            checkBox.FlatStyle = FlatStyle.Flat;
            checkBox.FlatAppearance.BorderSize = 1;
            checkBox.FlatAppearance.BorderColor = Color.DarkGray;

            this.Controls.Add(checkBox);
            return checkBox;
        }

        private async void BtnProcessar_Click(object sender, EventArgs e)
        {
            DataTable combinedTable = new DataTable();
            combinedTable.Columns.Add("Fonte", typeof(string));
            combinedTable.Columns.Add("Dados", typeof(string));

            if (chkAlunos.Checked)
                AddTableToCombined(combinedTable, "Alunos", databaseService.GetAllStudents());
            if (chkDesempenho.Checked)
                AddTableToCombined(combinedTable, "Desempenho Acadêmico", databaseService.GetAllAcademicPerformance());
            if (chkDisciplinas.Checked)
                AddTableToCombined(combinedTable, "Disciplinas", databaseService.GetAllSubjects());
            if (chkEscola.Checked)
                AddTableToCombined(combinedTable, "Escola", databaseService.GetAllSchools());
            if (chkProfessores.Checked)
                AddTableToCombined(combinedTable, "Professores", databaseService.GetAllTeachers());
            if (chkRecursos.Checked)
                AddTableToCombined(combinedTable, "Recursos Educacionais", databaseService.GetAllEducationalResources());

            if (chkEnderecoEscola.Checked)
                await AddNeo4jDataToCombined(combinedTable, "Endereço Escola", await databaseService.GetAllSchoolAddresses());
            if (chkEnderecoAluno.Checked)
                await AddNeo4jDataToCombined(combinedTable, "Endereço Aluno", await databaseService.GetAllStudentAddresses());

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
