
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvMasterDetails.DtoModels
{
    public class ApproveStatus
    {
        public long TeamId { get; set; }
        public bool? IsApprovedByManager { get; set; }
        public bool? IsApprovedByDirector { get; set; }
        public bool IsManager { get; set; }
    }
}
