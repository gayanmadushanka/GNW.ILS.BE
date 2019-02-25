using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GNW.ILS.BL;
using GNW.ILS.DAL.Contract;
using GNW.ILS.DAL.Entity;

namespace GNW.ILS.API
{
    public class PharmacyAPI
    {
        private readonly IUnitOfWork _unitOfWork;

        public PharmacyAPI(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public static async Task<UserEntity> GetUserDetailsByPasswordUsernameAsync(string userName, string password)
        //{
        //    return UserDetailBL.CheckUserAuthentication(userName, password);
        //}

        public static List<ModuleEntity> GetModules(UserEntity userEntity)
        {
            return ModuleBL.GetModules(userEntity);
        }

        public UserEntity GetUserDetailsBy(Expression<Func<UserEntity, bool>> selector)
        {
            var userDetailBL = new UserDetailBL(_unitOfWork);
            return userDetailBL.GetUserDetailsBy(selector);
        }

        public int AddUpdateUserDetails(UserEntity userDetails)
        {
            var userDetailBL = new UserDetailBL(_unitOfWork);
            return userDetailBL.AddUpdateUserDetails(userDetails);
        }

        public IEnumerable<UserEntity> GetAllUserDetails()
        {
            var userDetailBL = new UserDetailBL(_unitOfWork);
            return userDetailBL.GetAllUserDetails();
        }

        public async Task<IEnumerable<UserRoleEntity>> GetUserRolesAsync()
        {
            var userRoleBL = new UserRoleBL(_unitOfWork);
            return userRoleBL.GetUserRoles();
        }

        public async Task<IEnumerable<UserRoleEntity>> GetModulesByUserRoleIdAsync(int userRoleId)
        {
            var userRoleBL = new UserRoleBL(_unitOfWork);
            return userRoleBL.GetModulesByUserRoleId(userRoleId);
        }

        public async Task<IEnumerable<ModuleEntity>> GetAllModulesAsync()
        {
            var moduleBL = new ModuleBL(_unitOfWork);
            return moduleBL.GetAllModules();
        }

        public bool DeleteUserDetails(int id)
        {
            var userDetailBL = new UserDetailBL(_unitOfWork);
            return userDetailBL.DeleteUserDetails(id);
        }
    }
}
