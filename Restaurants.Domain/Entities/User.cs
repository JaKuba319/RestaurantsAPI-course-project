﻿using Microsoft.AspNetCore.Identity;

namespace Restaurants.Domain.Entities;

public class User : IdentityUser
{
    // custom props
    public DateOnly? DateOfBirth { get; set; }
    public string? Nationality { get; set; }
    public List<Restaurant> OwnedRestaurants { get; set; } = [];
}