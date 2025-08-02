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
            InitializeAsync();
        }
        public async Task<OpenSearchResult> SearchWiki()
        {
            WikiApiClient client = new WikiApiClient();
            return await client.SearchArticlesAsync(searchBox.Text);
        }
        public async Task Search()
        {
            var result = await SearchWiki();

            CardsPanel.Children.Clear();

            foreach (var item in result.Results)
            {
                ArticleCard card= new ArticleCard(item);
                card.FetchArticleClick += ReadArticle_ButtonClicked;
                CardsPanel.Children.Add(card);
            }
            return;
        }
        private void OnSearchTextKeydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Dispatcher.Invoke(() =>
                {
                    Search(); 
                });
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                Search();
            });
        }
        private void ReadArticle_ButtonClicked(object sender, RoutedEventArgs e)
        {
            if (sender is ArticleCard control && ArticleReader.CoreWebView2 != null)
            {
                Dispatcher.Invoke(() =>
                {
                    WikiApiClient wikiClient = new WikiApiClient();
                    WikiParseResult result = wikiClient.GetParsedArticlesAsync(control.Title).Result;
                    ArticleReader.NavigateToString(result.Parse.Text.HtmlContent);
                });
            }
        }
        async void InitializeAsync()
        {
            await ArticleReader.EnsureCoreWebView2Async(null);
        }
    }
}