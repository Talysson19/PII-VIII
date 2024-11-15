using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PII_VIII
{
    public class DatabaseService
    {
        private readonly string sqlConnectionString = "Server=DESKTOP-R5PIHTR\\SQLEXPRESS01;Database=EscolaCC;Integrated Security=True;";
        private readonly IDriver neo4jDriver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "EscolaCC"));

        public DataTable GetSchoolsFromSQL()
        {
            DataTable schoolsTable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
            {
                string query = "SELECT IDEscola, Nome, IDEnderecoEscola, Tipo, NivelEnsino FROM Escola";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    sqlConnection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(schoolsTable);
                }
            }
            return schoolsTable;
        }

        public int GetStudentCountBySchoolSQL(int escolaId)
        {
            int studentCount = 0;
            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Alunos WHERE IdEscola = @escolaId";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@escolaId", escolaId);
                    sqlConnection.Open();
                    studentCount = (int)cmd.ExecuteScalar();
                }
            }
            return studentCount;
        }

        public async Task<Dictionary<int, string>> GetSchoolAddressesFromNeo4j()
        {
            var schoolAddresses = new Dictionary<int, string>();

            using (var session = neo4jDriver.AsyncSession())
            {
                var result = await session.RunAsync("MATCH (p:enderecoEscola) RETURN p.idescola AS IDEscola, p.nome AS Nome, p.numero AS Numero, p.bairro AS Bairro, p.cidade AS Cidade, p.estado AS Estado, p.cep AS CEP");

                while (await result.FetchAsync())
                {
                    int escolaId = result.Current["IDEscola"].As<int>();
                    string nome = result.Current["Nome"].As<string>();
                    string numero = result.Current["Numero"].As<string>();
                    string bairro = result.Current["Bairro"].As<string>();
                    string cidade = result.Current["Cidade"].As<string>();
                    string estado = result.Current["Estado"].As<string>();
                    string cep = result.Current["CEP"].As<string>();

                    string enderecoCompleto = $"{nome}, {numero}, {bairro}, {cidade} - {estado}, {cep}";

                    schoolAddresses[escolaId] = enderecoCompleto;
                }
            }

            return schoolAddresses;
        }
    }
}
