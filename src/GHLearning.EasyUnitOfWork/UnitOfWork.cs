using System.Data;
using System.Data.Common;

namespace GHLearning.EasyUnitOfWork;

internal sealed class UnitOfWork(IMySqlConnectionFactory mySqlConnectionFactory) : IUnitOfWork
{
	private IDbConnection? _connection;

	public IDbConnection Connection
	{
		get
		{
			if (_connection == null)
			{
				_connection = mySqlConnectionFactory.Connection;
				if (_connection.State != ConnectionState.Open)
				{
					_connection.Open();
				}
			}

			return _connection;
		}
	}

	public IDbTransaction? Transaction { get; private set; }

	public void BeginTransaction() => Transaction = Connection.BeginTransaction();

	public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
	{
		if (Connection is DbConnection dbConnection)
		{
			Transaction = await dbConnection.BeginTransactionAsync(cancellationToken).ConfigureAwait(true);
		}
		else
		{
			BeginTransaction();
		}
	}

	public void Commit() => Transaction?.Commit();

	public async Task CommitAsync(CancellationToken cancellationToken = default)
	{
		if (Transaction is DbTransaction dbTransaction)
		{
			await dbTransaction.CommitAsync(cancellationToken).ConfigureAwait(false);
		}
		else
		{
			Commit();
		}
	}

	public void Rollback() => Transaction?.Rollback();

	public async Task RollbackAsync(CancellationToken cancellationToken = default)
	{
		if (Transaction is DbTransaction dbTransaction)
		{
			await dbTransaction.RollbackAsync(cancellationToken).ConfigureAwait(false);
		}
		else
		{
			Rollback();
		}
	}
}
