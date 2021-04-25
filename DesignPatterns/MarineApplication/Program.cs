using System;
using FluentBuilderPattern;

namespace MarineApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var unit = MarineUnitBuilder
                    .Initialize()
                    .WithName("Luna")
                    .WithIntendedUse(new UnitIntendedUse(TypeOfUse.MarineCommercial, "aa", "bb"))
                    .WithDimensions(new Dimensions(100,200,300))
                    .WithMechanicalInstallation(new MechanicalInstallation())
                    .WithVersatileInstallation(new VersatileInstallation())
                    .WithElectricalInstallation(new ElectricalInstallation())
                    .WithElectricalInstallation(new ElectricalInstallation())
                    .WithNoMoreElectricalInstallation()
                    .WithBrandAndModel("Volvo", "Penta")
                    .Build();

            var unit1 = MarineUnitBuilder
                .Initialize()
                .WithName("Moja nazwa")
                .WithIntendedUse(new UnitIntendedUse(TypeOfUse.MarineLeisure, "", ""))
                .WithDimensions(new Dimensions(10, 20, 30))
                .WithMechanicalInstallation(new MechanicalInstallation())
                .WithVersatileInstallation(new VersatileInstallation())
                .WithNoMoreElectricalInstallation()
                .WithBrandAndModel("", "")
                .Build();

            Console.WriteLine(unit.ElectricalInstallation.Length);
        }
    }
}
