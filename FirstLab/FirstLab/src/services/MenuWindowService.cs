using FirstLab.src.interfaces;
using FirstLab.src.utilities;
using FirstLab.src.controllers;
using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace FirstLab.src.services;

public class MenuWindowService : IMenuWindowService
{
    public MenuWindowService() { }

    public DoubleAnimation CreateElipseAnimation()
    {
        DoubleAnimation opacityAnimation = new()
        {
            From = 1.0,
            To = 0.1,
            Duration = TimeSpan.FromSeconds(2),
            AutoReverse = true,
            RepeatBehavior = RepeatBehavior.Forever
        };
        return opacityAnimation;
    }

    public void ShowMessage(string message)
    {
        MessageBox.Show(message);
    }

    public void CheckSenderOfTheButtonAndChangeView<T>(T someView, LogsView logsView, HomeView homeView, AnalyticsView analyticsView, string nameOfView)
    {
        if (someView is PlayWindow)
        {
            DateTime playWindowEndTime = DateTime.Now;
            logsView.CalculateAndCreateLog(homeView.flashcardOptionsView.playWindowStartTime, playWindowEndTime, homeView.flashcardOptionsView.flashcardSet);
            ViewsUtils.ChangeWindow(nameOfView, homeView);
            return;
        }
        else if (ViewsUtils.menuWindowReference!.contentControl.Content is FlashcardCustomization)
        {
            ShowMessage("There are unsaved changes!!");
            return;
        }

        if(nameOfView == "Menu")
        {
            ViewsUtils.ChangeWindow(nameOfView, homeView);
            return;
        }
        else if(nameOfView == "Logs")
        {
            ViewsUtils.ChangeWindow(nameOfView, logsView);
            return;
        }
        else if(nameOfView == "Analytics")
        {
            ViewsUtils.ChangeWindow(nameOfView, analyticsView);
            return;
        }
        throw new NotImplementedException($"nameOfView `{nameOfView}` is not implemented.");
    }

    public void InitializeViewsUtils(MenuWindow menuWindow)
    {
        ViewsUtils.menuWindowReference = menuWindow;
    }
}
