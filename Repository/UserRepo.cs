using UsersAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersAPI.Repository
{
    public class UserRepo: IUserRepo
    {
        private readonly UsersContext _context;

        public UserRepo()
        {

        }
        public UserRepo(UsersContext context)
        {
            _context = context;
        }

        
        public IEnumerable<UserServiceInfo> GetAllUsers()
        {
            return _context.UserServiceInfos.ToList();
        }
        public async Task<UserServiceInfo> PostUser(UserServiceInfo item)
        {
            UserServiceInfo Sp = null;
            if (item == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                Sp = new UserServiceInfo() {
                    Usid = item.Username + "-" + item.Phoneno,
                    Username = item.Username,
                    Phoneno = item.Phoneno,
                    EmailId = item.EmailId,
                    Password = item.Password,
                    Specialization = item.Specialization,
                    Specification = item.Specification,
                    ServiceCity = item.ServiceCity,
                    Address = item.Address,
                    Aadhaarno = item.Aadhaarno,
                    Role = item.Role,
                    Experience = item.Experience,
                    Costperhour = item.Costperhour,
                    Rating = item.Rating,
                    IsNewProvider = true,
                    IsProvicedBooked=false
                };
                await _context.UserServiceInfos.AddAsync(Sp);
                await _context.SaveChangesAsync();
            }
            return Sp;
        }
        public async Task<UserServiceInfo> RemoveUser(string id)
        {
            UserServiceInfo sp = await _context.UserServiceInfos.FindAsync(id);
            if (sp == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                _context.UserServiceInfos.Remove(sp);
                await _context.SaveChangesAsync();
            }
            return sp;
        }
        public async Task<UserServiceInfo> EditUser(string id,UserServiceInfo item)
        {
            UserServiceInfo sp = await _context.UserServiceInfos.FindAsync(id);
            sp.Password = item.Password;
            sp.Rating = item.Rating;
            sp.IsNewProvider = item.IsNewProvider;
            sp.IsProvicedBooked = item.IsProvicedBooked;
            _context.SaveChanges();
            return sp;
        }
    }
}
