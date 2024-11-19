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

        public async Task ExecuteWriteAsync(Func<IAsyncQueryRunner, Task> writeAction)
        {
            using (var session = _driver.AsyncSession())
            {
                await session.ExecuteWriteAsync(writeAction);
            }
        }

        public async Task ExecuteReadAsync(Func<IAsyncQueryRunner, Task> readAction)
        {
            using (var session = _driver.AsyncSession())
            {
                await session.ExecuteReadAsync(readAction);
            }
        }

        public void Dispose()
        {
            _driver?.Dispose();
        }
    }
}
