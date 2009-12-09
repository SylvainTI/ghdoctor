using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace GHDoctor
{
	public partial class DescriptiveTreeViewItem : UserControl
	{
		private Uri searchUri;

        public Uri SearchUri
		{
			get 
			{
				return searchUri;
			}
			set
			{
				this.searchUri = value;
			}
		}
		
		public DescriptiveTreeViewItem()
		{
			// Required to initialize variables
			InitializeComponent();
		}

		private void HyperlinkTb_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			if (this._contentLoaded)
            {   
			    System.Windows.Browser.HtmlPage.Window.Navigate(searchUri, "_newWindow");
            }
		}
	}
}