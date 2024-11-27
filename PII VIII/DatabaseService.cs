using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII_VIII
{
    public class DatabaseService
    {
        private readonly string sqlConnectionString = "Server=DESKTOP-DIFT32I\\SQLEXPRESS;Database=EscolaCC;Integrated Security=True;";
        private readonly IDriver neo4jDriver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "EscolaCC"));


        public DataTable GetAllStudents()
        {
            return ExecuteSQLQuery("SELECT * FROM Alunos");
        }

        public DataTable GetAllAcademicPerformance()
        {
            return ExecuteSQLQuery("SELECT * FROM DesempenhoAcademico");
        }

        public DataTable GetAllSubjects()
        {
            return ExecuteSQLQuery("SELECT * FROM Disciplinas");
        }

        public DataTable GetAllSchools()
        {
            return ExecuteSQLQuery("SELECT * FROM Escola");
        }

        public DataTable GetAllTeachers()
        {
            return ExecuteSQLQuery("SELECT * FROM Professores");
        }
        public DataTable GetAllEducationalResources()
        {
            return ExecuteSQLQuery("SELECT * FROM RecursosEducacionais");
        }

        private DataTable ExecuteSQLQuery(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    sqlConnection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }



        public async Task<Dictionary<int, string>> GetAllSchoolAddresses()
        {
            return await ExecuteNeo4jQuery("MATCH (e:enderecoEscola) RETURN e.idescola AS IDEscola, e.nome AS Nome, e.numero AS Numero, e.bairro AS Bairro, e.cidade AS Cidade, e.estado AS Estado, e.cep AS CEP");
        }
        public async Task<Dictionary<int, string>> GetAllStudentAddresses()
        {
            return await ExecuteNeo4jQuery("MATCH (a:EnderecoAluno) RETURN a.idEnderecoAluno AS EnderecoAluno, a.Rua AS Rua, a.Numero AS Numero, a.Bairro AS Bairro, a.Cidade AS Cidade, a.Estado AS Estado, a.CEP AS CEP");
        }

        private async Task<Dictionary<int, string>> ExecuteNeo4jQuery(string query)
        {
            var results = new Dictionary<int, string>();

            using (var session = neo4jDriver.AsyncSession())
            {
                var result = await session.RunAsync(query);

                while (await result.FetchAsync())
                {
                    string data = string.Join(", ", result.Current.Values.Values);
                    int id = result.Current.Values.Values.FirstOrDefault().As<int>();
                    results[id] = data;
                }
            }

            return results;
        }



    }
}
