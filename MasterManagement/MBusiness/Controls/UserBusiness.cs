using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MBusiness.Controls
{
    internal class UserBusiness : BaseControls
    {
        public string Get()
        {
            return "hello world";
        }

        public string GetName(string name)
        {
            return name;
        }

        public async Task GetTask()
        {
            await Task.Delay(5000);
            Console.WriteLine("success");
        }

        public async Task<int> GetAge()
        {
            await Task.Delay(1000);
            return 1;
        }
    }
}
