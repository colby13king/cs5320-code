using System.Text.Json.Serialization;
using LicenseAssetManager.Infrastructure;

namespace LicenseAssetManager.Models
{

    /// <summary>
    /// Author:      John L Williams Jr
    /// Date:        11/25/2024
    /// Class Name:  SessionCart
    /// Description: subclasses the Cart class and override AddItem, RemoveLine, and Clear
    /// so they call the base implementation and then store the updates state in the session
    /// using the extension methods on the ISession interface
    /// </summary>

    public class SessionCart : Cart
    {

        [JsonIgnore]
        public ISession? Session { get; set; }


        /// <remarks>
        /// Author:      John L Williams Jr
        /// Date:        11/25/2024
        /// Method Name: GetCart
        /// Description: a factory for creating SessionCart objects and providing them with an ISession
        /// object so they can store themselves
        /// Arguments:   args
        /// </remarks>

        public static Cart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetJson("Cart", this);
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session?.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session?.Remove("Cart");
        }
    }
}
