using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace loginPage.Model
{
    public interface IUserRepository
    {

        Task<bool> AuthenticateUser(NetworkCredential credential);
        void Add(UserModel user);
        void Update(UserModel user);
        void Delete(int id);
        UserModel GetById(int id);
        UserModel GetByName(string name);

    }
}
