﻿using MediatR;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Constants;

namespace Restaurants.Application.Restaurants.Querries.GetAllRestaurants;

public class GetAllRestaurantsQuery : IRequest<PagedResults<RestaurantDto>>
{
    public string? SearchPhrase { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set;}
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}