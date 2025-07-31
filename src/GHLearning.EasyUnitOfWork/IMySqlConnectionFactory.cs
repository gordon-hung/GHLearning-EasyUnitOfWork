using System.Data;

namespace GHLearning.EasyUnitOfWork;

public interface IMySqlConnectionFactory
{
    public IDbConnection Connection { get; }
}
