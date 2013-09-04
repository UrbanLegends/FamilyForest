using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyForest.ServiceDTO;

namespace FamilyForest.ServiceLayer.Abstract
{
    interface IUserService
    {
        UserDetails GetUserDetail(string userId);
    }
}
