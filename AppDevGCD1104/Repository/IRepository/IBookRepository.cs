using AppDevGCD1104.Models;

namespace AppDevGCD1104.Repository.IRepository
{
	public interface IBookRepository:IRepository<Book>
	{
		void Update(Book entity);
	}
}
