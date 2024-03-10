using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Base
{
    public class EntityBase
    {
        public Guid Id;
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
        public bool IsDeleted;
    }
}
