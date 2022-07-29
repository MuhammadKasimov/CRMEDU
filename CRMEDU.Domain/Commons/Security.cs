using System.ComponentModel.DataAnnotations;

namespace CRMEDU.Domain.Commons
{
    public class Security
    {
        public long Id { get; set; }
        public string Login { get; set; }

        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
