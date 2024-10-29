﻿using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository,
    ILogger<CreateRestaurantCommandHandler> logger,
    IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting restaurant with id: {request.Id}");

        var restaurant = await restaurantsRepository.GetByIdAsync( request.Id );

        if (restaurant is null)
            throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        if(!restaurantAuthorizationService.Authorize(restaurant,ResourceOperation.Delete))
        {
            throw new ForbidException();
        }

        await restaurantsRepository.Delete(restaurant);
    }
}