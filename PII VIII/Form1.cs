using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neo4j.Driver;
using System.Drawing;
using System.IO;


namespace PII_VIII
{
    public partial class Form1 : Form
    {
        private string connectionString =
            @"Server=DESKTOP-DIFT32I\SQLEXPRESS;Database=EscolaCC;Integrated Security=True;";

        private bool isDragging = false;
        private System.Drawing.Point lastCursor;
        private System.Drawing.Point lastMenuStrip;
        private Label descricaoProjeto;
        private PictureBox logoPic;
        private Label titulos;

        

        //CABECALHO
        private Panel headerPanel;
        private Label titleLabel;
        private Button relatoriobtn, sobrebtn, contatobtn;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            ApplyHoverEffect(button7, button6, button5, button4, button3, button2, button1);

            CreateHeader();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);


            this.Opacity = 0;
            Timer timer = new Timer { Interval = 10 };
            timer.Tick += (s, ev) =>
            {
                if (this.Opacity < 1) this.Opacity += 0.010;
                else timer.Stop();
            };
            timer.Start();

            titulos = new Label
            {
                Text = "Sobre",
                Font = new Font("Poppins", 17),
                BackColor = Color.FromArgb(224, 224, 224),
                ForeColor = Color.Black,
                Size = new Size(80, 50),
                Location = new System.Drawing.Point(632, 140),
                AutoSize = false,
                TextAlign = ContentAlignment.TopCenter
            };
            this.Controls.Add(titulos);

            descricaoProjeto = new Label
            {
                
                Text = "Desigualdade Educacional refere-se às diferenças no acesso e na qualidade da educação que variam entre diferentes grupos de alunos.\r\nEssas diferenças podem ser causadas por fatores como o tipo de escola (pública ou privada), a quantidade e qualidade dos recursos disponíveis, e o nível de apoio que os alunos recebem. Esse fenômeno pode afetar\r\nsignificativamente o desempenho acadêmico e as oportunidades futuras dos alunos.",
                Font = new Font("Arial", 13),
                BackColor = Color.FromArgb(224, 224, 224),
                ForeColor = Color.Black,
                Size = new Size(1000, 100),
                Location = new System.Drawing.Point(280, 205),
                AutoSize = false,
                TextAlign = ContentAlignment.TopLeft
            };

            this.Controls.Add(descricaoProjeto);

