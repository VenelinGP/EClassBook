namespace EClassBook.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public interface IBaseModel
    {
        [Key]
        int Id { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }

        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }

    }
}
