using RepairHub.Database.Entities.Base.Interface;

namespace RepairHub.Mvc.Infrastructure.Services.Interfaces
{
    public interface IEntityService<T> where T : IEntity
    {
        abstract IQueryable<T> Items { get; }
        public Task<bool> ExistId(int id, CancellationToken cancellation = default);
        public Task<bool> Exist(T item, CancellationToken cancellation = default);
        public Task<int> GetCount(CancellationToken cancellation = default);
        public Task<IPage<T>> GetPage(int page, int size, CancellationToken cancellation = default);
        public Task<T> GetById(int id, CancellationToken cancellation = default);
        public Task<List<T>> GetAll(CancellationToken cancellation = default);
        public Task<T> Add(T item, CancellationToken cancellation = default);
        public Task<T> Update(T item, CancellationToken cancellation = default);
        public Task<T> Delete(T item, CancellationToken cancellation = default);
        public Task<T> DeleteById(int id, CancellationToken cancellation = default);
    }
    public interface IPage<out T>
    {
        IEnumerable<T> Items { get; }
        int TotalCount { get; }
        int CurrentPage { get; }
        int Size { get; }
        int TotalPages { get; }
    }
}
