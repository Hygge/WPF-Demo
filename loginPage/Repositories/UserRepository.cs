using loginPage.Db;
using loginPage.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace loginPage.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbClientFactory dbClientFactory;
        private readonly ILogger<IUserRepository> logger;

        public UserRepository(ILogger<IUserRepository> logger, DbClientFactory dbClientFactory)
        {
            this.dbClientFactory = dbClientFactory;
            this.logger = logger;
        }

        public void Add(UserModel user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AuthenticateUser(NetworkCredential credential)
        {
            try
            {
                using var db = dbClientFactory.GetSqlSugarClient();
                UserModel u = await db.Queryable<UserModel>().FirstAsync(x => x.userName.Equals(credential.UserName) && x.password.Equals(credential.Password));
                return u != null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return false;
            }
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByName(string name)
        {
            try
            {
                using var db = dbClientFactory.GetSqlSugarClient();
                UserModel u = db.Queryable<UserModel>().First(x => x.userName.Equals(name));
                return u;
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return null;
            }
        }

        public void Update(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
