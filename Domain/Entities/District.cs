using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class District : TrackedEntity<uint>
    {
        public required string ArName { get; set; }
        public required string EnName { get; set; }
        public uint? CityId { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual City City { get; set; }
    }
}
