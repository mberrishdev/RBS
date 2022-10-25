using RBS.Domain.AdditionalInformations;

namespace RBS.Application.Models
{
    public class AdditionalInformationModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }
        public bool IsUrl { get; set; }

        public AdditionalInformationModel(AdditionalInformation additionalInformation)
        {
            Key = additionalInformation.Key;
            Value = additionalInformation.Value;
            Icon = additionalInformation.Icon;
            IsUrl = additionalInformation.IsUrl;
        }
    }
}
