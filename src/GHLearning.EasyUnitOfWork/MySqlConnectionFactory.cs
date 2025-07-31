using Microsoft.Extensions.Options;
using MySqlConnector;
using System.Data;

namespace GHLearning.EasyUnitOfWork;

internal sealed class MySqlConnectionFactory(
    IOptions<MySqlConnectionOptions> options) : IMySqlConnectionFactory
{
    private MySqlConnectionOptions _options { get; } = options.Value;
    public IDbConnection Connection => new MySqlConnection(_options.ConnectionString);
}