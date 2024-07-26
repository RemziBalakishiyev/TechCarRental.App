﻿namespace CarRental.Domain.Entities.Accounts;

public class Role
{
    public int Id { get; set; }
    public string RoleName { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}
