using FirstLab.src.interfaces;
using FirstLab.src.utilities;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace FirstLab.src.controllers;

public partial class MenuWindow : Window
{
    private HomeView homeView;

    private LogsView logsView;

    private AnalyticsView analyticsView;

    private ControlsView controlsView;

    private IMenuWindowService _menuWindowService;

    public MenuWindow(HomeView homeView, LogsView logsView, AnalyticsView analyticsView, IFactoryContainer factoryContainer, IMenuWindowService menuWindowService, ControlsView controlsView)
    {
        InitializeComponent();
        InitializeMenuFields(homeView,logsView, analyticsView, factoryContainer, menuWindowService, controlsView);
        InitializeAnimation();
    }

    private void InitializeMenuFields(HomeView homeView, LogsView logsView, AnalyticsView analyticsView, IFactoryContainer factoryContainer,
        IMenuWindowService menuWindowService, ControlsView controlsView)
    {
        this.homeView = homeView;
        _menuWindowService = menuWindowService;
        contentControl.Content = homeView;
        this.logsView = logsView;
        this.analyticsView = analyticsView;
        this.controlsView = controlsView;
        _menuWindowService.InitializeViewsUtils(this);
    }

    private void InitializeAnimation()
    {
        breathingEllipse.BeginAnimation(Ellipse.OpacityProperty, _menuWindowService.CreateElipseAnimation());
    }

    private void MovingWindow(object sender, MouseButtonEventArgs e)
    {
        if(e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }

    public void ReturnToHomeView_Click(object? sender = null, RoutedEventArgs? e = null)
    {
        _menuWindowService.CheckSenderOfTheButtonAndChangeView(sender, logsView, homeView, analyticsView, "Menu");
    }

    private void CloseWindow_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void AccessLogs_Click(object sender, RoutedEventArgs e)
    {
        _menuWindowService.CheckSenderOfTheButtonAndChangeView(sender, logsView, homeView, analyticsView, "Logs");
    }

    private void AccessAnalytics_Click(object sender, RoutedEventArgs e)
    {
        _menuWindowService.CheckSenderOfTheButtonAndChangeView(sender, logsView, homeView, analyticsView, "Analytics");
        analyticsView.InitializeAnalyticsTask();
    }

    private void Controls_Click(object sender, RoutedEventArgs e)
    {
        ViewsUtils.ChangeWindow("Controls", controlsView);
    }
}
