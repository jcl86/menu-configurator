using MenuConfigurator.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace MenuConfigurator.FunctionalTests
{
    public static class DishExtensions
    {
        public async static Task<Dish> DishInDatabase(this ServerFixture given)
        {
            var dto = DishMother.Create();
            var response = await given
             .Server
             .CreateRequest(Endpoints.Dishes.PostCreate)
             .WithJsonBody(dto)
             .PostAsync();
            await response.ShouldBe(StatusCodes.Status201Created);
            var result = await response.ReadJsonResponse<Dish>();
            return result;
        }

        public async static Task<Dish> GetDishFromDatabase(this ServerFixture given, Guid dishId)
        {
            var response = await given
             .Server
             .CreateRequest(Endpoints.Dishes.Get(dishId))
             .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);
            var result = await response.ReadJsonResponse<Dish>();
            return result;
        }
    }

}
