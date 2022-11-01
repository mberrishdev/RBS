using RBS.Domain.UserInfo;
using System.Text.Json.Serialization;

namespace RBS.Application.Services
{
    public class BaseQuery
    {
        [JsonIgnore]
        public UserModel UserModel { get; set; }
    }
}
