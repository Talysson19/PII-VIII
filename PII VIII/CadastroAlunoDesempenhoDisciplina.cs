using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinLabel = System.Windows.Forms.Label;

namespace PII_VIII
{
    public partial class CadastroAlunoDesempenhoDisciplina : Form
    {
        private Button sairbtn;

        public CadastroAlunoDesempenhoDisciplina()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Cadastro de Aluno e Desempenho";
            ApplyFadeInTransition();
            ApplyStyles();
            InicializarBotaoSair();
            AddHeader();

        }


        private void AddHeader()
        {
            // INICIO EXPANSÃO E CONTRAÇÃO COM CLIQUE
            System.Windows.Forms.Label lblAl = new System.Windows.Forms.Label
            {
                Text = "Alunos",
                ForeColor = Color.Black,
                BackColor = Color.FromArgb(224, 224, 224),
                Font = new Font("Franklin Gothic", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(100, 200),
                Size = new Size(170, 60)
            };

            Panel panelAluno = new Panel
            {
                Name = "panelAluno",
                Size = new Size(80, 80),
                BackColor = Color.Black,
                Location = new Point(150, 270),
            };

            PictureBox pictureAluno = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new Point(0, 0),
                Image = Image.FromFile("C:\\Users\\Pichau\\OneDrive\\Área de Trabalho\\Documentos\\Área de Trabalho\\PII-VIII-master\\PII-VIII\\PII VIII\\Resources\\aluno.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.FromArgb(224, 224, 224)
            };

            panelAluno.Controls.Add(pictureAluno);
            this.Controls.Add(panelAluno);
            this.Controls.Add(lblAl);
            bool isAlunoExpanded = false;

            pictureAluno.Click += (s, e) =>
            {
                if (!isAlunoExpanded)
                {
                    panelAluno.Size = new Size(300, 400);
                    panelAluno.AutoScroll = true;
                    pictureAluno.Visible = false;
                }

                isAlunoExpanded = !isAlunoExpanded;
            };

            panelAluno.Click += (s, e) =>
            {
                if (isAlunoExpanded)
                {
                    panelAluno.Size = new Size(80, 80);
                    panelAluno.AutoScroll = false;
                    pictureAluno.Visible = true;
                }

                isAlunoExpanded = !isAlunoExpanded;
            };

            // FIM EXPANSÃO E CONTRAÇÃO COM CLIQUE








            //INICIO EXPANSÃO DISCIPLINA
            System.Windows.Forms.Label lblDc = new System.Windows.Forms.Label
            {
                Text = "Disciplina",
                ForeColor = Color.Black,
                BackColor = Color.FromArgb(224, 224, 224),
                Font = new Font("Franklin Gothic", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(510, 200),
                Size = new Size(170, 60)
            };

            Panel panelDisciplina = new Panel
            {
                Name = "panelDisciplina",
                Size = new Size(80, 80),
                BackColor = Color.Black,
                Location = new Point(550, 270)
            };

            PictureBox pictureDisciplina = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new Point(0, 0),
                Image = Image.FromFile("C:\\Users\\Pichau\\OneDrive\\Área de Trabalho\\Documentos\\Área de Trabalho\\PII-VIII-master\\PII-VIII\\PII VIII\\Resources\\livro.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.FromArgb(224, 224, 224)
            };

            panelDisciplina.Controls.Add(pictureDisciplina);
            this.Controls.Add(lblDc);
            this.Controls.Add(panelDisciplina);

            bool isExpanded = false;

            pictureDisciplina.Click += (s, e) =>
            {
                if (!isExpanded)
                {
                    panelDisciplina.Size = new Size(300, 400);
                    panelDisciplina.AutoScroll = true;
                    pictureDisciplina.Visible = false;
                }

                isExpanded = !isExpanded;
            };

            panelDisciplina.Click += (s, e) =>
            {
                if (isExpanded)
                {
                    panelDisciplina.Size = new Size(80, 80);
                    panelDisciplina.AutoScroll = false;
                    pictureDisciplina.Visible = true;
                }

                isExpanded = !isExpanded;
            };

            //FIM EXPANSÃO E CONTRAÇÃO DISCIPLINA



            // INICIO EXPANSÃO DESEMPENH
            System.Windows.Forms.Label lblDs = new System.Windows.Forms.Label
            {
                Text = "Desempenhos",
                ForeColor = Color.Black,
                BackColor = Color.FromArgb(224, 224, 224),
                Font = new Font("Franklin Gothic", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(900, 200),
                Size = new Size(190, 60)
            };
            Panel panelDesempenho = new Panel
            {
                Name = "panelDesempenho",
                Size = new Size(80, 80),
                BackColor = Color.Black,
                Location = new Point(950, 270)
            };

            PictureBox pictureDesempenho = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new Point(0, 0),
                Image = Image.FromFile("C:\\Users\\Pichau\\OneDrive\\Área de Trabalho\\Documentos\\Área de Trabalho\\PII-VIII-master\\PII-VIII\\PII VIII\\Resources\\desempenho1.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.FromArgb(224, 224, 224)
            };

            bool isDesempenhoExpanded = false;

            panelDesempenho.Controls.Add(pictureDesempenho);
            this.Controls.Add(panelDesempenho);
            this.Controls.Add(lblDs);

            pictureDesempenho.Click += (s, e) =>
            {
                if (!isDesempenhoExpanded)
                {
                    panelDesempenho.Size = new Size(300, 400);
                    panelDesempenho.AutoScroll = true;
                    pictureDesempenho.Visible = false;
                }

                isDesempenhoExpanded = !isDesempenhoExpanded;
            };

            panelDesempenho.Click += (s, e) =>
            {
                if (isDesempenhoExpanded)
                {
                    panelDesempenho.Size = new Size(80, 80);
                    panelDesempenho.AutoScroll = false;
                    pictureDesempenho.Visible = true;
                }

                isDesempenhoExpanded = !isDesempenhoExpanded;
            };
            // FIM EXPANSÃO E CONTRAÇÃO DESEMPENHO


            this.Controls.Add(panelAluno);
            this.Controls.Add(panelDisciplina);
            this.Controls.Add(panelDesempenho);

            //ADD PANEL ALUNO
            label1.Location = new Point(10, 10);
            label1.ForeColor = Color.White;
            txtNome.Location = new Point(10, 40);

            label2.Location = new Point(10, 80);
            label2.ForeColor = Color.White;
            dtpDataNascimento.Location = new Point(10, 110);

            label3.Location = new Point(10, 150);
            label3.ForeColor = Color.White;
            cmbGenero.Location = new Point(10, 180);

            label4.Location = new Point(10, 220);
            label4.ForeColor = Color.White;
            cmbRaca.Location = new Point(10, 250);

            label9.Location = new Point(10, 290);
            label9.ForeColor = Color.White;
            txtIDEscola.Location = new Point(10, 320);

            label5.Location = new Point(10, 360);
            label5.ForeColor = Color.White;
            cmbClasseSocial.Location = new Point(10, 390);

            label6.Location = new Point(10, 430);
            label6.ForeColor = Color.White;
            txtPcd.Location = new Point(10, 460);

            label7.Location = new Point(10, 500);
            label7.ForeColor = Color.White;
            txtBolsa.Location = new Point(10, 530);

            label10.Location = new Point(10, 570);
            label10.ForeColor = Color.White;
            txtEndAluno.Location = new Point(10, 600);

            label8.Location = new Point(10, 640);
            label8.ForeColor = Color.White;
            txtAbandono.Location = new Point(10, 670);

            btnCadastrarEndA.Location = new Point(10, 700);

            panelAluno.Controls.Add(label1);
            panelAluno.Controls.Add(txtNome);
            panelAluno.Controls.Add(label2);
            panelAluno.Controls.Add(dtpDataNascimento);
            panelAluno.Controls.Add(label3);
            panelAluno.Controls.Add(cmbGenero);
            panelAluno.Controls.Add(label4);
            panelAluno.Controls.Add(cmbRaca);
            panelAluno.Controls.Add(label9);
            panelAluno.Controls.Add(txtIDEscola);
            panelAluno.Controls.Add(label5);
            panelAluno.Controls.Add(cmbClasseSocial);
            panelAluno.Controls.Add(label6);
            panelAluno.Controls.Add(txtPcd);
            panelAluno.Controls.Add(label7);
            panelAluno.Controls.Add(txtBolsa);
            panelAluno.Controls.Add(label10);
            panelAluno.Controls.Add(txtEndAluno);
            panelAluno.Controls.Add(label8);
            panelAluno.Controls.Add(txtAbandono);
            panelAluno.Controls.Add(btnCadastrarEndA);
            //ADD PANEL DISCIPLINA
            lblNome.Location = new Point(10, 10);
            lblNome.ForeColor = Color.White;
            txtDisciplina.Location = new Point(10, 40);

            btnSalvarDisc.Location = new Point(10, 70);

            panelDisciplina.Controls.Add(lblNome);
            panelDisciplina.Controls.Add(txtDisciplina);
            panelDisciplina.Controls.Add(btnSalvarDisc);
            //TERMINO EXPANSÃO

            //ADD PANEL DESEMPENHO
            label11.Location = new Point(10, 10);
            label11.ForeColor = Color.White;
            txtNota.Location = new Point(10, 40);

            label14.Location = new Point(10, 80);
            label14.ForeColor = Color.White;
            txtIDAluno.Location = new Point(10, 110);

            label13.Location = new Point(10, 150);
            label13.ForeColor = Color.White;
            txtIDDisciplina.Location = new Point(10, 180);

            button2.Location = new Point(10, 220);
            panelDesempenho.Controls.Add(label11);
            panelDesempenho.Controls.Add(txtNota);
            panelDesempenho.Controls.Add(label14);
            panelDesempenho.Controls.Add(txtIDAluno);
            panelDesempenho.Controls.Add(txtIDDisciplina);
            panelDesempenho.Controls.Add(button2);
            panelDesempenho.Controls.Add(label13);

            //TERMINO EXPANSÃO 

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

            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label
            {
                Text = "Cadastro de Aluno e Desempenho",
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


        private void PanelAluno_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.Size = new Size(300, 300);
            panel.BringToFront();
        }

        private void PanelAluno_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.Size = new Size(50, 50);
        }

        private void PanelDisciplina_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.Size = new Size(300, 300);
            panel.BringToFront();
        }

        private void PanelDisciplina_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.Size = new Size(50, 50);
        }

        private void PanelDesempenho_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.Size = new Size(300, 300);
            panel.BringToFront();
        }

