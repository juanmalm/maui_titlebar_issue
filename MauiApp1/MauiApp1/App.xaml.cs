using Microsoft.UI;
using Microsoft.UI.Windowing;
using WinRT.Interop;

namespace MauiApp1;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
#if WINDOWS
            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate();

            var windowHandle = WindowNative.GetWindowHandle(nativeWindow);
            var windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
            var appWindow = AppWindow.GetFromWindowId(windowId);
            var presenter = appWindow.Presenter as OverlappedPresenter;
            presenter.IsMaximizable = false;
            presenter.IsMinimizable = false;
            presenter.IsAlwaysOnTop = true;
            presenter.IsResizable = false;
            presenter.SetBorderAndTitleBar(false, false);
#endif
        });

        MainPage = new MainPage();
    }
}
