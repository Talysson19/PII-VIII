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

            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.FromArgb(31, 31, 31, 12);
                    button.ForeColor = Color.Black;
                    button.Font = new Font("Arial", 10, FontStyle.Bold);
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = Color.Black; 
                    button.FlatAppearance.MouseOverBackColor = Color.AntiqueWhite;
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
            string connectionString = @"Server=DESKTOP-DIFT32I\SQLEXPRESS;Database=EscolaCC;Integrated Security=True;";

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
            string connectionString = @"Server=DESKTOP-DIFT32I\SQLEXPRESS;Database=EscolaCC;Integrated Security=True;";

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

