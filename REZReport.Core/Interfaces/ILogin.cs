using REZReport.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REZReport.Core.Interfaces
{
    public interface ILogin
    {
        Task<ResponseModel<string>> Login(LoginModel model);
    }
}
