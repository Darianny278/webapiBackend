using System.Threading.Tasks;

namespace backend.Interfaces {
    public interface IUnitOfWork {
         ICategoryRepository CategoryRepository{get;}
         IMediaRepository MediaRepository{get;}

         ItypeMediaRepository TypeMediaRepository{get;}

         Task<int> CommitAsync();
         Task DisposeAsync();
         
    }
}