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
        private long searchEngineSvcResultsToObtain = 0;
        private long queriesResultsObtained = 0;

        private ModelServicesSoapClient modelSvc;

        SearchEngineServiceSoapClient svcClient;


        public DiagnoserResultsPage(String url, IEnumerable<Category> categories)
        {
            svcClient = new SearchEngineServiceSoapClient();
            svcClient.GetNumberOfResultsForSearchCompleted += new EventHandler<GetNumberOfResultsForSearchCompletedEventArgs>(svcClient_GetNumberOfResultsForSearchCompleted);

            InitializeComponent();

            this.url = url;
            this.categories = categories;

            modelSvc = new ModelServicesSoapClient();
            modelSvc.GetCommonQueriesCompleted += new EventHandler<GetCommonQueriesCompletedEventArgs>(modelSvc_GetCommonQueriesCompleted);

            foreach (Category category in categories)
            {
                modelSvcResultsToObtain += 1;
                modelSvc.GetCommonQueriesAsync(category.Code);
            }
            
        }

        void modelSvc_GetCommonQueriesCompleted(object sender, GetCommonQueriesCompletedEventArgs e)
        {
            lock (this)
            {
                modelSvcResultsToObtain -= 1;
                queries.AddRange(e.Result);
                if (modelSvcResultsToObtain == 0)
                {
                    searchEngineSvcResultsToObtain += queries.Count;
                    foreach (CommonQuery query in queries)
                    {/*
                        SearchEngineServiceSoapClient seSvc = new SearchEngineServiceSoapClient();
                        seSvc.GetNumberOfResultsForSiteSearchCompleted += new EventHandler<GetNumberOfResultsForSiteSearchCompletedEventArgs>(seSvc_GetNumberOfResultsForSiteSearchCompleted);

                        seSvc.GetNumberOfResultsForSiteSearchAsync(query.SearchString, url);
                        */
                        svcClient.GetNumberOfResultsForSearchAsync(query.SearchString + " site: " + url, query);
                       
                        //break;
                    }
                    
                    // done...
                }
            }
        }

        private void svcClient_GetNumberOfResultsForSearchCompleted(object sender, GetNumberOfResultsForSearchCompletedEventArgs e)
        {
            lock (this)
            {
                CommonQuery query = (CommonQuery)e.UserState;
                queriesResultsObtained += e.Result;
                searchEngineSvcResultsToObtain -= queriesResultsObtained;

                ThreatsFoundTxt.Text = "Buscando... (" + queriesResultsObtained + " amenazas encontradas)";

                if (searchEngineSvcResultsToObtain == 0)
                {
                    ThreatsFoundTxt.Text = "Se han encontrado " + queriesResultsObtained + " amenazas";
                    // DONE
                }
            }
        }


        void seSvc_GetNumberOfResultsForSiteSearchCompleted(object sender, GetNumberOfResultsForSiteSearchCompletedEventArgs e)
        {
            lock (this)
            {
                CommonQuery query = (CommonQuery)e.UserState;
                queriesResultsObtained += e.Result;
                searchEngineSvcResultsToObtain -= queriesResultsObtained;

                ThreatsFoundTxt.Text = "Buscando... (se han encontrado " + queriesResultsObtained + " amenazas)";

                if (searchEngineSvcResultsToObtain == 0)
                {
                    ThreatsFoundTxt.Text = "Se han encontrado " + queriesResultsObtained + " amenazas";
                    // DONE
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
