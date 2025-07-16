using PlantillaWPF.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace PlantillaWPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly NavigationService _navigationService;
        private bool _isLoading;

        public MainViewModel()
        {
            _navigationService = new NavigationService();
            IsLoading = true;
            Task.Delay(2000).ContinueWith(_ =>
            {
                IsLoading = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public UserControl CurrentView
        {
            get => _navigationService.CurrentView;
            set
            {
                _navigationService.CurrentView = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged();
                }
            }
        }

        public NavigationService Navigation => _navigationService;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 