using Bogus;
using MenuConfigurator.Model;
using System;

namespace MenuConfigurator.FunctionalTests
{
    public static class DishMother
    {
        public static CreateDish Create()
        {
            var faker = new Faker<CreateDish>()
                .StrictMode(true)
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Title, f => f.Commerce.Product())
                .RuleFor(x => x.Allergens, f => f.Commerce.ProductDescription())
                .RuleFor(x => x.Ingredients, f => f.Commerce.ProductMaterial())
                .RuleFor(x => x.NutritionalInfo, f => f.Commerce.ProductAdjective())
                .RuleFor(x => x.Type, f => f.PickRandom<DishType>())
                .RuleFor(x => x.ImagePath, f => f.Internet.UrlWithPath());

            faker.Locale = "es";
            return faker.Generate();
        }

        public static UpdateDish Update()
        {
            var faker = new Faker<UpdateDish>()
                .StrictMode(true)
                .RuleFor(x => x.Title, f => f.Commerce.Product())
                .RuleFor(x => x.Allergens, f => f.Commerce.ProductDescription())
                .RuleFor(x => x.Ingredients, f => f.Commerce.ProductMaterial())
                .RuleFor(x => x.NutritionalInfo, f => f.Commerce.ProductAdjective())
                .RuleFor(x => x.Type, f => f.PickRandom<DishType>())
                .RuleFor(x => x.ImagePath, f => f.Internet.UrlWithPath());

            faker.Locale = "es";
            return faker.Generate();
        }
    }
}
