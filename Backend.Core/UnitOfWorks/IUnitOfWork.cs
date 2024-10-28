using System.Threading.Tasks;
using Backend.Core.Repositories;

namespace Backend.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IBlogRepository Blogs { get; }
        ICommentRepository Comments { get; }
        
        Task CommitAsync();
        void Commit();
    }
}
