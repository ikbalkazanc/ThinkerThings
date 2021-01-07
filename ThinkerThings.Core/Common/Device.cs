using ThinkerThings.Core.Entities;

namespace ThinkerThings.Core.Common
{
    public class Device : BaseEntity
    {
        public bool isAlive { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        //public bool isAlive { get; set; }
    }
}
