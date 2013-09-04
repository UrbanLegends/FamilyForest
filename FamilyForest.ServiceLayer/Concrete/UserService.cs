using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyForest.ServiceDTO;
using FamilyForest.ServiceLayer.Abstract;
using FamilyForest.DataAccess.Repositories.Abstract;
using FamilyForest.Domain.Abstract;
using FamilyForest.DataAccess.Repositories.Concrete;
using FamilyForest.Domain.Concrete;
using FamilyForest.DataDTO;
using FamilyForest.DomainObjects;

namespace FamilyForest.ServiceLayer.Concrete
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IUserLogic _userLogic;
        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="_user"></param>
        public UserService(IUserRepository userRepository, IUserLogic userLogic)
        {
            _userRepository = userRepository;
            _userLogic = userLogic;
        }
        public UserService()
        {
            _userRepository = new UserRepository();
            _userLogic = new UserLogic();
        }
        UserDetails IUserService.GetUserDetail(string userId)
        {
            
            User user = _userRepository.GetUser("1212");
            DomainUser duser = new DomainUser();
            //construct duser from user and invoke the business logic
            _userLogic.ValidateUser(duser);
            //construct USerDetails finally and pass to UI layer
            UserDetails userdet = new UserDetails();
            return userdet;
        }
    }
}
