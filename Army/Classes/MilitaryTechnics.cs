using System;

namespace Army.Classes
{
    public class MilitaryTechnics
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeTechnics { get; set; }        
        public int YearRelease { get; set; }
        public TechnicalInfo TechnicalSpecs { get; set; }
        public CombatInfo CombatInfo { get; set; } 
    }
    public class TechnicalInfo
    {
        public string Weight { get; set; }
        public string EnginePower { get; set; }
        public string MaxSpeed { get; set; } 
        public string FuelCapacity { get; set; }
    }
    public class CombatInfo
    {
        public string Crew { get; set; }
        public string Armament { get; set; }
        public string Ammunition { get; set; } 
        public string Armor { get; set; } 
    }
}
