using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JitivSounds.Models
{
    public class Link
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Linkyt { get; set; }


        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
        public string UserId { get; set; }

        public int Counter { get; set; }

        public DateTime LastPlayed { get; set; }

        public ISet<LinkRate> LinkRates { get; set; }
    }

    
}
