using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.RefreshTokens
{
    public class RefreshToken : EntityBase
    {
        [MaxLength(50)]
        public string JwtId { get; set; }
        [MaxLength(50)]
        public string Token { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ExpiryDate { get; set; }
        public bool Used { get; set; } = false;
        public int UserId { get; set; }
    }
}
