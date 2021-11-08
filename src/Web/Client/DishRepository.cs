using MenuConfigurator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MenuConfigurator.Web.Client
{
    public class DishRepository
    {
        private readonly ApiClient apiClient;

        public DishRepository(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<IEnumerable<Dish>> GetAll()
        {
            var result = await apiClient.Client.GetFromJsonAsync<IEnumerable<Dish>>(Endpoints.Dishes.GetAll);
            return result;
        }

        public async Task<Dish> Get(Guid id)
        {
            var result = await apiClient.Client.GetFromJsonAsync<Dish>(Endpoints.Dishes.Get(id));
            return result;
        }

        public async Task<Dish> Create(CreateDish dto)
        {
            var response = await apiClient.Client.PostAsJsonAsync(Endpoints.Dishes.PostCreate, dto);
            var result = await response.Content.ReadFromJsonAsync<Dish>();
            return result;
        }

        //public async Task<Dish> Update(Guid dishId, UpdateDish dto)
        //{
        //    var response = await apiClient.Client.p(Endpoints.Dishes.PatchUpdate(dishId), dto);
        //    return await response.Content.ReadAsAsync<Dish>();
        //}

        public async Task Delete(Guid id)
        {
            await apiClient.Client.DeleteAsync(Endpoints.Dishes.Delete(id));
        }

    }
}
