using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Text.Json.Serialization;

namespace ERP.XCore.Hotel.Web.Client.Extensions
{
    public class ApplicationUserAccount : RemoteUserAccount
    {
        [JsonPropertyName("amr")]
        public string[] Modules { get; set; }
    }
}
