using Neo4j.Driver;
using System;
using System.Threading.Tasks;

namespace PII_VIII
{
    public class Neo4jConnection : IDisposable
    {
        private readonly IDriver _driver;

        public Neo4jConnection(string uri, string username, string password)
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(username, password));
        }

        // Método para criar uma sessão de escrita
        public async Task ExecuteWriteAsync(Func<IAsyncQueryRunner, Task> writeAction)
        {
            using (var session = _driver.AsyncSession())
            {
                await session.ExecuteWriteAsync(writeAction);
            }
        }

        // Método para criar uma sessão de leitura (caso precise no futuro)
        public async Task ExecuteReadAsync(Func<IAsyncQueryRunner, Task> readAction)
        {
            using (var session = _driver.AsyncSession())
            {
                await session.ExecuteReadAsync(readAction);
            }
        }

        // Método para liberar recursos
        public void Dispose()
        {
            _driver?.Dispose();
        }
    }
}
