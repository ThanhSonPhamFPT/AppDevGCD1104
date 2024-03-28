using AppDevGCD1104.Data;
using AppDevGCD1104.Repository.IRepository;

namespace AppDevGCD1104.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDBContext _dbContext;
        public ICategoryRepository CategoryRepository { get; private set; }

        public IBookRepository BookRepository { get; private set; }

        public UnitOfWork(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            CategoryRepository = new CategoryRepository(dbContext);
            BookRepository = new BookRepository(dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
