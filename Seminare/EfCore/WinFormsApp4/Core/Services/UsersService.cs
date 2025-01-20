using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp4.Core.Data;

namespace WinFormsApp4.Core.Services
{
    public static class UsersService
    {
        public static void AddUser(User user)
        {
            var dbContext = new UsersDbContext(Program.ConnectionString);
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        internal static void EditUser(int userId, User editedUser)
        {
            var dbContext = new UsersDbContext(Program.ConnectionString);
            var user = dbContext.Users.Find(userId);
            user.Name = editedUser.Name;
            user.Surname = editedUser.Surname;
            user.Email = editedUser.Email;
            if (!string.IsNullOrEmpty(editedUser.Password))
            {
                user.Password = editedUser.Password;
            }
            dbContext.SaveChanges();
        }

        internal static User? GetById(int userId)
        {
            var dbContext = new UsersDbContext(Program.ConnectionString);
            return dbContext.Users.Find(userId);
        }

        internal static List<User> GetUsers()
        {
            var dbContext = new UsersDbContext(Program.ConnectionString);
            return dbContext.Users.ToList();
        }
    }
}
