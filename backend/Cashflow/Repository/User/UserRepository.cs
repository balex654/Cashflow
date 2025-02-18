using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly CashflowDbContext _context;

        public UserRepository(CashflowDbContext context)
        {
            _context = context;
        }

        public async Task Add(Domain.User.User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.User.User?> GetById(string id)
        {
            return await _context.User.Where(u => u.Id == id).FirstOrDefaultAsync();
        }
    }
}
