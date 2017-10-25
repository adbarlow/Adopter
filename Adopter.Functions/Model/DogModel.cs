using System;
using System.Collections.Generic;
namespace dogfunctions.Model
{
    public class Parameters
    {
        public string Adaptability { get; set; }
        public string AdaptsWelltoApartmentLiving { get; set; }
        public string GoodForNoviceOwners { get; set; }
        public string SensitivityLevel { get; set; }
        public string ToleratesBeingAlone { get; set; }
        public string ToleratesColdWeather { get; set; }
        public string ToleratesHotWeather { get; set; }
        public string AllAroundFriendliness { get; set; }
        public string AffectionatewithFamily { get; set; }
        public string IncrediblyKidFriendlyDogs { get; set; }
        public string DogFriendly { get; set; }
        public string FriendlyTowardStrangers { get; set; }
        public string HealthGrooming { get; set; }
        public string AmountOfShedding { get; set; }
        public string DroolingPotential { get; set; }
        public string EasyToGroom { get; set; }
        public string GeneralHealth { get; set; }
        public string PotentialForWeightGain { get; set; }
        public string Size { get; set; }
        public string Trainability { get; set; }
        public string EasyToTrain { get; set; }
        public string Intelligence { get; set; }
        public string PotentialForMouthiness { get; set; }
        public string PreyDrive { get; set; }
        public string TendencyToBarkOrHowl { get; set; }
        public string WanderlustPotential { get; set; }
        public string ExerciseNeeds { get; set; }
        public string EnergyLevel { get; set; }
        public string Intensity { get; set; }
        public string PotentialForPlayfulness { get; set; }
    }

    public class Dog
    {
        public string id { get; set; }
        public string dogName { get; set; }
        public string dogDescription { get; set; }
        public Parameters parameters { get; set; }
        public List<string> photoUrls { get; set; }
    }
}
