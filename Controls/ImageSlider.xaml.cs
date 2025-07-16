using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PlantillaWPF.Controls
{
    public partial class ImageSlider : UserControl
    {
        private List<string> _imagePaths = new List<string>();
        private int _currentIndex = 0;

        public ImageSlider()
        {
            InitializeComponent();
        }

        public void SetImages(List<string> imagePaths)
        {
            _imagePaths = imagePaths;
            _currentIndex = 0;
            ShowImage();
        }

        private void ShowImage()
        {
            if (_imagePaths.Count > 0 && _currentIndex >= 0 && _currentIndex < _imagePaths.Count)
            {
                ImageDisplay.Source = new BitmapImage(new System.Uri(_imagePaths[_currentIndex], System.UriKind.RelativeOrAbsolute));
            }
            else
            {
                ImageDisplay.Source = null;
            }
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            if (_imagePaths.Count == 0) return;
            _currentIndex = (_currentIndex - 1 + _imagePaths.Count) % _imagePaths.Count;
            ShowImage();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (_imagePaths.Count == 0) return;
            _currentIndex = (_currentIndex + 1) % _imagePaths.Count;
            ShowImage();
        }
    }
} 