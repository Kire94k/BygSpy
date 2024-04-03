using System.Collections.Generic;
using System.Threading.Tasks;
using BygSpyServer.Models.BygSpy;
using Refit;

namespace BygSpyServer.RefitClients
{
    public interface IKMDAPI
    {

        // KMD endpoints will be put here
        [Get("/example/resource/{id}")]
        Task<User> GetUserById(int id);

        [Post("/example/resource")]
        Task CreateUser([Body] User resource);

        // Add more API endpoints as needed
    }
}
