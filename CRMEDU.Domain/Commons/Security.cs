using System.ComponentModel.DataAnnotations;

namespace CRMEDU.Domain.Commons
{
    public class Security
    {
        public long Id { get; set; }
        public string Login { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
    }
}
