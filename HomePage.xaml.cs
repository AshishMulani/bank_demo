using System;
using Microsoft.Maui.Controls;

namespace bank_demo
{


public partial class HomePage : ContentPage
{
    private const uint DrawerAnimationDuration = 250;
    private const double DrawerWidth = 300;
    public HomePage()
    {
        InitializeComponent();

        MenuDrawer.TranslationX = -DrawerWidth;
        MenuDrawer.Opacity = 0;
        MenuDrawer.InputTransparent = true;
        MenuOverlay.IsVisible = false;
        }

        private async void OnHamburgerClicked(object sender, EventArgs e)
        {
            MenuOverlay.IsVisible = true;
            MenuDrawer.InputTransparent = false;
            MenuDrawer.IsVisible = true;

            await MenuDrawer.TranslateTo(0, 0, DrawerAnimationDuration, Easing.CubicOut);
            await MenuDrawer.FadeTo(1, DrawerAnimationDuration, Easing.CubicOut);

            if (BindingContext is ViewModels.HomeViewModel vm)
            {
                vm.IsMenuVisible = true;
            }
        }

        private async void OnOverlayTapped(object sender, EventArgs e)
        {
            await MenuDrawer.TranslateTo(-DrawerWidth, 0, DrawerAnimationDuration, Easing.CubicIn);
            await MenuDrawer.FadeTo(0, DrawerAnimationDuration, Easing.CubicIn);

            MenuDrawer.InputTransparent = true;
            MenuOverlay.IsVisible = false;

            if (BindingContext is ViewModels.HomeViewModel vm)
            {
                vm.IsMenuVisible = false;
            }
        }

    }

}

