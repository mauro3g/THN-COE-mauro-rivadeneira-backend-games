using Company.BL.Repositories;
using Company.DAL;
using Company.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.BL.Services
{
    public class UserService: IUserRepository
    {
        private readonly ApiDbContext _context;

        // Creamos un constructor e inyectar el contexto
        public UserService(ApiDbContext context)
        {
            _context = context;
        }


        // GET Users
        public async Task<IEnumerable<User>> GetUsers()
        {
            var listUsers = await _context.User.ToListAsync();
            return listUsers;
        }

        // GET User By Id
        public async Task<User> GetUserById(int id)
        {

            var userFound = await _context.User.FindAsync(id);
            return userFound;
        }


        // POST User
        public async Task<User> PostUser(User dataUser)
        {
            _context.User.Add(dataUser);
            await _context.SaveChangesAsync();
            return dataUser;
        }


        // UPDATE
        public async Task<User> UpdateUser(int id, User dataUser)
        {
            _context.User.Update(dataUser);
            await _context.SaveChangesAsync();
            return dataUser;
        }

        // DELETE
        public async Task<string> DeleteUserById(int id)
        {
            var userFound = await _context.User.FindAsync(id);
            if (userFound == null)
            {
                return "NOT_FOUND";
            }
            _context.User.Remove(userFound);
            await _context.SaveChangesAsync();
            return "OK";
        }
    }
}
