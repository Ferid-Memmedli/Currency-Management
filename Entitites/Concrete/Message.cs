using Core.EntitiesCore;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
