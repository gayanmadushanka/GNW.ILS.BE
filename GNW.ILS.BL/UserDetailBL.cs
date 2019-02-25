using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GNW.ILS.Core.Utils;
using GNW.ILS.DAL.Contract;
using GNW.ILS.DAL.Entity;

namespace GNW.ILS.BL
{
    public class UserDetailBL
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserDetailBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CheckUserAuthentication(string userName, string password)
        {
            UserEntity userEntity = _unitOfWork.UserDetailsRepository.GetAll().FirstOrDefault(x => x.UserName.Equals(userName) && x.Password.Equals(PasswordHelper.Encrypt(password)));
            if (userEntity == null) return false;
            return true;
        }

        public UserEntity GetUserDetailsBy(Expression<Func<UserEntity, bool>> selector)
        {
            return _unitOfWork.UserDetailsRepository.FindBy(selector).First();
        }

        public IEnumerable<UserEntity> GetAllUserDetails()
        {
            var userEntities = _unitOfWork.UserDetailsRepository.GetAll();
            foreach (var userEntity in userEntities)
            {
                userEntity.Password = PasswordHelper.Decrypt(userEntity.Password);
            }
            return userEntities;
        }

        public int AddUpdateUserDetails(UserEntity userDetails)
        {
            userDetails.Password = PasswordHelper.Encrypt(userDetails.Password);
            if (userDetails.Id == 0)
            {
                _unitOfWork.UserDetailsRepository.Insert(userDetails);
                _unitOfWork.SaveChanges();
            }
            else
            {
                _unitOfWork.UserDetailsRepository.Update(userDetails);
                _unitOfWork.SaveChanges();
            }
            return userDetails.Id;
        }

        public bool DeleteUserDetails(int id)
        {
            _unitOfWork.UserDetailsRepository.Delete(x => x.Id == id);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
