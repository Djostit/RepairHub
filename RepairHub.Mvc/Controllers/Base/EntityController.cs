using FluentValidation;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using RepairHub.Database.Entities.Base.Interface;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;

namespace RepairHub.Mvc.Controllers.Base
{
    public abstract class EntityController<Dto, TEntity> : Controller
        where Dto : IEntity
        where TEntity : IEntity
    {
        public IEntityService<TEntity> _service => HttpContext.RequestServices.GetRequiredService<IEntityService<TEntity>>();
        public IMapper _mapper => HttpContext.RequestServices.GetRequiredService<IMapper>();
        public virtual async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var data = await _service.GetAll(cancellationToken);
            var dto = _mapper.Map<List<Dto>>(data);
            return View(dto.AsEnumerable());
        }
        public virtual async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _service.GetById(id, cancellationToken);
                var dto = _mapper.Map<Dto>(data);
                return View(dto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Не удалось найти информацию");
                ModelState.AddModelError("", ex.Message);
            }
            return NotFound();
        }
        public virtual IActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(Dto request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(request);
                var result = await _service.Add(entity, cancellationToken);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Не удалось найти информацию");
                ModelState.AddModelError("", ex.Message);
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }
        public virtual async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _service.GetById(id, cancellationToken);
                var dto = _mapper.Map<Dto>(data);
                return View(dto);
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
                await _service.DeleteById(id, cancellationToken);
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
                var data = await _service.GetById(id, cancellationToken);
                var dto = _mapper.Map<Dto>(data);
                return View(dto);
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
        public virtual async Task<IActionResult> Edit(int id, Dto request, CancellationToken cancellationToken)
        {
            if (request.Id != id)
                return RedirectToAction(nameof(Details), new { id = request.Id });
            try
            {
                var entity = _mapper.Map<TEntity>(request);
                var result = await _service.Update(entity, cancellationToken);
                return RedirectToAction(nameof(Details), new { id = request.Id });
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
