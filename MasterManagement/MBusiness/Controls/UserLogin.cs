using System;
using MEventBus;
using System.Threading.Tasks;
using System.Collections.Generic;
using MEventBus.UI;

namespace MBusiness.Controls
{
    /// <summary>
    /// 提供User登录验证
    /// </summary>
    internal class UserLogin : BaseControls
    {
        internal override object Control => throw new NotImplementedException();
        internal override TaskPromise Execute(Event e)
        {
            return null;
        }

        public Task<bool> Login(string userName, string password)
        {
            return Task.Factory.StartNew(() =>
            {
                return userName == "ymz" && password == "123";
            });
        }

        public List<User> GetUsers()
        {
            System.Threading.Thread.Sleep(10000); 
            return new List<User>() {
                new User(){
                    Name ="YMZ",
                    Sex = "男",
                    Age = 21
                },
                new User(){
                    Name ="SDM",
                    Sex = "男",
                    Age = 21
                },
                new User(){
                    Name ="HZH",
                    Sex = "女",
                    Age = 21
                }
            };
        }

    }
}
