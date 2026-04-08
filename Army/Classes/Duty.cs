using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army.Classes
{
    public class Duty
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Priority { get; set; }
        public int Duration { get; set; }
        public AssignedSoldiers AssignedSoldiers { get; set; }
        public LocationInfo LocationInfo { get; set; }
    }
    public class AssignedSoldiers
    {
        public int LeaderId { get; set; }
        public string LeaderName { get; set; } 
        public int MembersCount { get; set; } 
        public string MembersList { get; set; }
    }
    public class LocationInfo
    {
        public string Zone { get; set; }
        public string Coordinates { get; set; }
        public string Checkpoint { get; set; } 
        public string Route { get; set; } 
    }
}
