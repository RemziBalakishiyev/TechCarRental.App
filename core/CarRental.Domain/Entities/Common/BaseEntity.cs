﻿namespace CarRental.Domain.Entities.Common;

public class BaseEntity 
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int CreatedId { get; set; }
    public int UpdatedId { get; set; }
}
