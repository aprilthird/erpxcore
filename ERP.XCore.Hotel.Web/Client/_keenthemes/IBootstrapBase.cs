using ERP.XCore.Hotel.Web.Client._keenthemes.libs;

namespace ERP.XCore.Hotel.Web.Client._keenthemes;

public interface IBootstrapBase
{
    void initThemeMode();
    
    void initThemeDirection();
    
    void initRtl();

    void initLayout();

    void init(IKTTheme theme);
}