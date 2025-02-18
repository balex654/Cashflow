namespace Domain.User
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task<User?> GetById(string id);
        Task<User?> GetByEmail(string email);
    }
}
