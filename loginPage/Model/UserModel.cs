using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginPage.Model
{

    [SugarTable("users")]
    public class UserModel
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

    }

}
