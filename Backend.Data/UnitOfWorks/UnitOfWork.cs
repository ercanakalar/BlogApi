using System.Threading.Tasks;
using Backend.Core.Repositories;
using Backend.Core.UnitOfWorks;
using Backend.Data.Repositories;

namespace Backend.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        private IUserRepository _userRepository;
        private IBlogRepository _blogRepository;
        private ICommentRepository _commentRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IUserRepository Users =>
            _userRepository ??= (IUserRepository)new UserRepository(_appDbContext);

        public IBlogRepository Blogs =>
            _blogRepository ??= (IBlogRepository)new BlogRepository(_appDbContext);

        public ICommentRepository Comments =>
            _commentRepository ??= (ICommentRepository)new CommentRepository(_appDbContext);

        public void Commit()
        {
            _appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
