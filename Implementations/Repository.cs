using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Implementations {
    public class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<Entity> _set;
        
        public Repository(DbContext context){
            _context= context;
            _set = context.Set<Entity>();
        }
        public async Task<Entity> AddAsync(Entity entity)
        {
            await _set.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task<Entity> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        public void Remove(Entity entity)
        {
             _set.Remove(entity);
        }

        public void Update(Entity entity)
        {
            _set.Update(entity);
        }
    }
}