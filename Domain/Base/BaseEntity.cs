using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Domain.Base
{
    public class BaseEntity<T>
    {
        public BaseEntity()
        {
            Deleted = false;
            RowVersion = 1;
        }

        [Key]
        public T Id { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }

        [NotMapped]
        public int RowVersion { get; set; }
    }
}
