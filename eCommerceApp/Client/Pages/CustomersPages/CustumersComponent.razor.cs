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

namespace eCommerceApp.Client.Pages.CustomersPages
{
    public partial class CustumersComponent
    {
        Customers customers = new Customers();
        List<Customers> customersList;
        RadzenDataGrid<Customers> grid;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                await GetCustomers();
            }
            catch (Exception)
            {

            }
        }

        async Task GetCustomers()
        {
            customersList = await http.GetFromJsonAsync<List<Customers>>($"api/Customers");
            await grid.Reload();
        }


        async Task PostCustomers()
        {
            string json = JsonConvert.SerializeObject(customers);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var responses = await http.PostAsync("api/Customers", httpContent);
            var respuesta = await responses.Content.ReadFromJsonAsync<CustomersResponse>();
            if (respuesta.ok)
            {
                await Js.InvokeAsync<object>("Estado", "Exito", $"{respuesta.msj}", "success");
                await GetCustomers();
            }
            else
            {
                await Js.InvokeAsync<object>("Estado", "Oops...", $"{respuesta.msj}", "error");
            }
        }
    }
}
