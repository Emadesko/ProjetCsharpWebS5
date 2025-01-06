using ProjetCsharpWebS5.Core.Pagination;
using Microsoft.EntityFrameworkCore;
using ProjetCsharpWebS5.Data;
using ProjetCsharpWebS5.Models;

namespace ProjetCsharpWebS5.Services.impl
{
    public class UserService : IUserService
    {

        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetDatasAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<PaginationModel<User>> GetDatasByPaginate(int page, int pageSize)
        {
            var users = _context.Users.AsQueryable<User>();
            return await PaginationModel<User>.Paginate(users, pageSize, page);
        }

        public async Task<User> GetUserByLogin(string login)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Login == login)!;
        }
    }
}