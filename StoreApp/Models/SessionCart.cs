using Entities.Models;
using StoreApp.Infrastructe.Extensions;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace StoreApp.Models
{
    public class SessionCart :Cart
    {
        [JsonIgnore]
        public ISession? session { get; set; }


        public static Cart GetCart(IServiceProvider serviceProvider)
        {
            ISession? session = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();
            cart.session = session;
            return cart;
        }
        public override void AddCartLine(Product product, int quantity)
        {
            base.AddCartLine(product, quantity);
            session?.SetJson<SessionCart>("cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            session?.Remove("cart");
        }
        public override void RemoveCartLine(Product product)
        {
            base.RemoveCartLine(product);
            session?.SetJson<SessionCart>("cart", this);
        }
    }
}
