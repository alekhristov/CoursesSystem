using CoursesSystem.Data.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoursesSystem.Data.Models.Abstracts
{
    public abstract class DataModel : IAuditable, IDeletable
    {
        [Key]
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }
    }
}
