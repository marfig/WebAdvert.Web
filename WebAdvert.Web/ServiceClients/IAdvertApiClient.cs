using System.Threading.Tasks;

namespace WebAdvert.Web.ServiceClients
{
    public interface IAdvertApiClient
    {
        Task<AdvertResponse> Create(CreateAdvertApiModel model);
        Task<bool> Confirm(ConfirmAdvertRequest model);
    }
}
