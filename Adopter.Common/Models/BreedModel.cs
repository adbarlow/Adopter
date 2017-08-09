using System;
using System.Collections.Generic;
using System.Text;

namespace Adopter.Common.Models
{
    public enum StarRating { One = 1, Two = 2, Three =3 , Four = 4, Five = 5};

    public class BreedModel : BaseModel
    {
        //TODO map propertys to the constructor
        //public BreedModel(string breedName)
        //{

        //}
        public string BreedName { get; set; }
        public StarRating Adaptability { get; set; }
        public StarRating AdaptsWelltoApartmentLiving { get; set; }
        public StarRating GoodForNoviceOwners { get; set; }
        public StarRating SensitivityLevel { get; set; }
        public StarRating ToleratesBeingAlone { get; set; }
        public StarRating ToleratesColdWeather { get; set; }
        public StarRating ToleratesHotWeather { get; set; }
        public StarRating AllAroundFriendliness { get; set; }
        public StarRating AffectionatewithFamily { get; set; }
        public StarRating IncrediblyKidFriendlyDogs { get; set; }
        public StarRating DogFriendly { get; set; }
        public StarRating FriendlyTowardStrangers { get; set; }
        public StarRating HealthGrooming { get; set; }
        public StarRating AmountOfShedding { get; set; }
        public StarRating DroolingPotential { get; set; }
        public StarRating EasyToGroom { get; set; }
        public StarRating GeneralHealth { get; set; }
        public StarRating PotentialForWeightGain { get; set; }
        public StarRating Size { get; set; }
        public StarRating Trainability { get; set; }
        public StarRating EasyToTrain { get; set; }
        public StarRating Intelligence { get; set; }
        public StarRating PotentialForMouthiness { get; set; }
        public StarRating PreyDrive { get; set; }
        public StarRating TendencyToBarkOrHowl { get; set; }
        public StarRating WanderlustPotential { get; set; }
        public StarRating ExerciseNeeds { get; set; }
        public StarRating EnergyLevel { get; set; }
        public StarRating Intensity { get; set; }
        public StarRating ExerciseNeeds1 { get; set; }
        public StarRating PotentialForPlayfulness { get; set; }
    }
}
