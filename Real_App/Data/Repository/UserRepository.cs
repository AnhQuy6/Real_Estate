using Microsoft.EntityFrameworkCore;
using Real_App.Interfaces;
using Real_App.Model;

namespace Real_App.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dc;
        public UserRepository(DataContext dc)
        {

            _dc = dc;

        }
        public async Task<User> Authenticate(string userName, string password)
        {
            return await _dc.Users.FirstOrDefaultAsync(x => x.Username == userName && x.Password == password);
        }
    }
}
