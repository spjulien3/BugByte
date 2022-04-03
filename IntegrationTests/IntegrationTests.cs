using API;
using API.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using API.Controllers;
using Microsoft.AspNetCore.Identity;
using API.Entities;
using Microsoft.AspNetCore.Http;
using API.DTOs;

namespace IntegrationTests;

public class IntegrationTests
{
    protected readonly HttpClient TestClient;

    public IntegrationTests()
    {
        var appFactory = new WebApplicationFactory<Startup>()
        .WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services => 
            {
                services.RemoveAll(typeof(DataContext));
                services.AddDbContext<DataContext>(options => {
                    options.UseInMemoryDatabase("TestDb");
                });
            });
        });
        TestClient = appFactory.CreateClient();
        

    }

    // public async void AuthenticateAsync()
    // {
    //     TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());

    // }

    // public async Task<string> GetJwtAsync()
    // {
    //     var response = await TestClient.PostAsJsonAsync("api/account/register", new 
    //     {
    //         UserName = "test",
    //         Password = "Pa$$w0rd"
            
    //     });

    //     var registrationResponse =  response.EnsureSuccessStatusCode();
    // }
}