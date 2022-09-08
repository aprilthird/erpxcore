using ERP.XCore.Hotel.Web.Client._keenthemes.libs;

namespace ERP.XCore.Hotel.Web.Client._keenthemes;

public class BootstrapBase: IBootstrapBase {
    private IKTTheme _theme;

    // Init theme mode option from settings
    public void initThemeMode()
    {
        _theme.setModeSwitch(KTThemeSettings.config.ModeSwitchEnabled);
        _theme.setModeDefault(KTThemeSettings.config.ModeDefault);
    }
 
    // Init theme direction option (RTL or LTR) from settings
    public void initThemeDirection()
    {
        _theme.setDirection(KTThemeSettings.config.Direction);
    }

    // Init RTL html attributes by checking if RTL is enabled.
    // This function is being called for the html tag
    public void initRtl()
    {
        if (_theme.isRtlDirection())
        {
            _theme.addHtmlAttribute("html", "direction", "rtl");
            _theme.addHtmlAttribute("html", "dir", "rtl");
            _theme.addHtmlAttribute("html", "style", "direction: rtl");
        }
    }

    // Init layout
    public void initLayout()
    {
        _theme.addHtmlAttribute("body", "id", "kt_app_body");
        _theme.addHtmlAttribute("body", "data-kt-app-page-loading", "on");
    }

    // Global theme initializer
    public void init(IKTTheme theme)
    {
        _theme = theme;

        initThemeMode();
        initThemeDirection();
        initRtl();
        initLayout();
    }
}
