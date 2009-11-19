using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace GHDoctor
{
	public partial class MainPage : Page
	{
		public MainPage()
		{
			// Required to initialize variables
			InitializeComponent();
            
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            Grid mainView = (Grid)App.Current.RootVisual;
            mainView.Children.Clear();
            mainView.Children.Add(new AboutPage());
		}
		
		private void WebSearch_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            Grid mainView = (Grid)App.Current.RootVisual;
            mainView.Children.Clear();
            mainView.Children.Add(new WebSearchPage());
		}

		private void Diagnoser_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            Grid mainView = (Grid)App.Current.RootVisual;
            mainView.Children.Clear();
            mainView.Children.Add(new DiagnoserPage());
		}
	}
}