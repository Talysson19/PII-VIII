using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PII_VIII
{
    public partial class CadastroEscolaRec : Form
    {

        //Select* From Professores; TERMINAR DE COLOCAR PARA CADASTRAR




        public CadastroEscolaRec()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            ApplyFadeInTransition();
        }

        private void ApplyFadeInTransition()
        {
            this.Opacity = 0; // Define a opacidade inicial como 0
            Timer fadeInTimer = new Timer { Interval = 10 }; // Cria um timer para controle da opacidade
            fadeInTimer.Tick += (s, e) =>
            {
                if (this.Opacity < 1)
                {
                    this.Opacity += 0.04; // Aumenta a opacidade gradualmente
                }
                else
                {
                    fadeInTimer.Stop(); // Para o timer quando a opacidade atinge 1
                }
            };
            fadeInTimer.Start(); // Inicia o timer para começar o efeito
        }

        private void CadastroEscolaRec_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }

        private void btnCadastrosEscolas_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=DESKTOP-DQNSI4G;Database=EscolaCC;Integrated Security=True;";

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
                    MessageBox.Show(rowsAffected > 0 ? "Escola cadastrado com sucesso!" : "Erro ao cadastrar aluno.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao inserir dados: " + ex.Message);
                }
            }
        }

        private void btnCadastroRec_Click(object sender, EventArgs e)
        {

            string connectionString = @"Server=DESKTOP-DQNSI4G;Database=EscolaCC;Integrated Security=True;";

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
                    MessageBox.Show(rowsAffected > 0 ? "Disciplina cadastrada com sucesso!" : "Erro ao cadastrar aluno.");
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
            string connectionString = @"Server=DESKTOP-DQNSI4G;Database=EscolaCC;Integrated Security=True;";

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
    }
}
