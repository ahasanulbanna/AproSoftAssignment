using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class Team
    {
        public Team()
        {
            this.TeamMembers =new List<TeamMember>();
        }
        [Key]
        public long TeamId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Approved By Manager")]
        public bool? IsApprovedByManager { get; set; }
        public string ManagerApproveHtmlCode { get; set; }
        [Display(Name = "Approved By Director")]
        public bool? IsApprovedByDirector { get; set; }
        public string DirectorApproveHtmlCode { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
