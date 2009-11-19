using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace GHDoctor
{
    public partial class WebSearchPageResults : Page
    {
        public WebSearchPageResults()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Grid mainView = (Grid)App.Current.RootVisual;
            mainView.Children.Clear();
            mainView.Children.Add(new MainPage());
        }
    }
}
