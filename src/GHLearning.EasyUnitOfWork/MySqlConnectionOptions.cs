namespace GHLearning.EasyUnitOfWork;

public record MySqlConnectionOptions
{
    public string ConnectionString { get; set; } = default!;
}
