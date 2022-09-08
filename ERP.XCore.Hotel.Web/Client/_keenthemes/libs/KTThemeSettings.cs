namespace ERP.XCore.Hotel.Web.Client._keenthemes.libs;

class KTThemeSettings
{
    public static KTThemeBase config;

    public static void init(IConfiguration configuration)
    {
        config = configuration.GetSection("Kt").Get<KTThemeBase>();
    }
}
