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
    /// Interaction logic for SearchCard.xaml
    /// </summary>
    public partial class SearchCard : UserControl
    {
        protected SearchItem Model { get; set; }
        public SearchCard(SearchItem _model = null)
        {
            if (_model == null)
            {
                Model = new SearchItem();
            }
            else
            {
                Model = _model;
            }
            InitializeComponent();
            this.DataContext = Model;
            if (_model != null && !String.IsNullOrEmpty(Model.Snippet))
            {
                
            }
        }
    }
}
