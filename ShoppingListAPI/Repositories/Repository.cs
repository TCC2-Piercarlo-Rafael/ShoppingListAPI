using System.Linq.Expressions;

namespace ShoppingListAPI.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DataContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;

            _dbSet = _context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet
        {
            get { return _dbSet; }
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> lambda)
        {
            return DbSet.Where(lambda).ToList();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}
