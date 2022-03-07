using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Interfaces {
 public interface IRepository<Entity> where Entity:class {
     Task<IEnumerable<Entity>> GetAllAsync();
     Task<Entity> GetByIdAsync(int id);
     Task<Entity> AddAsync(Entity entity);

     void Update(Entity entity);
     void Remove(Entity entity);
 }
}