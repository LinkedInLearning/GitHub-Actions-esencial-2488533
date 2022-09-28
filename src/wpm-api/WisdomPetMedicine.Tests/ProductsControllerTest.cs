using Microsoft.AspNetCore.Mvc;
using WisdomPetMedicine.Api.Controllers;

namespace WisdomPetMedicine.Tests;

public class ProductsControllerTest
{
    [Fact]
    public void GetShouldReturnAllProducts()
    {
        var productsController = 
            new ProductsController(null, 
            new Api.DataAccess.WpmDbContext());
        var result = productsController.Get();
        Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(((OkObjectResult)result).Value);
    }
}