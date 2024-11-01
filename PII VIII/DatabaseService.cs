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
        private readonly string sqlConnectionString = "Server=DESKTOP-DIFT32I\\SQLEXPRESS;Database=EscolaCC;Integrated Security=True;";
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

        public async Task<List<string>> GetSchoolsFromNeo4j()
        {
            List<string> schoolAddresses = new List<string>();
            var session = neo4jDriver.AsyncSession();

            try
            {
                var result = await session.RunAsync("MATCH (e:EnderecoEscola) RETURN e.Rua AS EnderecoEscola");
                await result.ForEachAsync(record =>
                {
                    var endereco = record["EnderecoEscola"].As<string>();
                    Console.WriteLine($"Endereço: {endereco}");
                    schoolAddresses.Add(endereco);
                });
            }
            finally
            {
                await session.CloseAsync();
            }
            return schoolAddresses;
        }
    }
}
