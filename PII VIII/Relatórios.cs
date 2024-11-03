using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class Relatórios : Form
    {
        private DatabaseService databaseService;
        private Button Sair;
        private DataGridView dataGridView;
        
        

        public Relatórios()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            databaseService = new DatabaseService(); 
            this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            CustomizeDesign();
            ApplyHoverEffect();
        }

        private async void Relatórios_Load(object sender, EventArgs e)
        {
            await LoadCombinedDataAsync();
            this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);

        }
        
        private async Task LoadCombinedDataAsync()
        {
            DataTable schoolsTable = databaseService.GetSchoolsFromSQL();
            var schoolAddresses = await databaseService.GetSchoolsFromNeo4j();

            DataTable combinedTable = new DataTable();
            combinedTable.Columns.Add("IDEscola", typeof(int));
            combinedTable.Columns.Add("Nome da Escola", typeof(string));
            combinedTable.Columns.Add("IDEndereco da Escola", typeof(int));
            combinedTable.Columns.Add("Tipo", typeof(string));
            combinedTable.Columns.Add("NivelEnsino", typeof(string));
            combinedTable.Columns.Add("Número de Alunos", typeof(int));
            combinedTable.Columns.Add("Endereço", typeof(string));

            for (int i = 0; i < schoolsTable.Rows.Count; i++)
            {
                DataRow row = schoolsTable.Rows[i];
                int escolaId = Convert.ToInt32(row["IDEscola"]);
                string nomeEscola = row["Nome"].ToString();
                int enderecoEscolaId = Convert.ToInt32(row["IDEnderecoEscola"]);
                string tipo = row["Tipo"].ToString();
                string nivelEnsino = row["NivelEnsino"].ToString();
                int studentCount = databaseService.GetStudentCountBySchoolSQL(escolaId);

                string endereco = schoolAddresses.Count > i ? schoolAddresses[i] : "Endereço não disponível";

                combinedTable.Rows.Add(escolaId, nomeEscola, enderecoEscolaId, tipo, nivelEnsino, studentCount, endereco);
            }

            dataGridView.DataSource = combinedTable;
        }

        
       

        private void CustomizeDesign()
        {
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 119,
                BackColor = Color.FromArgb(31, 31, 31)
            };

            Panel sideBarPanel = new Panel
            {
                Dock = DockStyle.Left,
                Height = 20,
                BackColor = Color.FromArgb(31, 31, 31)
            };


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

            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(Sair);
            this.Controls.Add(headerPanel);
            this.Controls.Add(sideBarPanel);

            Panel bodyPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(31, 31, 31, 12)
            };
            this.Controls.Add(bodyPanel);

          
            dataGridView = new DataGridView
            {
                Size = new Size(705, 255),
                Location = new Point(350, 200), 
                BackgroundColor = Color.White,
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AllowUserToResizeRows = false,
                AllowUserToResizeColumns = false,
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(240, 240, 240) },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(31, 31, 31),
                    ForeColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Bold)
                },
                RowHeadersVisible = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
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

        
    }
}
