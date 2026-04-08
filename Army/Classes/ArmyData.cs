using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army.Classes
{
    public class ArmyData
    {
        public List<Soldier> Soldiers { get; set; }
        public List<MilitaryTechnics> Technics { get; set; }
        public List<Duty> Duties { get; set; }
    }
}
