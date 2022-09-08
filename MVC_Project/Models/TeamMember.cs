using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class TeamMember
    {

        [Key]
        public long TeamMemberId { get; set; }
        public string MemberName { get; set; }
        public string Gender { get; set; }

        public DateTime DOB { get; set; }
        public string ContactNo { get; set; }
        public long TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
