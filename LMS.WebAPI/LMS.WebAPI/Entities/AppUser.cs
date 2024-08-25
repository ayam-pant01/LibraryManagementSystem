﻿using Microsoft.AspNetCore.Identity;

namespace LMS.WebAPI.Entities;

public class AppUser : IdentityUser
{
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
}
