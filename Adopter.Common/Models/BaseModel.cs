using System;
using System.Collections.Generic;
using System.Text;

namespace Adopter.Common.Models
{
    public abstract class BaseModel
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        
    }
}
