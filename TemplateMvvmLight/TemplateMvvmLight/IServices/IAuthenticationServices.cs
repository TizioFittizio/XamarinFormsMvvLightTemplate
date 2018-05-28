using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemplateMvvmLight.Models;

namespace TemplateMvvmLight.IServices
{
    public interface IAuthenticationServices
    {
        Task<HttpResponse<User>> Login(String username, String password);
    }
}
