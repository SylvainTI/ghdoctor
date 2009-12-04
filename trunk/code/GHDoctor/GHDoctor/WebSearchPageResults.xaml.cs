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
using GHDoctor.SearchEngineService;

namespace GHDoctor
{
    public partial class WebSearchPageResults : Page
    {
        String searchString;
        public WebSearchPageResults(String searchString)
        {
            this.searchString = searchString;
            InitializeComponent();

            SearchEngineServiceSoapClient svcClient = new SearchEngineServiceSoapClient();
            svcClient.GetNumberOfResultsForSearchCompleted += new EventHandler<GetNumberOfResultsForSearchCompletedEventArgs>(svcClient_GetNumberOfResultsForSearchCompleted);
            svcClient.GetNumberOfResultsForSearchAsync(searchString);
            
        }

        private void svcClient_GetNumberOfResultsForSearchCompleted(object sender, GetNumberOfResultsForSearchCompletedEventArgs e)
        {
            long cantResults = e.Result;
            ResultsSummaryLbl.Text = "Se han encontrado aproximadamente " + cantResults + " resultados!";
        }

  		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this._contentLoaded)
            {
                Grid mainView = (Grid)App.Current.RootVisual;
                mainView.Children.Clear();
                mainView.Children.Add(new MainPage());
            }
        }

		private void GotoWebPage_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            if (this._contentLoaded)
            {
			    System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("http://www.google.com/search?q=" + searchString), "_newWindow", "toolbar=1,menubar=1,resizable=1,scrollbars=1,top=0,left=0");
            }
		}

		private void VolverBtn_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (this._contentLoaded)
            {
                Grid mainView = (Grid)App.Current.RootVisual;
                mainView.Children.Clear();
                mainView.Children.Add(new WebSearchPage());
            }
		}
    }
}
