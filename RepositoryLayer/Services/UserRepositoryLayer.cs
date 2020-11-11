using CommanLayer;
using RepositoryLayer.AppDbContext;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRepositoryLayer : IUserRepositoryLayer
    {
        //DBContext Refernce.
        private Application dBContext;

        /// <summary>
        /// Parameter Constructor For Seting DbContext Reference.
        /// </summary>
        /// <param name="dBContext"></param>
        public UserRepositoryLayer(Application dBContext)
        {
            this.dBContext = dBContext;
        }

        public UserRepositoryLayer()
        {
        }

        /// <summary>
        /// Method to Add Conversion Detail to Database.
        /// </summary>
        /// <param name="Info"></param>
        /// <returns>Conversion result</returns>
        public RegisterModel UserRegister(RegisterModel Info)
        {
            try
            {
                string Password = EncryptedPassword.EncodePasswordToBase64(Info.Password);
                Info.Password = Password;
                //add Data in database
                dBContext.Users.Add(Info);
                //saves all changes in database
                dBContext.SaveChanges();
                return Info;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public UserDetails UserLogin(Login Info)
        {
            try
            { 
                string EmailId = Info.EmailId;
                string Password = EncryptedPassword.EncodePasswordToBase64(Info.Password);

                var Result = dBContext.Users.Where(u => u.EmailId == EmailId && u.Password == Password).FirstOrDefault();

                if (Result != null)
                {
                    UserDetails Data = new UserDetails()
                    {
                        Id = Result.Id,
                        FirstName = Result.FirstName,
                        LastName = Result.LastName,
                        UserRole = Result.UserRole,
                        EmailId = Result.EmailId
                    };
                    return Data;
                }
                else
                {
                    throw new Exception("Login failed");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
