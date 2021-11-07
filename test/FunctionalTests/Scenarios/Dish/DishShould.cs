using FluentAssertions;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.TestHost;
using MenuConfigurator.Model;

namespace MenuConfigurator.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class DishShould
    {
        private readonly ServerFixture Given;

        public DishShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public async Task Be_created()
        {
            var dto = DishMother.Create();
            var response = await Given
             .Server
             .CreateRequest(Endpoints.Dishes.PostCreate)
             .WithJsonBody(dto)
             .PostAsync();
            await response.ShouldBe(StatusCodes.Status201Created);
            var result = await response.ReadJsonResponse<Dish>();

            result.Id.Should().Be(dto.Id);
            result.Title.Should().Be(dto.Title);
            result.Ingredients.Should().Be(dto.Ingredients);
            result.NutritionalInfo.Should().Be(dto.NutritionalInfo);
            result.Allergens.Should().Be(dto.Allergens);
            result.ImagePath.Should().Be(dto.ImagePath);
            result.Type.Should().Be(dto.Type);
        }

        [Fact]
        public async Task Be_found_after_created()
        {
            var dish = await Given.DishInDatabase();

            var response = await Given
               .Server
               .CreateRequest(Endpoints.Dishes.Get(dish.Id))
               .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<Dish>();
            result.Should().BeEquivalentTo(dish);
        }

        [Fact]
        public async Task Be_all_found_after_create_2()
        {
            var dish1 = await Given.DishInDatabase();
            var dish2 = await Given.DishInDatabase();

            var response = await Given
               .Server
               .CreateRequest(Endpoints.Dishes.GetAll)
               .GetAsync();

            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.ReadJsonResponse<IEnumerable<Dish>>();

            result.Count().Should().BeGreaterOrEqualTo(2);
            result.Should().ContainEquivalentOf(dish1);
            result.Should().ContainEquivalentOf(dish2);
        }

        [Fact]
        public async Task Be_updated()
        {
            var dish = await Given.DishInDatabase();

            var dto = DishMother.Update();

            var response = await Given
                .Server
                .CreateRequest(Endpoints.Dishes.PatchUpdate(dish.Id))
                .WithJsonBody(dto)
                .PatchAsync();
            await response.ShouldBe(StatusCodes.Status204NoContent);

            var result = await Given.GetDishFromDatabase(dish.Id);
            result.Id.Should().Be(dish.Id);
            result.Title.Should().Be(dto.Title);
            result.Ingredients.Should().Be(dto.Ingredients);
            result.NutritionalInfo.Should().Be(dto.NutritionalInfo);
            result.Allergens.Should().Be(dto.Allergens);
            result.ImagePath.Should().Be(dto.ImagePath);
            result.Type.Should().Be(dto.Type);
        }

        [Fact]
        public async Task Be_deleted()
        {
            var dish = await Given.DishInDatabase();

            var response = await Given
               .Server
               .CreateRequest(Endpoints.Dishes.Get(dish.Id))
               .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);

            response = await Given
               .Server
               .CreateRequest(Endpoints.Dishes.Delete(dish.Id))
               .DeleteAsync();
            await response.ShouldBe(StatusCodes.Status204NoContent);

            response = await Given
              .Server
              .CreateRequest(Endpoints.Dishes.Get(dish.Id))
              .GetAsync();
            await response.ShouldBe(StatusCodes.Status404NotFound);
        }
    }
}
