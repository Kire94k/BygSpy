using Refit;

namespace BygSpyServer.RefitClients
{
    public class KMDClient
    {
        public static IKMDAPI CreateClient(string baseUrl)
        {
            return RestService.For<IKMDAPI>(baseUrl);
        }
    }
}
