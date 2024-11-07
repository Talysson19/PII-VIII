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
        private Panel headerPanel;
        private PictureBox logoPic;
        private Label toggleLabel;
        private Panel sideBarPanel;

        private Timer sidebarTimer;
        private bool isSidebarVisible = false;
        private const int maxSidebarWidth = 350;
        private const int widthStep = 20;
        private const int opacityStep = 20;

        public Relatórios()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            databaseService = new DatabaseService();
            this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            CustomizeDesign();
            ApplyHoverEffect();


            sidebarTimer = new Timer { Interval = 20 };
            sidebarTimer.Tick += SidebarTimer_Tick;

            sideBarPanel.BackColor = Color.FromArgb(0, Color.Gray);

        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {

            if (isSidebarVisible)
            {
                if (sideBarPanel.Width < maxSidebarWidth)
                {
                    sideBarPanel.Width += widthStep;
                }

                int currentAlpha = sideBarPanel.BackColor.A + opacityStep;
                if (currentAlpha >= 255)
                {
                    sideBarPanel.BackColor = Color.FromArgb(255, Color.Gray);
                    sidebarTimer.Stop();
                }
                else
                {
                    sideBarPanel.BackColor = Color.FromArgb(currentAlpha, Color.Gray);
                }
            }
            else
            {
                if (sideBarPanel.Width > 0)
                {
                    sideBarPanel.Width -= widthStep;
                }

                int currentAlpha = sideBarPanel.BackColor.A - opacityStep;
                if (currentAlpha <= 0)
                {
                    sideBarPanel.BackColor = Color.FromArgb(0, Color.Gray);
                    sidebarTimer.Stop();
                }
                else
                {
                    sideBarPanel.BackColor = Color.FromArgb(currentAlpha, Color.Gray);
                }
            }

        }

        private async void Relatórios_Load(object sender, EventArgs e)
        {
            await LoadCombinedDataAsync();

        }

        private async Task LoadCombinedDataAsync()
        {
            DataTable schoolsTable = databaseService.GetSchoolsFromSQL();
            var schoolAddresses = await databaseService.GetSchoolAddressesFromNeo4j();

            DataTable combinedTable = new DataTable();
            combinedTable.Columns.Add("IDEscola", typeof(int));
            combinedTable.Columns.Add("Nome da Escola", typeof(string));
            combinedTable.Columns.Add("IDEndereco da Escola", typeof(int));
            combinedTable.Columns.Add("Tipo", typeof(string));
            combinedTable.Columns.Add("NivelEnsino", typeof(string));
            combinedTable.Columns.Add("Número de Alunos", typeof(int));
            combinedTable.Columns.Add("Endereço", typeof(string));

            foreach (DataRow row in schoolsTable.Rows)
            {
                int escolaId = Convert.ToInt32(row["IDEscola"]);
                string nomeEscola = row["Nome"].ToString();
                int enderecoEscolaId = Convert.ToInt32(row["IDEnderecoEscola"]);
                string tipo = row["Tipo"].ToString();
                string nivelEnsino = row["NivelEnsino"].ToString();
                int studentCount = databaseService.GetStudentCountBySchoolSQL(escolaId);

                string endereco = schoolAddresses.ContainsKey(enderecoEscolaId)
                    ? schoolAddresses[enderecoEscolaId]
                    : "Endereço não disponível";

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



            toggleLabel = new Label
            {
                Text = "≡",
                Font = new Font("Arial", 20, FontStyle.Bold),
                AutoSize = true,
                BackColor = Color.FromArgb(200,200,200),
                Location = new Point(5, headerPanel.Height + 5),
                ForeColor = Color.Black,
                Cursor = Cursors.Hand
            };
            toggleLabel.Click += ToggleLabel_Click;
            this.Controls.Add(toggleLabel);

            sideBarPanel = new BufferedPanel
            {
                Location = new Point(0, headerPanel.Height),
                Size = new Size(0, this.ClientSize.Height - headerPanel.Height),
                BackColor = Color.Gray
            };

            this.Resize += (s, e) =>
            {
                headerPanel.Width = this.ClientSize.Width;
                sideBarPanel.Height = this.ClientSize.Height - headerPanel.Height;
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
            this.Controls.Add(sideBarPanel);

            Panel bodyPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(31, 31, 31, 12)
            };
            this.Controls.Add(bodyPanel);


            dataGridView = new DataGridView
            {
                Size = new Size(720, 265),
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

        private void ToggleLabel_Click(object sender, EventArgs e)
        {
            isSidebarVisible = !isSidebarVisible;
            sidebarTimer.Start();

            if (isSidebarVisible)
            {
                sideBarPanel.Width = 0;
                sideBarPanel.BackColor = Color.FromArgb(0, Color.Gray);
                toggleLabel.BackColor = Color.FromArgb(127, 127, 127);
            }
            else
            {
                toggleLabel.BackColor = Color.FromArgb(200, 200, 200);
            }
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