        private void PanelDesempenho_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.Size = new Size(50, 50);
        }



        private void InicializarBotaoSair()
        {
            sairbtn = new Button
            {
                Text = "Endereço Aluno",
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
                if (ctrl is System.Windows.Forms.Label lbl)
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
                    button.BackColor = Color.White;
                    button.ForeColor = Color.Black;
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
                if (control is System.Windows.Forms.Label label)
                {
                    label.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    label.ForeColor = Color.FromArgb(31, 31, 31);
                    label.BackColor = Color.Transparent;
                    label.TextAlign = ContentAlignment.MiddleLeft;
                }
            }
        }


        private async Task MostrarComTransicaoAsync(CadastroAlunoDesempenhoDisciplina form)
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

        private void CadastroAlunoDesempenhoDisciplina_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(224, 224, 224);
        }



        private void button1_Click(object sender, EventArgs e)
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







        private void button3_Click(object sender, EventArgs e)
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

        private void btnCadastrarEndA_Click_1(object sender, EventArgs e)
        {
            string connectionString = @"Server=DESKTOP-DIFT32I\SQLEXPRESS;Database=EscolaCC;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // CustomMessageBox.Show("Conexão com o SQL Server bem-sucedida! Pronto para cadastrar o aluno.");
                }
                catch (Exception ex)
                {
                    //CustomMessageBox.Show("Erro ao conectar com o SQL Server: " + ex.Message);
                    return;
                }
            }

            string nome = txtNome.Text;
            DateTime dataNascimento = dtpDataNascimento.Value;
            string genero = cmbGenero.SelectedItem?.ToString();
            string racaEtnia = cmbRaca.SelectedItem?.ToString();
            int idEscola = int.Parse(txtIDEscola.Text);
            string classeSocial = cmbClasseSocial.SelectedItem?.ToString();
            string alunoEspecial = txtPcd.Text == "Sim" ? "Sim" : "Não";
            string bolsa = txtBolsa.Text.Trim().Equals("Sim", StringComparison.OrdinalIgnoreCase) ? "Sim" : "Não";
            int idEnderecoAluno = int.Parse(txtEndAluno.Text);
            string abandono = txtAbandono.Text.Trim().Equals("Sim", StringComparison.OrdinalIgnoreCase) ? "Sim" : "Não";

            string query = "INSERT INTO Alunos (Nome, DataNascimento, Genero, RacaEtnia, ClasseSocial, AlunoEspecial, Bolsa, IDEnderecoAluno, Abandono, IDEscola) " +
                           "VALUES (@Nome, @DataNascimento, @Genero, @RacaEtnia, @ClasseSocial, @AlunoEspecial, @Bolsa, @IDEnderecoAluno, @Abandono, @IDEscola)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@DataNascimento", dataNascimento);
                command.Parameters.AddWithValue("@Genero", genero ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@RacaEtnia", racaEtnia ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@ClasseSocial", classeSocial ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@AlunoEspecial", alunoEspecial);
                command.Parameters.AddWithValue("@Bolsa", bolsa);
                command.Parameters.AddWithValue("@IDEnderecoAluno", idEnderecoAluno);
                command.Parameters.AddWithValue("@Abandono", abandono);
                command.Parameters.AddWithValue("@IDEscola", idEscola);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    CustomMessageBox.Show(rowsAffected > 0 ? "Aluno cadastrado com sucesso!" : "Erro ao cadastrar aluno.");
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Erro ao inserir dados: " + ex.Message);
                }
            }
        }

        private void btnSalvarDisc_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=DESKTOP-DIFT32I\SQLEXPRESS;Database=EscolaCC;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //  CustomMessageBox.Show("Conexão com o SQL Server bem-sucedida! Pronto para cadastrar o aluno.");
                }
                catch (Exception ex)
                {
                    // CustomMessageBox.Show("Erro ao conectar com o SQL Server: " + ex.Message);
                    return;
                }
            }

            string nomeDis = txtDisciplina.Text;



            string query = "INSERT INTO Disciplinas (Nome) " +
                           "VALUES (@Nome)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nome", nomeDis);


                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    CustomMessageBox.Show(rowsAffected > 0 ? "Disciplina cadastrada com sucesso!" : "Erro ao cadastrar aluno.");
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
                    // CustomMessageBox.Show("Conexão com o SQL Server bem-sucedida! Pronto para cadastrar o aluno.");
                }
                catch (Exception ex)
                {
                    // CustomMessageBox.Show("Erro ao conectar com o SQL Server: " + ex.Message);
                    // CustomMessageBox.Show("Erro ao conectar com o SQL Server: " + ex.Message);
                    return;
                }
            }

            int idAluno = int.Parse(txtIDAluno.Text);
            int idDisciplina = int.Parse(txtIDDisciplina.Text);
            float notaMedia = float.Parse(txtNota.Text);

            string query = "INSERT INTO DesempenhoAcademico (IDAluno, IDDisciplina, NotaMedia) " +
                           "VALUES (@IDAluno, @IDDisciplina, @NotaMedia)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IDAluno", idAluno);
                command.Parameters.AddWithValue("@IDDisciplina", idDisciplina);
                command.Parameters.AddWithValue("@NotaMedia", notaMedia);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    CustomMessageBox.Show(rowsAffected > 0 ? "Desempenho Acadêmico cadastrado com sucesso!" : "Erro ao cadastrar aluno.");
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Erro ao inserir dados: " + ex.Message);
                }
            }
        }
    }
}