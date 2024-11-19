using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class CadastroEscolaRec : Form
    {
        public CadastroEscolaRec()
        {

            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Cadastro de Escolas e Professores"; 
            ApplyFadeInTransition();
            ApplyStyles();
            AddHeader(); 
        }

        private void AddHeader()
        {
            Panel panelHeader = new Panel();
            panelHeader.Dock = DockStyle.Top;
            panelHeader.BackColor = Color.FromArgb(31, 31, 31);
            panelHeader.Height = 120;  

            Label lblTitle = new Label();
            lblTitle.Text = "Cadastro End Aluno"; 
            lblTitle.Font = new Font("Arial", 24, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            panelHeader.Controls.Add(lblTitle);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile("images/unifenas1.logo.png");  
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Width = 80;  
            pictureBox.Height = 80; 
            pictureBox.Location = new Point(10, 10);

            panelHeader.Controls.Add(pictureBox);

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
            string connectionString = @"Server=DESKTOP-R5PIHTR\SQLEXPRESS01;Database=EscolaCC;Integrated Security=True;";

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
            string connectionString = @"Server=DESKTOP-R5PIHTR\SQLEXPRESS01;Database=EscolaCC;Integrated Security=True;";

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

        private void button1_Click(object sender, EventArgs e)
        {
            EndEscola endEscola = new EndEscola();
            endEscola.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Similar ao cadastro de escola e recursos, o código para cadastro de professor
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
