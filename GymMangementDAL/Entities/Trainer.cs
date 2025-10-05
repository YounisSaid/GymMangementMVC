using GymMangementDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Entities
{
    public class Trainer : GymUser
    {
        public Speicalites Speciality { get; set; }
        public ICollection<Session> Sessions { get; set; } = null!;
    }
}
