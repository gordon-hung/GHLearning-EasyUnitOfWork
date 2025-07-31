using GHLearning.EasyUnitOfWork.Services.Todos.Add;
using GHLearning.EasyUnitOfWork.Services.Todos.GetById;
using GHLearning.EasyUnitOfWork.Services.Todos.Update;
using GHLearning.EasyUnitOfWork.Services.Todos.UpdateRollback;
using GHLearning.EasyUnitOfWork.WebApi.Controllers.Todos.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GHLearning.EasyUnitOfWork.WebApi.Controllers.Todos;

[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
	[HttpPost("Add")]
	public ValueTask AddAsync(
		[FromServices] ITodoAddService service,
		[FromBody] TodoAddRequest request)
		=> service.CommandAsync(request, HttpContext.RequestAborted);

	[HttpGet("{id}")]
	public ValueTask<TodoGetByIdResponse?> GetByIdAsync(
		[FromServices] ITodoGetByIdService service,
		int id)
		=> service.GetAsync(new TodoGetByIdRequest(id), HttpContext.RequestAborted);

	[HttpPatch("{id}")]
	public ValueTask<TodoUpdateResponse> UpdateAsync(
		[FromServices] ITodoUpdateService service,
		int id,
		[FromBody] TodoUpdateViewModel source)
		=> service.CommandAsync(new TodoUpdateRequest(
			Id: id,
			Title: source.Title,
			Description: source.Description), HttpContext.RequestAborted);

	[HttpPatch("{id}/Rollback")]
	public ValueTask<TodoUpdateRollbackResponse> UpdateRollbackAsync(
		[FromServices] ITodoUpdateRollbackService service,
		int id,
		[FromBody] TodoUpdateRollbackViewModel source)
		=> service.CommandAsync(new TodoUpdateRollbackRequest(
			Id: id,
			Title: source.Title,
			Description: source.Description), HttpContext.RequestAborted);
}