            ConectarSqlServer();
            await ConectarNeo4jAsync();
            MessageBox.Show("Conexão com SQL Server e Neo4j realizada com sucesso!");
        }


        //CABEÇALHO DDO PROJETO
        private void CreateHeader()
        {
            
            headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 118,
                BackColor = Color.FromArgb(31, 31, 31)
            };
            this.Controls.Add(headerPanel);


            logoPic = new PictureBox
            {
                Image = Image.FromFile("images/unifenas1.logo.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(280, 80), 
                Location = new System.Drawing.Point(10, 10)
            };
            headerPanel.Controls.Add(logoPic);


            titleLabel = new Label
            {
                Text = "Gestão Escolar",
                Font = new Font("Arial", 24, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true
            };
            headerPanel.Controls.Add(titleLabel);

            relatoriobtn = CreateHeaderButton("Relatório");
            relatoriobtn.Click += new EventHandler(relatoriobtn_click);

            sobrebtn = CreateHeaderButton("Sobre");
            sobrebtn.Click += new EventHandler(sobrebtn_click);

            contatobtn = CreateHeaderButton("Contato");
            contatobtn.Click += new EventHandler(contatobtn_click);

            headerPanel.Controls.Add(relatoriobtn);
            headerPanel.Controls.Add(sobrebtn);
            headerPanel.Controls.Add(contatobtn);

            CenterHeaderElements();
        }

        private Button CreateHeaderButton(string text)
        {
            return new Button
            {
                Text = text,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Size = new Size(135, 45),
                BackColor = Color.White,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
        }

        private void CenterHeaderElements()
        {
            int formWidth = this.ClientSize.Width;

            int titleXOffset = 240;
            titleLabel.Location = new System.Drawing.Point((formWidth - titleLabel.Width) / 2 + titleXOffset, 10);


            int buttonY = 65;
            int spacing = 10;
            int totalButtonWidth = relatoriobtn.Width * 1 + spacing * 0;
            int startX = (formWidth - totalButtonWidth) / 2 + 100;

            relatoriobtn.Location = new System.Drawing.Point(startX, buttonY);
            sobrebtn.Location = new System.Drawing.Point(startX + relatoriobtn.Width + spacing, buttonY);
            contatobtn.Location = new System.Drawing.Point(startX + 2 * (relatoriobtn.Width + spacing), buttonY);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterHeaderElements();
        }






        //CORPO DO PROJETO









        //TRANSIÇÃO ENTRE OS FORMS
        private async Task MostrarComTransicaoAsync(Form form)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new System.Drawing.Point(this.Location.X + this.Width, this.Location.Y);
            form.BackColor = Color.FromArgb(224, 224, 224);
            form.Opacity = 0; // Defina a opacidade inicial para 0
            form.Show();

            // Gradualmente aumente a opacidade
            for (double i = 0; i <= 1; i += 0.02)
            {
                form.Opacity = i;
                await Task.Delay(10);
            }

            // Mova o formulário para a posição desejada
            for (int i = this.Location.X + this.Width; i >= this.Location.X; i -= 10)
            {
                form.Location = new System.Drawing.Point(i, form.Location.Y);
                await Task.Delay(1);
            }

        }



            //CONNECT COM SQL E NEO4J
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


        //CONEXÃO ENTRE OS FORMS


        private async void relatoriobtn_click(object sender, EventArgs e)
        {
            Relatórios rel = new Relatórios();
            await MostrarComTransicaoAsync(rel);
        }

        private async void sobrebtn_click(object sender, EventArgs e)
        {
            
        }
        private async void contatobtn_click(object sender, EventArgs e)
        {
            ;
        }

        private async void relatorio_click(object sender, EventArgs e)
        {
            Relatórios rel = new Relatórios();
            await MostrarComTransicaoAsync(rel);
        }



        private async void endereçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EndAluno endAluno = new EndAluno();
            await MostrarComTransicaoAsync(endAluno);

        }



        private async void endereçoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EndEscola endEscola = new EndEscola();
            await MostrarComTransicaoAsync(endEscola);

        }









        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.sidebarPanel.BackColor = Color.FromArgb(31, 31, 31, 12);
        }

        //Buttons
        private async void homeButton_click(object sender, EventArgs e)
        {
            Relatórios rel = new Relatórios();
            await MostrarComTransicaoAsync(rel);
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.FromArgb(31, 31, 31);
            infoAluno infoAluno = new infoAluno();
            await MostrarComTransicaoAsync(infoAluno);
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            this.button2.BackColor = Color.FromArgb(38, 50, 56, 22);
            infoEscola infoEscola = new infoEscola();
            await MostrarComTransicaoAsync(infoEscola);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            this.button3.BackColor = Color.FromArgb(38, 50, 56, 22);
            infoProfessores infoProf = new infoProfessores();
            await MostrarComTransicaoAsync(infoProf);
        }
        private async void button4_Click(object sender, EventArgs e)
        {
            this.button4.BackColor = Color.FromArgb(38, 50, 56, 22);
            infoDisciplinas infoDisciplinas = new infoDisciplinas();
            await MostrarComTransicaoAsync(infoDisciplinas);
        }
        private async void button5_Click(object sender, EventArgs e)
        {
            this.button5.BackColor = Color.FromArgb(38, 50, 56, 22);
            infoRecursosEdu infoRec = new infoRecursosEdu();
            await MostrarComTransicaoAsync(infoRec);
        }
        private async void button6_Click(object sender, EventArgs e)
        {
            this.button6.BackColor = Color.FromArgb(38, 50, 56, 22);
            infoDesempenhoAca infoDesem = new infoDesempenhoAca();
            await MostrarComTransicaoAsync(infoDesem);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();


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