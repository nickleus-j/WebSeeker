using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Seeker.lib;

namespace WebWikiSeeker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public WikipediaSearchResult SearchWiki()
        {
            WikiApiClient client = new WikiApiClient();
            return client.SearchForArticleAsync(searchBox.Text).Result;
        }
        public void Search()
        {
            var result = SearchWiki();

            CardsPanel.Children.Clear();

            foreach (var item in result.Query.Search)
            {
                SearchCard card= new SearchCard(item);
                CardsPanel.Children.Add(card);
            }
        }
        private void OnSearchTextKeydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Search();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }
    }
}