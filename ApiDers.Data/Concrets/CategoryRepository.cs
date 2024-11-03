using APIDers1.Data.Context;
using APIDers1.Core.Entities;
using APIDers1.Core.Repositories.Abstractions;


namespace APIDers1.Data.Repositories.Concrets
{

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
