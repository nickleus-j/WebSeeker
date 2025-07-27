using Seeker.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebWikiSeeker
{
    /// <summary>
    /// Interaction logic for ArticleCard.xaml
    /// </summary>
    public partial class ArticleCard : UserControl
    {
        protected OpenSearchItem Model { get; set; }
        public string Title => Model?.Title ?? String.Empty;
        public string ArticleUrl=> Model?.Url ?? String.Empty;
        public ArticleCard(OpenSearchItem _model = null)
        {
            if (_model == null)
            {
                Model = new OpenSearchItem();
            }
            else
            {
                Model = _model;
            }
            InitializeComponent();
            this.DataContext = Model;
            if (_model != null && !String.IsNullOrEmpty(Model.Description))
            {

            }
        }
        public static readonly RoutedEvent FetchArticleClickEvent =
        EventManager.RegisterRoutedEvent("FetchArticleClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ArticleCard));

        public event RoutedEventHandler FetchArticleClick
        {
            add { AddHandler(FetchArticleClickEvent, value); }
            remove { RemoveHandler(FetchArticleClickEvent, value); }
        }

        private void FetchArticle_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(FetchArticleClickEvent));
        }
    }
}
