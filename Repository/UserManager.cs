using UsersAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersAPI.Repository
{
    public class UserManager:IUserManager
    {
        public readonly UsersContext _context;
        public UserManager()
        {

        }
        public UserManager(UsersContext context)
        {
            _context = context;
        }

    }
}
