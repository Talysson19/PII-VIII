using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class CadastroEscolaRec : Form
    {
        private Button sairbtn;
        public CadastroEscolaRec()
        {

            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            ApplyFadeInTransition();
            InicializarBotaoSair();
            AddHeader();
            ApplyStyles();
            InitializeButton();
        }
        private void InitializeButton()
        {
            button1 = new Button
            {
                Text = "Endereço Escola",
                Size = new Size(100, 40),
                Location = new Point(this.ClientSize.Width - 250, this.ClientSize.Height - 60),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font("Arial", 9, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };

            this.Controls.Add(button1);

            button1.Click += Button1_Click;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            EndEscola endEscola = new EndEscola();
            endEscola.ShowDialog();
        }

        private void InicializarBotaoSair()
        {
            sairbtn = new Button
            {
                Text = "Voltar",
                Size = new Size(100, 40),
                Location = new Point(this.ClientSize.Width - 120, this.ClientSize.Height - 60),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            sairbtn.FlatAppearance.BorderSize = 0;
            sairbtn.Click += (sender, e) => VoltarParaForm1();
            this.Controls.Add(sairbtn);
        }

        private void VoltarParaForm1()
        {
            Timer fadeOutTimer = new Timer { Interval = 10 };
            fadeOutTimer.Tick += (s, ev) =>
            {
                if (this.Opacity > 0)
                {
                    this.Opacity -= 0.04;
                }
                else
                {
                    fadeOutTimer.Stop();
                    this.Close();
                }
            };
            fadeOutTimer.Start();
        }

        private void AddHeader()
        {

            //CRIANDO EXPANSÃO ESCOLA
            System.Windows.Forms.Label lblEs = new System.Windows.Forms.Label
            {
                Text = "Escolas",
                ForeColor = Color.Black,
                BackColor = Color.FromArgb(224, 224, 224),
                Font = new Font("Franklin Gothic", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(100, 200),
                Size = new Size(170, 60)
            };

            Panel paneleEscola = new Panel
            {
                Name = "panelAluno",
                Size = new Size(80, 80),
                BackColor = Color.Black,
                Location = new Point(150, 270),
            };

            PictureBox pictureEscola = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new Point(0, 0),
                Image = Image.FromFile("C:\\Users\\ogabr\\OneDrive\\Área de Trabalho\\PII-VIII-master\\PII-VIII-master\\PII VIII\\Resources\\escola.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.FromArgb(224, 224, 224)
            };

            paneleEscola.Controls.Add(pictureEscola);
            this.Controls.Add(paneleEscola);
            this.Controls.Add(lblEs);
            bool isAlunoExpanded = false;

            pictureEscola.Click += (s, e) =>
            {
                if (!isAlunoExpanded)
                {
                    paneleEscola.Size = new Size(300, 400);
                    paneleEscola.AutoScroll = true;
                    pictureEscola.Visible = false;
                }

                isAlunoExpanded = !isAlunoExpanded;
            };

            paneleEscola.Click += (s, e) =>
            {
                if (isAlunoExpanded)
                {
                    paneleEscola.Size = new Size(80, 80);
                    paneleEscola.AutoScroll = false;
                    pictureEscola.Visible = true;
                }

                isAlunoExpanded = !isAlunoExpanded;
            };


            //TERMINO EXPANSÃO ESCOLA









            //CRIANDO EXPANSÃO RECURSOS
            System.Windows.Forms.Label lblRe = new System.Windows.Forms.Label
            {
                Text = "Disciplina",
                ForeColor = Color.Black,
                BackColor = Color.FromArgb(224, 224, 224),
                Font = new Font("Franklin Gothic", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(510, 200),
                Size = new Size(170, 60)
            };

            Panel panelRecursos = new Panel
            {
                Name = "panelDisciplina",
                Size = new Size(80, 80),
                BackColor = Color.Black,
                Location = new Point(550, 270)
            };

            PictureBox pictureRecursos = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new Point(0, 0),
                Image = Image.FromFile("C:\\Users\\ogabr\\OneDrive\\Área de Trabalho\\PII-VIII-master\\PII-VIII-master\\PII VIII\\Resources\\recursos.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.FromArgb(224, 224, 224)
            };

            panelRecursos.Controls.Add(pictureRecursos);
            this.Controls.Add(lblRe);
            this.Controls.Add(panelRecursos);

            bool isExpanded = false;

            pictureRecursos.Click += (s, e) =>
            {
                if (!isExpanded)
                {
                    panelRecursos.Size = new Size(300, 400);
                    panelRecursos.AutoScroll = true;
                    pictureRecursos.Visible = false;
                }

                isExpanded = !isExpanded;
            };

            panelRecursos.Click += (s, e) =>
            {
                if (isExpanded)
                {
                    panelRecursos.Size = new Size(80, 80);
                    panelRecursos.AutoScroll = false;
                    pictureRecursos.Visible = true;
                }

                isExpanded = !isExpanded;
            };

            //TERMINO EXPANSÃO RECURSOS










            //CRIANDO EXPANSÃO PROFESSORES
            System.Windows.Forms.Label lblPr = new System.Windows.Forms.Label
            {
                Text = "Desempenhos",
                ForeColor = Color.Black,
                BackColor = Color.FromArgb(224, 224, 224),
                Font = new Font("Franklin Gothic", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(900, 200),
                Size = new Size(190, 60)
            };
            Panel panelProfessor = new Panel
            {
                Name = "panelDesempenho",
                Size = new Size(80, 80),
                BackColor = Color.Black,
                Location = new Point(950, 270)
            };

            PictureBox pictureProfessor = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new Point(0, 0),
                Image = Image.FromFile("C:\\Users\\ogabr\\OneDrive\\Área de Trabalho\\PII-VIII-master\\PII-VIII-master\\PII VIII\\Resources\\desempenho1.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.FromArgb(224, 224, 224)
            };

            bool isDesempenhoExpanded = false;

            panelProfessor.Controls.Add(pictureProfessor);
            this.Controls.Add(panelProfessor);
            this.Controls.Add(lblPr);

            pictureProfessor.Click += (s, e) =>
            {
                if (!isDesempenhoExpanded)
                {
                    panelProfessor.Size = new Size(300, 400);
                    panelProfessor.AutoScroll = true;
                    pictureProfessor.Visible = false;
                }

                isDesempenhoExpanded = !isDesempenhoExpanded;
            };

            panelProfessor.Click += (s, e) =>
            {
                if (isDesempenhoExpanded)
                {
                    panelProfessor.Size = new Size(80, 80);
                    panelProfessor.AutoScroll = false;
                    pictureProfessor.Visible = true;
                }

                isDesempenhoExpanded = !isDesempenhoExpanded;
            };


            //TERMINO EXPANSÃO PROFESSORES





            Panel panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(31, 31, 31),
                Height = 120
            };

            PictureBox pictureBox = new PictureBox
            {
                Image = Image.FromFile("images/unifenas1.logo.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(280, 80),
                Location = new Point(10, 20)
            };
            panelHeader.Controls.Add(pictureBox);

            Label lblTitle = new Label
            {
                Text = "Cadastro de Escolas e Professores",
                Font = new Font("Arial", 20, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true
            };
            lblTitle.Location = new Point(
                (panelHeader.Width - lblTitle.Width) / 2,
                (panelHeader.Height - lblTitle.Height) / 2
            );
            panelHeader.Controls.Add(lblTitle);

            this.Resize += (s, e) =>
            {
                lblTitle.Location = new Point(
                    (panelHeader.Width - lblTitle.Width) / 2,
                    (panelHeader.Height - lblTitle.Height) / 2
                );
            };

            this.Controls.Add(panelHeader);



        }


        private void ApplyFadeInTransition()
        {
            this.Opacity = 0;
            Timer fadeInTimer = new Timer { Interval = 10 };
            fadeInTimer.Tick += (s, e) =>
            {
                if (this.Opacity < 1)
                {
                    this.Opacity += 0.04;
                }
                else
                {
                    fadeInTimer.Stop();
                }
            };
            fadeInTimer.Start();
        }

        private void ApplyStyles()
        {
            this.BackColor = Color.FromArgb(245, 245, 245);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    lbl.ForeColor = Color.FromArgb(31, 31, 31);
                }
            }


            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ComboBox cmbBox)
                {
                    cmbBox.BackColor = Color.White;
                    cmbBox.FlatStyle = FlatStyle.Flat;
                    cmbBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    cmbBox.ForeColor = Color.Black;
                }
            }

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txtBox)
                {
                    txtBox.BorderStyle = BorderStyle.FixedSingle;
                    txtBox.BackColor = Color.FromArgb(245, 245, 245);
                    txtBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    txtBox.ForeColor = Color.Black;
                }
            }


            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.Black;
                    button.ForeColor = Color.White;
                    button.Font = new Font("Arial", 10, FontStyle.Bold);
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = Color.White;
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Font = new Font("Arial", 10);
                    textBox.BackColor = Color.WhiteSmoke;
                }
            }
            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {

                    label.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    label.ForeColor = Color.FromArgb(31, 31, 31);
                    label.BackColor = Color.Transparent;
                    label.TextAlign = ContentAlignment.MiddleLeft;

                }
            }

        }

        private void CadastroEscolaRec_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void btnCadastrosEscolas_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=GABRIEL\SQLEXPRESS09;Database=EscolaCC;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Conexão com o SQL Server bem-sucedida! Pronto para cadastrar o aluno.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar com o SQL Server: " + ex.Message);
                    return;
                }
            }

            string nome = txtNomeEscola.Text;
            int idEndEscola = int.Parse(txtEndEscola.Text);
            string Tipo = cmbTipoEscola.SelectedItem?.ToString();
            string nivelensino = cmbNivelEnsino.SelectedItem?.ToString();

            string query = "INSERT INTO Escola (Nome, IDEnderecoEscola, Tipo, NivelEnsino) " +
                           "VALUES (@Nome, @IDEnderecoEscola, @Tipo, @NivelEnsino)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@IDEnderecoEscola", idEndEscola);
                command.Parameters.AddWithValue("@Tipo", Tipo ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@NivelEnsino", nivelensino ?? (object)DBNull.Value);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "Escola cadastrada com sucesso!" : "Erro ao cadastrar escola.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao inserir dados: " + ex.Message);
                }
            }
        }

        private void btnCadastroRec_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=GABRIEL\SQLEXPRESS09;Database=EscolaCC;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Conexão com o SQL Server bem-sucedida! Pronto para cadastrar o recurso.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar com o SQL Server: " + ex.Message);
                    return;
                }
            }

            string tipoRec = txtTipoRec.Text;
            int idEscola = int.Parse(txtIDEscola.Text);
            int Qtd = int.Parse(txtQtd.Text);
            string estadoRec = cmbEstadoRec.SelectedItem?.ToString();

            string query = "INSERT INTO RecursosEducacionais (IDEscola, TipoRecurso, Quantidade, Estado) " +
                           "VALUES (@IDEscola, @TipoRecurso, @Quantidade, @Estado)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IDEscola", idEscola);
                command.Parameters.AddWithValue("@TipoRecurso", tipoRec);
                command.Parameters.AddWithValue("@Quantidade", Qtd);
                command.Parameters.AddWithValue("@Estado", estadoRec ?? (object)DBNull.Value);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "Recurso cadastrado com sucesso!" : "Erro ao cadastrar recurso.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao inserir dados: " + ex.Message);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=GABRIEL\SQLEXPRESS09;Database=EscolaCC;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Conexão com o SQL Server bem-sucedida! Pronto para cadastrar o aluno.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar com o SQL Server: " + ex.Message);
                    return;
                }
            }

            string nomeProf = txtNomeProf.Text;
            DateTime dataNascimentoProf = dtpDataNasciProf.Value;
            string generoProf = cmbGeneroProf.SelectedItem?.ToString();
            string nivelEdu = txtNivelEducaProf.Text;
            string especializacao = txtEspecializaçãoProf.Text;
            int idEscola = int.Parse(txtIDEscolaProf.Text);
            DateTime dataIngressoProf = dtpDataIngressoProf.Value;



            string query = "INSERT INTO Professores (Nome, DataNascimentoProf, Genero, NivelEducacao, Especializacao, IDEscola, DataIngresso) " +
                           "VALUES (@Nome, @DataNascimentoProf, @Genero, @NivelEducacao, @Especializacao, @IDEscola, @DataIngresso)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nome", nomeProf);
                command.Parameters.AddWithValue("@DataNascimentoProf", dataNascimentoProf);
                command.Parameters.AddWithValue("@Genero", generoProf ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@NivelEducacao", nivelEdu);
                command.Parameters.AddWithValue("@Especializacao", especializacao);
                command.Parameters.AddWithValue("@IDEscola", idEscola);
                command.Parameters.AddWithValue("@DataIngresso", dataIngressoProf);


                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "Professor cadastrado com sucesso!" : "Erro ao cadastrar aluno.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao inserir dados: " + ex.Message);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            EndEscola endEscola = new EndEscola();
            endEscola.ShowDialog();
        }



        private async void button2_Click_1(object sender, EventArgs e)
        {
            Timer fadeOutTimer = new Timer { Interval = 10 };
            fadeOutTimer.Tick += (s, ev) =>
            {
                if (this.Opacity > 0)
                {
                    this.Opacity -= 0.04;
                }
                else
                {
                    fadeOutTimer.Stop();
                    this.Close();
                }
            };
            fadeOutTimer.Start();
        }
    }
}

