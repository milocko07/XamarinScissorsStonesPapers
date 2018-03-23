using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ScissorsStonesPapers
{
    public partial class MainMenuTabbedPage : TabbedPage
    {
        public MainMenuTabbedPage()
        {
            Children.Add(new GamePage() { Title = "The Game", Icon = "game.png" });
            //Children.Add(new ControlsSamplePage() { Title = "Controls", Icon = "controls.png" });
        }
    }
}
