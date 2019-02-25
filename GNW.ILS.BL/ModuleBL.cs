using System.Collections.Generic;
using GNW.ILS.DAL.Contract;
using GNW.ILS.DAL.Entity;

namespace GNW.ILS.BL
{
    public class ModuleBL
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModuleBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public static List<ModuleEntity> GetModules(UserEntity userEntity)
        {
            List<ModuleEntity> moduleList = new List<ModuleEntity>();

            //UserEntity userEntity = UserDetailBL.GetUserDetailsByPasswordUsername(userName, passWord);
            //moduleList = userEntity.UserRole.ModuleEntities.ToList();

            return moduleList;
        }

        public IEnumerable<ModuleEntity> GetAllModules()
        {
            return _unitOfWork.ModuleDetailsRepository.GetAll();
        }
    }
}
