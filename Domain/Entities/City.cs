using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class City : TrackedEntity<uint>
    {
        public required string ArName { get; set; }
        public required string EnName { get; set; }
        public uint? GovernorateId { get; set; }
        public virtual Governorate Governorate { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
