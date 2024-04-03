using BygSpyServer.RefitClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BygSpyServer.Services
{
    public class UserService
    {
        private IKMDAPI _kmdAPI;

        public UserService(IKMDAPI kMDAPI) 
        {
            _kmdAPI = kMDAPI;
        }

        
        
    }
}
