
using BusinessLayer.Interface;
using CommanLayer;
using RepositoryLayer.Interface;
using System;

namespace BusinessLayer
{
    public class UserBusinessLayer : IUserBusinessLayer
    {
        private IUserRepositoryLayer _UserRepositoryLayer;
        public UserBusinessLayer(IUserRepositoryLayer UserRepositoryLayer)
        {
            _UserRepositoryLayer = UserRepositoryLayer;
        }
        /// <summary>
        /// Method to Add Conversion Detail
        /// </summary>
        /// <param name="info">value from quantity model</param>
        /// <returns>Return result of conversion</returns>
        public bool UserRegister(RegisterModel Info)
        {
            try
            {
                var Result = _UserRepositoryLayer.UserRegister(Info);
                if (!Result.Equals(null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for Login
        /// </summary>
        /// <param name="user"> Login API</param>
        /// <returns></returns>
        public UserDetails UserLogin(Login user)
        {
            try
            {
                var result = _UserRepositoryLayer.UserLogin(user);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
