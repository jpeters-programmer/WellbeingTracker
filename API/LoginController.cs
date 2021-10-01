using System;
using DTO;
using Model;
namespace API
{
    public class LoginController : IController
    {
        private WellbeingDbContext _db;
        public LoginController(WellbeingDbContext db)
        {
            _db = db;
        }
    }
}