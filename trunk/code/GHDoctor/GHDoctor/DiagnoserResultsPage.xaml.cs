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
using GHDoctor.ModelServicesReference;
using GHDoctor.SearchEngineService;
using System.Threading;

namespace GHDoctor
{
    public partial class DiagnoserResultsPage : Page
    {
        private String url;
        private IEnumerable<Category> categories;
        private List<CommonQuery> queries = new List<CommonQuery>();


        private long modelSvcResultsToObtain = 0;
        private long queriesResultsObtained = 0;

        private ModelServicesSoapClient modelSvc;

        SearchEngineServiceSoapClient svcClient;


        public DiagnoserResultsPage(String url, IEnumerable<Category> categories)
        {
            InitializeComponent();

            this.url = url;
            this.categories = categories;

            svcClient = new SearchEngineServiceSoapClient();
            svcClient.GetNumberOfResultsForSiteSearchCompleted += new EventHandler<GetNumberOfResultsForSiteSearchCompletedEventArgs>(svcClient_GetNumberOfResultsForSiteSearchCompleted);

            modelSvc = new ModelServicesSoapClient();
            modelSvc.GetCommonQueriesCompleted += new EventHandler<GetCommonQueriesCompletedEventArgs>(modelSvc_GetCommonQueriesCompleted);

            foreach (Category category in categories)
            {
                modelSvcResultsToObtain += 1;
                modelSvc.GetCommonQueriesAsync(category.Code);
            }
            
        }

        private void modelSvc_GetCommonQueriesCompleted(object sender, GetCommonQueriesCompletedEventArgs e)
        {
            lock (this)
            {
                modelSvcResultsToObtain -= 1;
                queries.AddRange(e.Result);
                if (modelSvcResultsToObtain == 0)
                {
                    // done
                    if (queries.Count > 0)
                    {
                        CallSearchEngine();
                    }
                    else
                    {
                        // TODO: que hacer?
                    }
                }
            }
        }

        private void CallSearchEngine()
        {
            CommonQuery query = queries.FirstOrDefault();
            queries.Remove(query);

            if (query.SearchString.Contains("site"))
            {
                CallSearchEngine();
                return;
            }

            try
            {
                svcClient.GetNumberOfResultsForSiteSearchAsync(query.SearchString, url, query);
            }
            catch (Exception)
            {
                if (queries.Count > 0)
                {
                    CallSearchEngine();
                }
                else
                {
                    svcClient_GetNumberOfResultsForSiteSearchCompleted(this, null);
                }
            }
        }

        private void svcClient_GetNumberOfResultsForSiteSearchCompleted(object sender, GetNumberOfResultsForSiteSearchCompletedEventArgs e)
        {
            lock (this)
            {
                if (queries.Count > 0)
                {
                    CommonQuery query = (CommonQuery)e.UserState;
                    queriesResultsObtained += e.Result;
                    ThreatsFoundTxt.Text = "Buscando... (" + queriesResultsObtained + " amenazas encontradas)";
                    CallSearchEngine();
                }
                else
                {
                    // DONE
                    ThreatsFoundTxt.Text = "Se han encontrado " + queriesResultsObtained + " amenazas";
                }
            }
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

        private void GoBackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this._contentLoaded)
            {
                Grid mainView = (Grid)App.Current.RootVisual;
                mainView.Children.Clear();
                mainView.Children.Add(new DiagnoserPage());
            }
        }
    }
}
