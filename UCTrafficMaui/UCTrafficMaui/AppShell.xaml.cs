using UCTrafficMaui.Pages;

namespace UCTrafficMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register navigation routes
        Routing.RegisterRoute(nameof(ProfileInfoPage), typeof(ProfileInfoPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
        Routing.RegisterRoute(nameof(ReportIssuePage), typeof(ReportIssuePage));
        Routing.RegisterRoute(nameof(ReportIssueThanksPage), typeof(ReportIssueThanksPage));

    }
}
