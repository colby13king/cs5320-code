using System.Text.Json;

namespace LicenseAssetManager.Infrastructure
{
    public static class SessionExtensions
    {

        /// <remarks>
        /// Author:      John L Williams Jr
        /// Date:        10/30/2024
        /// Method Name: Set/Get Json
        /// Description: serialize objects into the JavaScript Object Notation format
        /// making it easy to store and retrieve Cart objects
        /// Arguments:   args
        /// </remarks>

        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null
                ? default(T)
                : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
