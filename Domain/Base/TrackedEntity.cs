using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public class TrackedEntity<T>: BaseEntity<T>
    {
        public TrackedEntity()
        {
            CreatedAt = DateTime.UtcNow;
            LastModifiedAt = DateTime.UtcNow;
        }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }

        public void SetCreatedBy(string userId)
        {
            CreatedBy = userId;
        }
        public void SetLastModifiedBy(string userId)
        {
            LastModifiedBy = userId;
            LastModifiedAt = DateTime.UtcNow;
        }
    }
}
