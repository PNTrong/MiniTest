using Model.Models;
using Training.Data.Infrastructure;

namespace Data.Repositories
{
    public interface ICountyRepository : IRepository<County>
    {

    }

    public class CountyRepository : RepositoryBase<County>, ICountyRepository
    {
        public CountyRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
