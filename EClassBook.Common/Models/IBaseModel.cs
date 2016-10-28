using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EClassBook.Common.Models
{
    public interface IBaseModel
    {
       int Id { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }

        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }

    }
}
