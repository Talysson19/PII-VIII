using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;


namespace PII_VIII
{
    public partial class CadastroAlunoDesempenhoDisciplina : Form
    {

        public CadastroAlunoDesempenhoDisciplina()
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
            this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }

        private void btnCadastrarEndA_Click(object sender, EventArgs e)
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
                    MessageBox.Show(rowsAffected > 0 ? "Aluno cadastrado com sucesso!" : "Erro ao cadastrar aluno.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao inserir dados: " + ex.Message);
                }
            }
        }

        private void btnSalvarDisc_Click(object sender, EventArgs e)
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
            EndAluno endAluno = new EndAluno();
            endAluno.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
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
                    MessageBox.Show(rowsAffected > 0 ? "Desempenho Acadêmico cadastrado com sucesso!" : "Erro ao cadastrar aluno.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao inserir dados: " + ex.Message);
                }
            }
        }
    }
}