using System.Text.Json.Serialization;

namespace RBS.Application.Models.QRModels
{
    public class QRModel
    {
        [JsonIgnore]
        public byte[] Data { get; set; }
        public string QrImage { get; set; }
        public string FileName { get; set; }
    }
}
