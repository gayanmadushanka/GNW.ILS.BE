using System.Collections.Generic;
using System.Linq;
using GNW.ILS.DAL.Contract;
using GNW.ILS.DAL.Entity;

namespace GNW.ILS.BL
{
    public class UserRoleBL
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UserRoleEntity> GetModulesByUserRoleId(int userRoleId)
        {
            return _unitOfWork.UserRoleRepository.GetModulesByUserRoleId(userRoleId);
        }

        public IEnumerable<UserRoleEntity> GetUserRoles()
        {
            return _unitOfWork.UserRoleRepository.GetUserRoles();
        }
    }
}
