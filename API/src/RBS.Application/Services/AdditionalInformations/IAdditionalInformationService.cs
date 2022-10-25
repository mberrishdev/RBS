using RBS.Application.Models;

namespace RBS.Application.Services.AdditionalInformations
{
    public interface IAdditionalInformationService
    {
        Task<List<AdditionalInformationModel>> GetAdditionalInformation(int restaurantId);
    }
}
