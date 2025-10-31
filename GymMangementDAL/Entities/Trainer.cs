using GymMangementDAL.Entities.Enums;

namespace GymMangementDAL.Entities
{
    public class Trainer : GymUser
    {
        public Speicalites? Speciality { get; set; }
        public ICollection<Session> Sessions { get; set; } = null!;
    }
}
