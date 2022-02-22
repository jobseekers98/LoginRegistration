using DAL.IRepository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Login : ILogin
    {
        private DatabaseContext databaseContext;

        public Login(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public Task<int> LoginData(LoginModel objLoginModel)
        {
            throw new NotImplementedException();
        }
    }
 }
