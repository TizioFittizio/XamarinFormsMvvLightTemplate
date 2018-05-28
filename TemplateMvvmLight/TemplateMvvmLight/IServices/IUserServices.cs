using System;
using TemplateMvvmLight.Models;
using System.Threading.Tasks;

namespace TemplateMvvmLight.IServices
{
    public interface IUserServices
    {
        Task<bool> SignIn(User user);
        Task<bool> SignUp(User user);
        Task<bool> ForgotPassword(String Email);
    }
}
