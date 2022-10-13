using OA.Data;
using OA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service
{
    public class UserInfoService : IUserInfoService
    {
        private IRepository<UserInfo> userInfoRepository;

        public UserInfoService(IRepository<UserInfo> userInfoRepository)
        {
            this.userInfoRepository = userInfoRepository;
        }

        public UserInfo GetUserInfo(long? id)
        {
            return userInfoRepository.Get(id);
        }
    }
}
