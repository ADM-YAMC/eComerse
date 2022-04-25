using eCommerceApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace eCommerceApp.Client.Services
{
    public class ProductsServices
    {
        private readonly HttpClient httpClient;



        public ProductsServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }



        public async Task<IEnumerable<dynamic>> GetProducts()
        {
            return await httpClient.GetFromJsonAsync<Products[]>("api/Products");
        }



        public async Task<HttpResponseMessage> PostProducts(Products products)
        {
            return await httpClient.PostAsJsonAsync("api/Products", products);
        }
        public async Task DeleteProducts(int id)
        {
            await httpClient.DeleteAsync($"api/Customer/deleteCustomer/{id}");
        }
        public async Task<Products> GetProducts(int id)
        {
            return await httpClient.GetFromJsonAsync<Products>($"api/Products/{id}");
        }



        public async Task<HttpResponseMessage> UpdateProducts(int id, Products products)
        {
            return await httpClient.PutAsJsonAsync($"api/Products/{id}", products);
        }
    }
}
