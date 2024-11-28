using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;
using WinLabel = System.Windows.Forms.Label;

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
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
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
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
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
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(160, 200),
                Size = new Size(170, 60)
            };

            Panel paneleEscola = new Panel
            {
                Name = "paneleEscola",
                Size = new Size(80, 80),
                BackColor = Color.FromArgb(60, 60, 60),
                Location = new Point(150, 270),
            };

            PictureBox pictureEscola = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new Point(0, 0),
                Image = Image.FromFile("C:\\Users\\Pichau\\OneDrive\\Área de Trabalho\\Documentos\\Área de Trabalho\\PII-VIII-master\\PII-VIII\\PII VIII\\Resources\\escola.png"),
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
                Text = "Recursos",
                ForeColor = Color.Black,
                BackColor = Color.FromArgb(224, 224, 224),
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(555, 200),
                Size = new Size(250, 60)
            };

            Panel panelRecursos = new Panel
            {
                Name = "panelRecursos",
                Size = new Size(80, 80),
                BackColor = Color.FromArgb(60, 60, 60),
                Location = new Point(550, 270)
            };

            PictureBox pictureRecursos = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new Point(0, 0),
                Image = Image.FromFile("C:\\Users\\Pichau\\OneDrive\\Área de Trabalho\\Documentos\\Área de Trabalho\\PII-VIII-master\\PII-VIII\\PII VIII\\Resources\\recursos.png"),
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
                Text = "Professores",
                ForeColor = Color.FromArgb(60, 60, 60),
                BackColor = Color.FromArgb(224, 224, 224),
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(950, 200),
                Size = new Size(270, 60)
            };
            Panel panelProfessor = new Panel
            {
                Name = "panelProfessor",
                Size = new Size(80, 80),
                BackColor = Color.FromArgb(60, 60, 60),
                Location = new Point(950, 270)
            };

            PictureBox pictureProfessor = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new Point(0, 0),
                Image = Image.FromFile("C:\\Users\\Pichau\\OneDrive\\Área de Trabalho\\Documentos\\Área de Trabalho\\PII-VIII-master\\PII-VIII\\PII VIII\\Resources\\professor.png"),
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

            this.Controls.Add(paneleEscola);
            this.Controls.Add(panelRecursos);
            this.Controls.Add(panelProfessor);

            label1.Location = new Point(10, 10);
            label1.ForeColor = Color.White;
            txtNomeEscola.Location = new Point(10, 40);

            label10.Location = new Point(10, 80);
            label10.ForeColor = Color.White;
            txtEndEscola.Location = new Point(10, 110);

            label3.Location = new Point(10, 150);
            label3.ForeColor = Color.White;
            cmbTipoEscola.Location = new Point(10, 180);

            label4.Location = new Point(10, 220);
            label4.ForeColor = Color.White;
            cmbNivelEnsino.Location = new Point(10, 250);

            btnCadastrosEscolas.Location = new Point(10, 320);

            paneleEscola.Controls.Add(label1);
            paneleEscola.Controls.Add(txtNomeEscola);
            paneleEscola.Controls.Add(label10);
            paneleEscola.Controls.Add(label3);
            paneleEscola.Controls.Add(label4);
            paneleEscola.Controls.Add(txtEndEscola);
            paneleEscola.Controls.Add(cmbTipoEscola);
            paneleEscola.Controls.Add(cmbNivelEnsino);
            paneleEscola.Controls.Add(btnCadastrosEscolas);

            label7.Location = new Point(10, 10);
            label7.ForeColor = Color.White;
            txtTipoRec.Location = new Point(10, 40);

            label2.Location = new Point(10, 80);
            label2.ForeColor = Color.White;
            txtIDEscola.Location = new Point(10, 110);

            label6.Location = new Point(10, 150);
            label6.ForeColor = Color.White;
            txtQtd.Location = new Point(10, 180);

            label5.Location = new Point(10, 220);
            label5.ForeColor = Color.White;
            cmbEstadoRec.Location = new Point(10, 250);

            btnCadastroRec.Location = new Point(10, 320);

            panelRecursos.Controls.Add(label7);
            panelRecursos.Controls.Add(txtTipoRec);
            panelRecursos.Controls.Add(label2);
            panelRecursos.Controls.Add(txtIDEscola);
            panelRecursos.Controls.Add(label6);
            panelRecursos.Controls.Add(txtQtd);
            panelRecursos.Controls.Add(label5);
            panelRecursos.Controls.Add(cmbEstadoRec);
            panelRecursos.Controls.Add(btnCadastroRec);

            label12.Location = new Point(10, 10);
            label12.ForeColor = Color.White;
            txtNomeProf.Location = new Point(10, 40);

            label8.Location = new Point(10, 80);
            label8.ForeColor = Color.White;
            dtpDataNasciProf.Location = new Point(10, 110);

            label11.Location = new Point(10, 150);
            label11.ForeColor = Color.White;
            cmbGeneroProf.Location = new Point(10, 180);

            label9.Location = new Point(10, 220);
            label9.ForeColor = Color.White;
            txtNivelEducaProf.Location = new Point(10, 250);

            label13.Location = new Point(10, 290);
            label13.ForeColor = Color.White;
            txtEspecializaçãoProf.Location = new Point(10, 320);

            label15.Location = new Point(10, 360);
            label15.ForeColor = Color.White;
            txtIDEscolaProf.Location = new Point(10, 390);

            label14.Location = new Point(10, 430);
            label14.ForeColor = Color.White;
            dtpDataIngressoProf.Location = new Point(10, 460);

            btnCadastroProf.Location = new Point(10, 500);

            panelProfessor.Controls.Add(label12);
            panelProfessor.Controls.Add(txtNomeProf);
            panelProfessor.Controls.Add(label8);
            panelProfessor.Controls.Add(dtpDataNasciProf);
            panelProfessor.Controls.Add(label11);
            panelProfessor.Controls.Add(cmbGeneroProf);
            panelProfessor.Controls.Add(label9);
            panelProfessor.Controls.Add(txtNivelEducaProf);
            panelProfessor.Controls.Add(label13);
            panelProfessor.Controls.Add(txtEspecializaçãoProf);
            panelProfessor.Controls.Add(label15);
            panelProfessor.Controls.Add(txtIDEscolaProf);
            panelProfessor.Controls.Add(label14);
            panelProfessor.Controls.Add(dtpDataIngressoProf);
            panelProfessor.Controls.Add(btnCadastroProf);

            Panel panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(60, 60, 60),
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

            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label
            {
                Text = "Cadastro de Escolas e Professores",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
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
            btnCadastroProf.FlatStyle = FlatStyle.Flat;
            btnCadastroRec.FlatStyle = FlatStyle.Flat;
            btnCadastrosEscolas.FlatStyle = FlatStyle.Flat;

            btnCadastroProf.BackColor = Color.White;
            btnCadastroRec.BackColor = Color.White;
            btnCadastrosEscolas.BackColor = Color.White;


            this.BackColor = Color.FromArgb(245, 245, 245);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is System.Windows.Forms.Label lbl)
                {
                    lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    lbl.ForeColor = Color.FromArgb(60, 60, 60);
                }
            }


            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ComboBox cmbBox)
                {
                    cmbBox.BackColor = Color.White;
                    cmbBox.FlatStyle = FlatStyle.Flat;
                    cmbBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    cmbBox.ForeColor = Color.FromArgb(60, 60, 60);
                }
            }

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txtBox)
                {
                    txtBox.BorderStyle = BorderStyle.FixedSingle;
                    txtBox.BackColor = Color.FromArgb(245, 245, 245);
                    txtBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    txtBox.ForeColor = Color.FromArgb(60, 60, 60);
                }
            }


            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.FromArgb(60, 60, 60);
                    button.ForeColor = Color.White;
                    button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Font = new Font("Segoe UI", 10);
                    textBox.BackColor = Color.WhiteSmoke;
                }
            }
            foreach (Control control in this.Controls)
            {
                if (control is System.Windows.Forms.Label label)
                {

                    label.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    label.ForeColor = Color.FromArgb(60, 60, 60);
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
            string connectionString = @"Server=DESKTOP-DIFT32I\SQLEXPRESS;Database=EscolaCC;Integrated Security=True;";

           

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    CustomMessageBox.Show("Conexão com o SQL Server bem-sucedida! Pronto para cadastrar o aluno.");
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Erro ao conectar com o SQL Server: " + ex.Message);
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
                    CustomMessageBox.Show(rowsAffected > 0 ? "Escola cadastrada com sucesso!" : "Erro ao cadastrar escola.");
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Erro ao inserir dados: " + ex.Message);
                }
            }
        }

        private void btnCadastroRec_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=DESKTOP-DIFT32I\SQLEXPRESS;Database=EscolaCC;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    CustomMessageBox.Show("Conexão com o SQL Server bem-sucedida! Pronto para cadastrar o recurso.");
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Erro ao conectar com o SQL Server: " + ex.Message);
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
                    CustomMessageBox.Show(rowsAffected > 0 ? "Recurso cadastrado com sucesso!" : "Erro ao cadastrar recurso.");
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Erro ao inserir dados: " + ex.Message);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=DESKTOP-DIFT32I\SQLEXPRESS;Database=EscolaCC;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    CustomMessageBox.Show("Conexão com o SQL Server bem-sucedida! Pronto para cadastrar o aluno.");
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Erro ao conectar com o SQL Server: " + ex.Message);
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
                    CustomMessageBox.Show(rowsAffected > 0 ? "Professor cadastrado com sucesso!" : "Erro ao cadastrar aluno.");
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Erro ao inserir dados: " + ex.Message);
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

