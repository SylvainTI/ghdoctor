﻿using System;
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

namespace GHDoctor
{
    public partial class WebSearchPage : Page
    {
        ModelServicesSoapClient modelServicesClient = new ModelServicesSoapClient();

        public WebSearchPage()
        {
            InitializeComponent();

            categories.SelectionChanged += new SelectionChangedEventHandler(categories_SelectionChanged);
            queries.IsEnabled = false;

            modelServicesClient.GetAllCategoriesCompleted +=
                new EventHandler<GetAllCategoriesCompletedEventArgs>(modelServicesClient_GetAllCategoriesCompleted);
            modelServicesClient.GetAllCategoriesAsync();
        }

        private void categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category selectedCategory = (Category)categories.SelectedItem;
            modelServicesClient.GetCommonQueriesCompleted += new EventHandler<GetCommonQueriesCompletedEventArgs>(modelServicesClient_GetCommonQueriesCompleted);
            modelServicesClient.GetCommonQueriesAsync(selectedCategory.Code);
        }

        private void modelServicesClient_GetCommonQueriesCompleted(object sender, GetCommonQueriesCompletedEventArgs e)
        {
            if (e.Result.Count > 0)
            {
                IList<CommonQuery> cqs = e.Result;
                queries.ItemsSource = cqs;
                queries.DisplayMemberPath = "SearchString";

                queries.IsEnabled = true;
            }
        }

        private void modelServicesClient_GetAllCategoriesCompleted(object sender, GetAllCategoriesCompletedEventArgs e)
        {
            IList<Category> cs = e.Result;
            categories.ItemsSource = cs;
            categories.DisplayMemberPath = "ShortDescription";
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

		private void Buscar_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            Grid mainView = (Grid)App.Current.RootVisual;
            mainView.Children.Clear();
            mainView.Children.Add(new WebSearchPageResults());
		}
    }
}
