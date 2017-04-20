using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsabellaBirdBlog.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        public string PersonName { get; set; }

        //public string LocationId { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<PersonExperience> PersonsExperiences { get; set; }
    }
}
