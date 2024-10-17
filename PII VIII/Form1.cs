using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neo4j.Driver;
using System.Data.SqlClient;
namespace PII_VIII
{
    public partial class Form1 : Form
    {
        private string connectionString =
           @"Server=DESKTOP-DIFT32I\SQLEXPRESS;Database=EscolaCC;User Id=ProjetoInovador2;Password=projetoinovador;";


        public Form1()
        {
            InitializeComponent();
        }


        private async void btnConnect_Click(object sender, EventArgs e)
        {
            // URI e credenciais do Neo4j
            var uri = "bolt://localhost:7687";  // Substitua pelo IP do servidor, se for remoto
            var user = "neo4j";  // Usuário padrão ou personalizado
            var password = "12345678";  // Sua senha do Neo4j

            // Criando o driver para conexão
            var driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
            var session = driver.AsyncSession();  // Inicia a sessão

            try
            {
                // Testa a conexão tentando abrir a sessão
                await session.ExecuteReadAsync(tx => tx.RunAsync("RETURN 1"));
                MessageBox.Show("Conexão estabelecida com sucesso!");
            }
            catch (Exception ex)
            {
                // Caso haja erro na conexão
                MessageBox.Show($"Erro na conexão: {ex.Message}");
            }
            finally
            {
                // Fechando a sessão e o driver
                await session.CloseAsync();
                await driver.CloseAsync();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Conexão com o banco de dados realizada com sucesso!");

                    string query = "SELECT COUNT(*) FROM Alunos";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int totalAlunos = (int)command.ExecuteScalar();
                        MessageBox.Show($"Total de alunos cadastrados: {totalAlunos}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }
        }
    }
}


