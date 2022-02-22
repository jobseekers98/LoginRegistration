using MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public    interface ILogin
    {
        public Task<int> LoginData(LoginModel objLoginModel);
    }
}
