using MagBug.Domain;

namespace MadBug.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(DataContext context):base(context)
        {   

        }
    }
}
