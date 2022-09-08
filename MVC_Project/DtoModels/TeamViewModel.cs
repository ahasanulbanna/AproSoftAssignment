using MVC_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.DtoModels
{
    public class TeamViewModel
    {
        public long TeamId { get; set; }
        [Required]
        public string TeamName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Approved By Manager")]
        public bool? IsApprovedByManager { get; set; }
        [Display(Name = "Approved By Director")]
        public bool? IsApprovedByDirector { get; set; }
        [Display(Name = "Member Name")]

        public bool? MemberName { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }
        public List<TeamMember> TeamMembers { get; set; }

    }
}
