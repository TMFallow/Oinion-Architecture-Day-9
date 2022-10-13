using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service
{
    public interface IUserInfoService
    {
        UserInfo GetUserInfo(long? id);
    }
}
