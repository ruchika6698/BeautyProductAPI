using CommanLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IUserBusinessLayer
    {
        /// <summary>
        /// Method to Perform Conversion.
        /// </summary>
        /// <param name="Info"></param>
        /// <returns>Conversion of units</returns>
        bool UserRegister(RegisterModel Info);

        //Interface method for User Login
        UserDetails UserLogin(Login user);

    }
}
