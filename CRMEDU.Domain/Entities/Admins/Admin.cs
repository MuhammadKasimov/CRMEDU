using CRMEDU.Domain.Commons;

namespace CRMEDU.Domain.Entities.Admins
{
    public class Admin : Auditable
    {
        public long BasicsId { get; set; }
        public Basics Basics { get; set; }
        public virtual long ConnectionId { get; set; }
        public virtual Connection Connection { get; set; }

    }
}