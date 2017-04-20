using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IsabellaBirdBlog.Models
{
    public class PersonExperience
    {
        [Key]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; }
    }
}
