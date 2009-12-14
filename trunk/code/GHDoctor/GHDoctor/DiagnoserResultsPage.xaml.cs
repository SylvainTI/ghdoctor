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
using System.Windows.Browser;

namespace GHDoctor
{
    public partial class DiagnoserResultsPage : Page
    {
        private String siteUrl;
        private IEnumerable<Category> categories;
        private List<CommonQuery> queries = new List<CommonQuery>();
        private int queriesCount;

        private long modelSvcResultsToObtain = 0;
        private long queriesResultsObtained = 0;
        private long getNumberOfResultsForSiteSearchCalled = 0;
        private bool willClose = false;

        private ModelServicesSoapClient modelSvc;

        SearchEngineServiceSoapClient svcClient;


        public DiagnoserResultsPage(String url, IEnumerable<Category> categories)
        {
            InitializeComponent();

            this.siteUrl = url;
            this.categories = categories;

            svcClient = new SearchEngineServiceSoapClient();
            svcClient.GetNumberOfResultsForSiteSearchCompleted += new EventHandler<GetNumberOfResultsForSiteSearchCompletedEventArgs>(svcClient_GetNumberOfResultsForSiteSearchCompleted);

            modelSvc = new ModelServicesSoapClient();
            modelSvc.GetCommonQueriesCompleted += new EventHandler<GetCommonQueriesCompletedEventArgs>(modelSvc_GetCommonQueriesCompleted);

            modelSvcResultsToObtain = categories.Count();

            AddCategoriesToResultsView();

            foreach (Category category in categories)
            {
                if (willClose)
                {
                    return;
                }
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
                        queriesCount = queries.Count;
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

            if (willClose)
            {
                return;
            }

            if (query == null)
            {
                svcClient_GetNumberOfResultsForSiteSearchCompleted(this, null);
                return;
            }

            if (query.SearchString.Contains("site"))
            {
                // skip the query, it's not useful for the diagnoser
                CallSearchEngine();
            }
            else
            {
                svcClient.GetNumberOfResultsForSiteSearchAsync(query.SearchString, siteUrl, query);
                if (queries.Count == 0)
                {
                    svcClient_GetNumberOfResultsForSiteSearchCompleted(this, null);
                }
            }
        }

        private void svcClient_GetNumberOfResultsForSiteSearchCompleted(object sender, GetNumberOfResultsForSiteSearchCompletedEventArgs e)
        {
            lock (this)
            {
                if (willClose)
                {
                    return;
                }

                if (queries.Count > 0)
                {
                    CommonQuery query = (CommonQuery)e.UserState;
                    
                    getNumberOfResultsForSiteSearchCalled += 1;

                    if (e.Result > 0)
                    {
                        queriesResultsObtained += 1;
                        AddResultToTreeView(query, e.Result);
                    }


                    Decimal percentageCompleted = new Decimal(100*((float)getNumberOfResultsForSiteSearchCalled / (float)queriesCount));

                    if (queriesResultsObtained == 1 )
                        ThreatsFoundTxt.Text = "Buscando...\n" + queriesResultsObtained + " amenaza encontrada - " + percentageCompleted.ToString(@"0.00") + "% completado";
                    else
                        ThreatsFoundTxt.Text = "Buscando...\n" + queriesResultsObtained + " amenazas encontradas - " + percentageCompleted.ToString(@"0.00") + "% completado";

                    CallSearchEngine();

                }
                else
                {
                    // DONE
                    if (queriesResultsObtained == 1)
                        ThreatsFoundTxt.Text = "Se ha encontrado " + queriesResultsObtained + " amenaza";
                    else
                        ThreatsFoundTxt.Text = "Se han encontrado " + queriesResultsObtained + " amenazas";
                }
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this._contentLoaded)
            {
                willClose = true;
                /*
                modelSvc.CloseAsync();
                svcClient.CloseAsync();
                 */

                Grid mainView = (Grid)App.Current.RootVisual;
                mainView.Children.Clear();
                mainView.Children.Add(new MainPage());
            }
        }

        private void GoBackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this._contentLoaded)
            {
                willClose = true;
                /*
                modelSvc.CloseAsync();
                svcClient.CloseAsync();
                 */

                Grid mainView = (Grid)App.Current.RootVisual;
                mainView.Children.Clear();
                mainView.Children.Add(new DiagnoserPage());
            }
        }

        private void AddCategoriesToResultsView()
        {
            foreach (Category category in categories)
            {
                TreeViewItem item = new TreeViewItem();
                item.DataContext = category;

                DescriptiveTreeViewItem catItem = new DescriptiveTreeViewItem();
                catItem.HeaderTb.Text = category.LongDescription;
                catItem.Width = ResultsTreeView.Width*.75;
                item.Items.Add(catItem);

                UpdateCategoriesItemHeader(item);
                ResultsTreeView.Items.Add(item);
            }
        }

        private void UpdateCategoriesItemHeader(TreeViewItem item)
        {
            Category category = (Category)item.DataContext;
            if ((item.Items.Count() - 1) == 1)
                item.Header = category.ShortDescription + " - " + (item.Items.Count() - 1) + " amenaza";
            else
                item.Header = category.ShortDescription + " - " + (item.Items.Count() - 1) + " amenazas";
        }

        private void AddResultToTreeView(CommonQuery query, long qty)
        {
            Category category = query.Category;

            foreach (TreeViewItem item in ResultsTreeView.Items)
            {
                Category itemCat = (Category)item.DataContext;
                if (category.Code == itemCat.Code)
                {
                    TreeViewItem subItem = new TreeViewItem();
                    subItem.Header = query.ShortDescription;
                    subItem.DataContext = query;

                    DescriptiveTreeViewItem desItem = new DescriptiveTreeViewItem();
                    desItem.HeaderTb.Text = query.Description;
                    desItem.Width = ResultsTreeView.Width * .75;

                    // TODO es medio pesado reconstruir la query aca, pero bueh
                    desItem.SearchUri = new Uri("http://www.google.com/search?q=" + HttpUtility.UrlEncode("site:") + HttpUtility.UrlEncode(siteUrl) + HttpUtility.UrlEncode(" " + query.SearchString));
                    
                    desItem.HyperlinkTb.Text = "Google!";
                    subItem.Items.Add(desItem);

                    item.Items.Add(subItem);
                }

                UpdateCategoriesItemHeader(item);
            }
        }
    }
}
