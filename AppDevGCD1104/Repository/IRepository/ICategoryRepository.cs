using AppDevGCD1104.Models;

namespace AppDevGCD1104.Repository.IRepository
{
	public interface ICategoryRepository:IRepository<Category>
	{
		void Update(Category entity);
	}
}
