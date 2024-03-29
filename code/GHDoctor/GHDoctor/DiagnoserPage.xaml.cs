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
using System.Text.RegularExpressions;

namespace GHDoctor
{
    public partial class DiagnoserPage : Page
    {
        public DiagnoserPage()
        {
            InitializeComponent();

            ModelServicesSoapClient svc = new ModelServicesSoapClient();
            svc.GetAllCategoriesCompleted += new EventHandler<GetAllCategoriesCompletedEventArgs>(svc_GetAllCategoriesCompleted);
            svc.GetAllCategoriesAsync();

            ErrorMsgTxt.Visibility = Visibility.Collapsed;
            
        }

        void svc_GetAllCategoriesCompleted(object sender, GetAllCategoriesCompletedEventArgs e)
        {
            QueryTypes.ItemsSource = e.Result;
            QueryTypes.DisplayMemberPath = "ShortDescription";
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

        private void Diagnose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this._contentLoaded)
            {
                if (QueryTypes.SelectedItems.Count == 0)
                {
                    ErrorMsgTxt.Text = "Seleccione al menos una categoria para la búsqueda";
                    ErrorMsgTxt.Visibility = Visibility.Visible;
                }
                else if (!ValidateURL(UrlTxt.Text))
                {
                    ErrorMsgTxt.Text = "Por favor, ingrese una URL válida";
                    ErrorMsgTxt.Visibility = Visibility.Visible;
                }
                else
                {
                    ErrorMsgTxt.Visibility = Visibility.Collapsed;

                    Grid mainView = (Grid)App.Current.RootVisual;
                    mainView.Children.Clear();

                    List<Category> selectedCategories = new List<Category>();
                    foreach (Category category in QueryTypes.SelectedItems)
                    {   
                        selectedCategories.Add(category);
                    }

                    mainView.Children.Add(new DiagnoserResultsPage(UrlTxt.Text, selectedCategories));
                }
            }
        }

        private bool ValidateURL(String url)
        {
            Regex regex = new Regex(@"(?:https?|ftp)://[-a-zA-Z0-9.]+(:(6553[0-5]|655[0-2][0-9]|65[0-4][0-9][0-9]|6[0-4][0-9][0-9][0-9]|\d{2,4}|[1-9]))?");
            return (regex.IsMatch(url));
        }

        private void SelectAllQueries_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (Category category in QueryTypes.Items)
            {
                QueryTypes.SelectedItems.Add(category);
            }
        }

        private void QueryTypes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
			    if (QueryTypes.SelectedItems.Count > 0)
                {
		        	ErrorMsgTxt.Visibility = Visibility.Collapsed;
				}
        }
    }
}
