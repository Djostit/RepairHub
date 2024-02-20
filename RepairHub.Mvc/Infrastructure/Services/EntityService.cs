using Microsoft.EntityFrameworkCore;
using RepairHub.Database.Context;
using RepairHub.Database.Entities.Base;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;

namespace RepairHub.Mvc.Infrastructure.Services
{
    public class EntityService<T> : IEntityService<T> where T : Entity, new()
    {
        private readonly RepairHubContext _context;
        protected DbSet<T> Set { get; }
        public virtual IQueryable<T> Items => Set;
        public EntityService(RepairHubContext context)
        {
            _context = context;
            Set = _context.Set<T>();
        }

        public async Task<T> Add(T item, CancellationToken cancellation = default)
        {
            await _context.AddAsync(item, cancellation).ConfigureAwait(false);
            await SaveChanges(cancellation).ConfigureAwait(false);
            return item;
        }

        public async Task<T> Delete(T item, CancellationToken cancellation = default)
        {
            _context.Remove(item);
            await SaveChanges(cancellation).ConfigureAwait(false);
            return item;
        }

        public async Task<T> DeleteById(int id, CancellationToken cancellation = default)
        {
            var item = Set.Local.FirstOrDefault(x => x.Id == id);
            item ??= await Set
                .Select(x => new T { Id = x.Id })
                .FirstOrDefaultAsync(x => x.Id == id, cancellation)
                .ConfigureAwait(false);
            return await Delete(item, cancellation).ConfigureAwait(false);
        }

        public async Task<bool> Exist(T item, CancellationToken cancellation = default)
        {
            return await Items.AnyAsync(x => x.Id == item.Id, cancellation).ConfigureAwait(false);
        }

        public async Task<bool> ExistId(int id, CancellationToken cancellation = default)
        {
            return await Items.AnyAsync(x => x.Id == id, cancellation).ConfigureAwait(false);
        }

        public async Task<T> GetById(int id, CancellationToken cancellation = default)
            => Items switch
            {
                DbSet<T> set => await set.FindAsync(new object[] { id }, cancellation).ConfigureAwait(false),
                { } items => await items.FirstOrDefaultAsync(item => item.Id == id, cancellation).ConfigureAwait(false),
            };

        public async Task<int> GetCount(CancellationToken cancellation = default)
        {
            return await Items.CountAsync(cancellation).ConfigureAwait(false);
        }

        public async Task<IPage<T>> GetPage(int page, int size, CancellationToken cancellation = default)
        {
            return new Page(await Items.Skip(((page - 1) * size)).Take(size).ToArrayAsync(cancellation).ConfigureAwait(false), await GetCount(cancellation).ConfigureAwait(false), page, size);
        }
        internal record Page(IEnumerable<T> Items, int TotalCount, int CurrentPage, int Size) : IPage<T>
        {
            public int TotalPages => (int)Math.Ceiling((double)TotalCount / Size);
        }

        public async Task<T> Update(T item, CancellationToken cancellation = default)
        {
            _context.Update(item);
            await SaveChanges(cancellation).ConfigureAwait(false);
            return item;
        }

        public async Task<int> SaveChanges(CancellationToken cancellation = default)
        {
            return await _context.SaveChangesAsync(cancellation).ConfigureAwait(false);
        }

        public async Task<List<T>> GetAll(CancellationToken cancellation = default)
        {
            return await Items.ToListAsync(cancellation).ConfigureAwait(false);
        }
    }
}
