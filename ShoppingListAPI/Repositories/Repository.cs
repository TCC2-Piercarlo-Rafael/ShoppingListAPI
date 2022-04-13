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
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }
    }
}
