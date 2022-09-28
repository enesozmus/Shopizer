using Microsoft.AspNetCore.Builder;
using SignalR.Hubs;

namespace SignalR.HubMapRegistrations;

public static class HubRegistration
{
    public static void MapHubs(this WebApplication webApplication)
    {
        webApplication.MapHub<ProductHub>("/products-hub");
    }
}
