using REZReport.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REZReport.Core.Interfaces
{
    public interface IRegister
    {
        Task<ResponseModel<string>>Register(RegisterModel Input);
        Task<ResponseModel<string>> EmailConfirm(string userId, string code);
    }
}
