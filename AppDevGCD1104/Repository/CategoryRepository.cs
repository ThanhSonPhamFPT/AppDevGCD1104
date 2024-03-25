using AppDevGCD1104.Data;
using AppDevGCD1104.Models;
using AppDevGCD1104.Repository.IRepository;

namespace AppDevGCD1104.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly ApplicationDBContext _dbContext;
		public CategoryRepository(ApplicationDBContext dbContext):base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void Update(Category entity)
		{
			_dbContext.Categories.Update(entity);
		}
	}
}
