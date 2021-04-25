using System.Collections.Generic;

namespace BuilderPattern
{
    public class MarineUnit
    {
        public MarineUnit() { }
        
        public UnitIntendedUse UnitIntendedUse { get; set; }
        
        public string UnitName { get; set; }
        
        public Dimensions Dimensions { get; set; }
        
        public MechanicalInstallation MechanicalInstallation { get; set; }
        
        public ElectricalInstallation[] ElectricalInstallation { get; set; }

        public VersatileInstallation VersatileInstallation { get; set; }
        
        public string Brand { get; set; }
        
        public string Model { get; set; }

        //Other methods...
    }

    public class UnitIntendedUse
    {
        public UnitIntendedUse(TypeOfUse typeOfUse, string lineOfBusiness, string unitPurpose)
        {
            TypeOfUse = typeOfUse;
            LineOfBusiness = lineOfBusiness;
            UnitPurpose = unitPurpose;
        }

        public TypeOfUse TypeOfUse { get; set; }
        public string LineOfBusiness { get; set; }
        public string UnitPurpose { get; set; }
    }

    public enum TypeOfUse
    {
        MarineCommercial,
        MarineLeisure
    }

    public struct Dimensions
    {
        public Dimensions(int length, int width, int weight)
        {
            Length = length;
            Width = width;
            Weight = weight;
        }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Weight { get; set; }
    }

    public class MechanicalInstallation : Installation { }

    public class ElectricalInstallation : Installation { }

    public class VersatileInstallation : Installation { }

    public abstract class Installation
    {
        public IList<Driveline> InstallationDrivelines { get; set; }
    }

    public class Driveline
    {
        public Engine Engine { get; set; }
    }

    public class Engine { }
}
