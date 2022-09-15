namespace Domain.Entities;

public abstract class BaseEntity
{
     public int Id { get; set; }
     public DateTime CreatedDate { get; set; }
     public DateTime? LastModifiedDate { get; set; }
}
