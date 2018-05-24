using TemplateMvvmLight.Models;
using TemplateMvvmLight.IServices;
using System.Threading.Tasks;

namespace TemplateMvvmLight.Services
{
    public class UserServices : IUserServices
    {
        public Task<bool> SignIn(User user)
        {
            return Task.Run(() => { return true; });
        }

        public Task<bool> SignUp(User user)
        {
            return Task.Run(() => { return true; });
        }

        public Task<bool> ForgotPassword(string Email)
        {
            return Task.Run(() => { return true; });
        }
    }
}
