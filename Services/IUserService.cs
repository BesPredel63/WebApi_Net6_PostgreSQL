using WebApi_Net6_PostgreSQL.Entities;
using WebApi_Net6_PostgreSQL.Models.Users;

namespace WebApi_Net6_PostgreSQL.Services {
    public interface IUserService {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Create(CreateRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
    }
}
