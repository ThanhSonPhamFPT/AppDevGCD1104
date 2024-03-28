using AppDevGCD1104.Data;
using AppDevGCD1104.Models;
using AppDevGCD1104.Repository.IRepository;

namespace AppDevGCD1104.Repository
{
	public class BookRepository : Repository<Book>, IBookRepository
	{
		private readonly ApplicationDBContext _dbContext;
		public BookRepository(ApplicationDBContext dbContext):base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void Update(Book entity)
		{
			_dbContext.Books.Update(entity);
		}
	}
}
