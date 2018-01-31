using MadBug.Data.Repositories;
using MagBug.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadBug.Data.Repositories
{
    public class BugRepository : RepositoryBase<Bug>
    {
        public BugRepository(DataContext context): base(context)
        {

        }
    }
}
