using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthJWT_CQRS.Entities.Identity
{
    public class UserEntity : IdentityUser
    {
        [Column(TypeName = "character varying(256)")]
        public string FirstName { get; set; }
        [Column(TypeName = "character varying(256)")]
        public string LastName { get; set; }
        public string Language { get; set; }
        public string Timezone { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
