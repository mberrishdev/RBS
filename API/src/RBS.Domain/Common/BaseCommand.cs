using RBS.Domain.UserInfo;
using System.Text.Json.Serialization;

namespace RBS.Domain.Common
{
    public class BaseCommand
    {
        [JsonIgnore]
        public UserModel? UserModel { get; set; }
    }
}
