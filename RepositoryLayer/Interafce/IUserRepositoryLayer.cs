using CommanLayer;

namespace RepositoryLayer.Interface
{
    public interface IUserRepositoryLayer
    {
        /// <summary>
        /// Method to Perform Conversion.
        /// </summary>
        /// <param name="Info"></param>
        /// <returns>Conversion of units</returns>
        RegisterModel UserRegister(RegisterModel Info);

        //Interface method for user Login
        UserDetails UserLogin(Login user);
    }
}