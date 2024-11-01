using System.Threading.Tasks;
using Neo4j.Driver;

namespace PII_VIII
{
    public class Neo4jDatabase
    {
        private readonly string uri;
        private readonly string user;
        private readonly string password;
        private IDriver _driver;

        public Neo4jDatabase(string uri, string user, string password)
        {
            this.uri = uri;
            this.user = user;
            this.password = password;
        }

        private async Task ConectarNeo4jAsync()
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
            var session = _driver.AsyncSession();
            try
            {
                await session.ExecuteReadAsync(tx => tx.RunAsync("RETURN 1"));
            }
            finally
            {
                await session.CloseAsync();
            }
        }

        public async Task SaveAddressAsync(string nome, int numero, string cep, string bairro, string cidade, string estado)
        {
            await ConectarNeo4jAsync();
            var session = _driver.AsyncSession();
            try
            {
                await session.ExecuteWriteAsync(async tx =>
                {
                    await tx.RunAsync("CREATE (e:Endereco {nome: $nome, numero: $numero, cep: $cep, bairro: $bairro, cidade: $cidade, estado: $estado})",
                        new { nome, numero, cep, bairro, cidade, estado });
                });
            }
            finally
            {
                await session.CloseAsync();
                await _driver.CloseAsync();
            }
        }
    }
}
