using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyForest.DataAccess.Repositories.Abstract;
using FamilyForest.DataDTO;

namespace FamilyForest.DataAccess.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
       

        User IUserRepository.GetUser(string userId)
        {
            User user = new User();
            //Get user from appropriate database and convert to User object
            return user;
        }
    }
}
