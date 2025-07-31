using System.ComponentModel.DataAnnotations.Schema;
using Dapper.ColumnMapper;

namespace GHLearning.EasyUnitOfWork.Repositories.Todos.Tables;

[Table("todo")]
public record TodoTable
{
	[ColumnMapping("id")]
	public int Id { get; set; }
	[ColumnMapping("title")]
	public string Title { get; set; } = default!;
	[ColumnMapping("description")]
	public string Description { get; set; } = default!;
	[ColumnMapping("created_at")]
	public DateTime CreatedAt { get; set; }
	[ColumnMapping("updated_at")]
	public DateTime UpdatedAt { get; set; }
}
