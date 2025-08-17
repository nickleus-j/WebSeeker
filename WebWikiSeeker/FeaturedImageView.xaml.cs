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
using Seeker.lib;

namespace WebWikiSeeker
{
    /// <summary>
    /// Interaction logic for FeaturedImageView.xaml
    /// </summary>
    public partial class FeaturedImageView : UserControl
    {
        protected FeaturedImage Model { get; set; }
        public string Title => Model?.Title ?? String.Empty;
        public string Source => Model?.Thumbnail?.Source ?? String.Empty;
        public string Description => Model?.Description?.Text ?? String.Empty;
        public FeaturedImageView(FeaturedImage _model = null)
        {
            if (_model == null)
            {
                Model = new FeaturedImage();
            }
            else
            {
                Model = _model;
            }
            InitializeComponent();
            this.DataContext = Model;
            if (_model != null && !String.IsNullOrEmpty(Model?.Description?.Text))
            {
                BitmapImage bitmapImage = new BitmapImage();

                // Begin initialization of the BitmapImage
                bitmapImage.BeginInit();

                // Set the UriSource to the web URL
                bitmapImage.UriSource = new Uri(Source);

                // Optional: Set DecodePixelWidth or DecodePixelHeight for memory optimization
                // bitmapImage.DecodePixelWidth = 200; 

                // End initialization of the BitmapImage
                bitmapImage.EndInit();

                // Set the Source of the Image element to the BitmapImage
                Img.Source = bitmapImage;
            }
        }
    }
}
