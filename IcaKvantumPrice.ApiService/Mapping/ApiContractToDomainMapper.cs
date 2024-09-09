﻿using IcaKvantumPrice.ApiService.Contracts.Requests;
using IcaKvantumPrice.ApiService.Domain;

namespace IcaKvantumPrice.ApiService.Mapping;

public static class ApiContractToDomainMapper
{
    public static Shopping ToShopping(this CreateShoppingRequest request)
    {
        return new Shopping
        {
            ProductIdentifier = request.ProductIdentifier,
            Description = request.Description,
            Price = request.Price,
            ShoppingDate = request.ShoppingDate,
        };
    }
}
