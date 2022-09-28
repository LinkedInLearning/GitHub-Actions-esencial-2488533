using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WisdomPetMedicine.Api.DataAccess;

namespace WisdomPetMedicine.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> logger;
    private readonly WpmDbContext dbContext;

    public ProductsController(ILogger<ProductsController> logger,
        WpmDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;

        dbContext.Database.EnsureCreated();
    }

    [HttpGet]
    public IActionResult Get()
    {
        var allProducts = dbContext.Products.ToList();
        return Ok(allProducts);
    }
}