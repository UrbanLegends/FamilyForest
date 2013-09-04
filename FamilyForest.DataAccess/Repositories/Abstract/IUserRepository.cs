using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyForest.DataDTO;

namespace FamilyForest.DataAccess.Repositories.Abstract
{
    public interface IUserRepository
    {
        User GetUser(string userId);
    }
}
