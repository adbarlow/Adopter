using System;
using System.Collections.Generic;
using System.Text;

namespace Adopter.Common.Models
{
    public class DogModel : BaseModel
    {
        public int Age => CalculateAge();
        public BreedModel Breed { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Birthdate { get; set; }

        int CalculateAge()
        {
            var age = DateTimeOffset.Now.Year - Birthdate.Year;

            if (Birthdate>DateTimeOffset.Now.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
