using System;

namespace StaffComposition.Data.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }

        DateTime RecordCreated { get; set; }

        DateTime? RecordModified { get; set; }

        DateTime? RecordDeleted { get; set; }
    }
}