using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RepairHub.Database.Entities.Base.Interface;
using RepairHub.Mvc.Infrastructure.Commands.AddEntity;
using RepairHub.Mvc.Infrastructure.Commands.DeleteEntity;
using RepairHub.Mvc.Infrastructure.Commands.EditEntity;
using RepairHub.Mvc.Infrastructure.Queries.GetData;
using RepairHub.Mvc.Infrastructure.Queries.GetEntityById;

namespace RepairHub.Mvc.Controllers.Base
{
    public abstract class EntityController<TModel, TBase> : Controller
        where TModel: IEntity
        where TBase : IEntity
    {
        public IMediator _mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
        public virtual async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetDataQuery<TModel, TBase>(), cancellationToken);
            return View(response.AsEnumerable());
        }
        public virtual async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(new GetEntityByIdQuery<TModel, TBase>(id), cancellationToken);
                return View(response);
            }
            catch(ValidationException)
            {
                return NotFound();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Не удалось найти информацию");
                ModelState.AddModelError("", ex.Message);
            }
            return NotFound();
        }
        public virtual IActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(TModel request, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(new AddEntityCommand<TModel, TBase>(request), cancellationToken);
            }
            catch(ValidationException ex)
            {
                foreach(var error in ex.Errors)
                {
                    ModelState.AddModelError(error.ErrorCode, error.ErrorMessage);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Не удалось найти информацию");
                ModelState.AddModelError("", ex.Message);
            }
            if(ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }
        public virtual async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(new GetEntityByIdQuery<TModel, TBase>(id), cancellationToken);
                return View(response);
            }
            catch (ValidationException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Не удалось найти информацию");
                ModelState.AddModelError("", ex.Message);
            }
            return NotFound();
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(new DeleteEntityByIdCommand<TBase>(id), cancellationToken);
            }
            catch (ValidationException ex)
            {
                foreach (var error in ex.Errors)
                {
                    ModelState.AddModelError(error.ErrorCode, error.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Не удалось удалить запись");
                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
        public virtual async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(new GetEntityByIdQuery<TModel, TBase>(id), cancellationToken);
                return View(response);
            }
            catch (ValidationException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Не удалось найти информацию");
                ModelState.AddModelError("", ex.Message);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(int id, TModel request, CancellationToken cancellationToken)
        {
            if(request.Id != id)
                return RedirectToAction(nameof(Details), new { id = request.Id });
            try
            {
                await _mediator.Send(new EditEntityCommand<TModel, TBase>(request), cancellationToken);
                return RedirectToAction(nameof(Details), new { id = request.Id });
            }
            catch (ValidationException ex)
            {
                foreach (var error in ex.Errors)
                {
                    ModelState.AddModelError(error.ErrorCode, error.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Не удалось найти информацию");
                ModelState.AddModelError("", ex.Message);
            }
            return NotFound();
        }

    }
}
