using System;

namespace Army.Classes
{
    public class Soldier
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Rank { get; set; } 
        public PersonalInfo PersonalInfo { get; set; }
        public ServiceInfo ServiceInfo { get; set; }
    }
    public class PersonalInfo
    {
        public DateTime BirthDate { get; set; }
        public string Passport { get; set; }
        public string Address { get; set; }
    }
    public class ServiceInfo
    {
        public DateTime EnlistmentDate { get; set; }
        public string Unit { get; set; } 
        public string Position { get; set; }
        public string ContractType { get; set; }
    }
}
