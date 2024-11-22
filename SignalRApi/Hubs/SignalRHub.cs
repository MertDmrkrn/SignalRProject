using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub //Hub burada sunucu görevi görecek. Bizim dağıtım işlemimiz hub sınıfı hangisi ise onun üzerinden sağlayacağız.
    {
        SignalRContext context = new SignalRContext();

        public async Task SendCategoryCount()
        {
            var value = context.Categories.Count();
            await Clients.All.SendAsync("ReceiverCategoryCount", value);

        }
    }
}
