using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neo4j.Driver;
using System.IO;
using System.Drawing.Imaging;


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
        private PictureBox escPubPic;
        private PictureBox escPartPic;

        private Button Sair;

        private PictureBox escPic;
        private Timer imageSwitchTimer;
        private bool isPublicImage = true;
        private Timer transitionTimer;
        private bool isFadingOut = true;
        private float opacity = 1.0f;



        private Panel headerPanel;
        private Label titleLabel;
        private Button relatoriobtn, sobrebtn, contatobtn;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            ApplyHoverEffect(button8,button7);
            SetupImageSwitcher();
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
                Font = new Font("MV Boli", 30),
                BackColor = Color.FromArgb(224, 224, 224),
                ForeColor = Color.Black,
                Size = new Size(200, 50),
                Location = new System.Drawing.Point(590, 450),
                AutoSize = false,
                TextAlign = ContentAlignment.TopCenter
            };
            this.Controls.Add(titulos);

            //descricaoProjeto = new Label
            //{

            //    Text = "A Desigualdade Educacional refere-se às disparidades no acesso e na qualidade da educação que ocorrem entre diferentes grupos de alunos. Essas diferenças são influenciadas por uma variedade de fatores, como o tipo de escola (pública ou privada), a infraestrutura disponível, o número e a qualificação dos professores, além da quantidade e da qualidade dos recursos oferecidos aos alunos.\r\n\r\nOutro aspecto relevante é o apoio familiar e comunitário, que pode variar de acordo com o contexto socioeconômico de cada estudante. Alunos de escolas públicas, especialmente em regiões mais vulneráveis, muitas vezes enfrentam limitações como a falta de material didático, instalações inadequadas e até dificuldade de acesso a atividades extracurriculares. Por outro lado, alunos de escolas particulares, em geral, contam com melhores estruturas, acesso a tecnologias e suporte individualizado.\r\n\r\nEssa desigualdade educacional pode impactar significativamente o desempenho acadêmico e as oportunidades futuras dos alunos, limitando o acesso ao ensino superior e a empregos qualificados. Portanto, enfrentar esse problema é fundamental para promover uma educação mais justa e inclusiva, onde todos os alunos tenham as mesmas condições para desenvolver seu potencial e contribuir para a sociedade.",
            //    Font = new Font("Arial", 10),
            //    BackColor = Color.FromArgb(224, 224, 224),
            //    ForeColor = Color.Black,
            //    Size = new Size(950, 300),
            //    Location = new System.Drawing.Point(310, 500),
            //    AutoSize = false,
            //    TextAlign = ContentAlignment.TopLeft
            //};

            //this.Controls.Add(descricaoProjeto);



            escPubPic = new PictureBox
            {
                Image = Image.FromFile(@"C:\Users\Pichau\OneDrive\Área de Trabalho\Documentos\Área de Trabalho\PII-VIII-master\PII-VIII\PII VIII\images\\escolapublica.jpg"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(400, 280),
                Location = new System.Drawing.Point(500, 150),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(escPubPic);
            DrawBorder(escPubPic, Color.Red, 5);



            escPartPic = new PictureBox
            {
                Image = Image.FromFile(@"C:\Users\Pichau\OneDrive\Área de Trabalho\Documentos\Área de Trabalho\PII-VIII-master\PII-VIII\PII VIII\images\\escolaparticular.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(400, 280),
                Location = new System.Drawing.Point(500, 150),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(escPartPic);



            ConectarSqlServer();
            await ConectarNeo4jAsync();
            //MessageBox.Show("Conexão com SQL Server e Neo4j realizada com sucesso!");
        }


        private void DrawBorder(PictureBox pictureBox, Color borderColor, int borderWidth)
        {
            pictureBox.Paint += (sender, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, pictureBox.ClientRectangle, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid);
            };
        }


        private void InitializeTimer()
        {
            transitionTimer = new Timer();
            transitionTimer.Interval = 50;
            transitionTimer.Tick += new EventHandler(TransitionTimer_Tick);
            transitionTimer.Start();
        }

        private void TransitionTimer_Tick(object sender, EventArgs e)
        {
            if (isFadingOut)
            {
                opacity -= 0.05f;
                if (opacity <= 0)
                {
                    opacity = 0;
                    isFadingOut = false;
                    if (escPubPic.Visible)
                    {
                        escPic.Visible = false;
                        escPic.Visible = true;
                    }
                    else
                    {
                        escPic.Visible = true;
                        escPic.Visible = false;
                    }
                }
            }
            else
            {
                opacity += 0.05f;
                if (opacity >= 1)
                {
                    opacity = 1;
                    isFadingOut = true;
                }
            }

            escPic.Image = SetImageOpacity(escPic.Image, opacity);
            escPic.Image = SetImageOpacity(escPic.Image, opacity);
            escPic.Invalidate();
            escPic.Invalidate();
        }
        private Image SetImageOpacity(Image image, float opacity)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }

        //alternando as imgs
        private void SetupImageSwitcher()
        {
            escPic = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(400, 280),
                Location = new System.Drawing.Point(500, 150)
            };
            this.Controls.Add(escPic);


            escPic.Image = Image.FromFile(@"C:\Users\Pichau\OneDrive\Área de Trabalho\Documentos\Área de Trabalho\PII-VIII-master\PII-VIII\PII VIII\images\\escolapublica.jpg");


            imageSwitchTimer = new Timer();
            imageSwitchTimer.Interval = 5000;
            imageSwitchTimer.Tick += new EventHandler(SwitchImage);
            imageSwitchTimer.Start();
            DrawBorder(escPic, Color.FromArgb(31, 31, 31), 5);
        }

        private void SwitchImage(object sender, EventArgs e)
        {
            if (isPublicImage)
            {
                escPic.Image = Image.FromFile(@"C:\Users\Pichau\OneDrive\Área de Trabalho\Documentos\Área de Trabalho\PII-VIII-master\PII-VIII\PII VIII\images\\escolaparticular.png");
            }
            else
            {
                escPic.Image = Image.FromFile(@"C:\Users\Pichau\OneDrive\Área de Trabalho\Documentos\Área de Trabalho\PII-VIII-master\PII-VIII\PII VIII\images\\escolapublica.jpg");
            }
            isPublicImage = !isPublicImage;
        }










        //CABEÇALHO DDO PROJETO
        private void CreateHeader()
        {
            Panel panelBackground = new Panel
            {
                Size = new Size(820, 290), 
                Location = new System.Drawing.Point(350, 500), 
                BackColor = Color.FromArgb(31, 31, 31),
                BorderStyle = BorderStyle.None 
            };
            this.Controls.Add(panelBackground);

            Label lblTexto = new Label
            {
                Text = "A Desigualdade Educacional refere-se às disparidades no acesso e na qualidade da educação que ocorrem entre diferentes grupos de alunos. Essas diferenças são influenciadas por uma variedade de fatores, como o tipo de escola (pública ou privada), a infraestrutura disponível, o número e a qualificação dos professores, além da quantidade e da qualidade dos recursos oferecidos aos alunos.\r\n\r\nOutro aspecto relevante é o apoio familiar e comunitário, que pode variar de acordo com o contexto socioeconômico de cada estudante. Alunos de escolas públicas, especialmente em regiões mais vulneráveis, muitas vezes enfrentam limitações como a falta de material didático, instalações inadequadas e até dificuldade de acesso a atividades extracurriculares. Por outro lado, alunos de escolas particulares, em geral, contam com melhores estruturas, acesso a tecnologias e suporte individualizado.\r\n\r\nEssa desigualdade educacional pode impactar significativamente o desempenho acadêmico e as oportunidades futuras dos alunos, limitando o acesso ao ensino superior e a empregos qualificados. Portanto, enfrentar esse problema é fundamental para promover uma educação mais justa e inclusiva, onde todos os alunos tenham as mesmas condições para desenvolver seu potencial e contribuir para a sociedade.",
                AutoSize = false,
                Size = new Size(800, 630), 
                Location = new System.Drawing.Point(10, 10),
                Font = new Font("MV Boli", 10),
                ForeColor = Color.FromArgb(224, 224, 224)

            };
            panelBackground.Controls.Add(lblTexto);



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

            Sair.Click += new EventHandler(Sair_Click);



            contatobtn = CreateHeaderButton("Contato");
            contatobtn.Click += new EventHandler(contatobtn_click);

            headerPanel.Controls.Add(relatoriobtn);
            headerPanel.Controls.Add(contatobtn);
            headerPanel.Controls.Add(Sair);
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
            int startX = (formWidth - totalButtonWidth) / 2 + 180;

            relatoriobtn.Location = new System.Drawing.Point(startX, buttonY );
            contatobtn.Location = new System.Drawing.Point(startX + (relatoriobtn.Width + spacing), buttonY);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterHeaderElements();
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private async void contatobtn_click(object sender, EventArgs e)
        {
             Contato contatoa = new Contato();
            await MostrarComTransicaoAsync(contatoa);
        }

        //CORPO DO PROJETO

        //TRANSIÇÃO ENTRE OS FORMS
        private async Task MostrarComTransicaoAsync(Form form)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new System.Drawing.Point(this.Location.X + this.Width, this.Location.Y);
            form.BackColor = Color.FromArgb(224, 224, 224);
            form.Opacity = 0;
            form.Show();


            for (double i = 0; i <= 1; i += 0.02)
            {
                form.Opacity = i;
                await Task.Delay(10);
            }

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

        private async void homeButton_click(object sender, EventArgs e)
        {
            Relatórios rel = new Relatórios();
            await MostrarComTransicaoAsync(rel);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            EndAluno endA = new EndAluno();
            endA.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CadastroEscolaRec cadA = new CadastroEscolaRec();
            cadA.ShowDialog();
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