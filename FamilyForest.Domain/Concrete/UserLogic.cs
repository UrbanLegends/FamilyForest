using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyForest.Domain.Abstract;
using FamilyForest.DomainObjects;

namespace FamilyForest.Domain.Concrete
{
    public class UserLogic : IUserLogic
    {
        public bool ValidateUser(DomainUser user)
        {
            return true;
        }
    }
}
