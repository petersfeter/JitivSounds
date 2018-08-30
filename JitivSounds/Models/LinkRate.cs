using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JitivSounds.Models
{
    public class LinkRate
    {
        public int Id { get; set; }

        [ForeignKey(nameof(LinkId))]
        public Link Link { get; set; }
        public int LinkId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
        public string UserId { get; set; }

        public bool  Like { get; set; }
        
    }
}
