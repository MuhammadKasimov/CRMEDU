using System.ComponentModel.DataAnnotations;

namespace CRMEDU.Domain.Commons
{
    public class Connection
    {
        public long Id { get; set; }

        [Phone]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string TgUserName { get; set; }
    }
}
