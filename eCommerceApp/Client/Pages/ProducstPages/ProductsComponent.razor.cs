using eCommerceApp.Shared.Models;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace eCommerceApp.Client.Pages.ProducstPages
{
    public partial class ProductsComponent
    {
        Products products = new Products();
        List<Products> productsList;
        RadzenDataGrid<Products> grid;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                await GetProducts();
            }
            catch (Exception)
            {

            }
        }

        async Task GetProducts()
        {
            productsList = await http.GetFromJsonAsync<List<Products>>($"api/Products");
            await grid.Reload();
        }


        async Task PostProducts()
        {
            string json = JsonConvert.SerializeObject(products);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var responses = await http.PostAsync("api/Products", httpContent);
            var respuesta = await responses.Content.ReadFromJsonAsync<ProducstResponse>();
            if (respuesta.ok)
            {
                await Js.InvokeAsync<object>("Estado", "Exito", $"{respuesta.msj}", "success");
                await GetProducts();
            }
            else
            {
                await Js.InvokeAsync<object>("Estado", "Oops...", $"{respuesta.msj}", "error");
            }
        }
    }
}
