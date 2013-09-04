using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyForest.DomainObjects;

namespace FamilyForest.Domain.Abstract
{
    public interface IUserLogic
    {
        bool ValidateUser(DomainUser user);
    }
}
