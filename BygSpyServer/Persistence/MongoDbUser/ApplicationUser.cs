using AspNetCore.Identity.MongoDbCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BygSpyServer.Persistence.MongoDbUser
{
    public class ApplicationUser : MongoIdentityUser<Guid>
    {
        // Additional properties if needed
    }

}
