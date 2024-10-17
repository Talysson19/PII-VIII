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

namespace PII_VIII
{
    public partial class Form1 : Form
    {
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



    }
}
    
