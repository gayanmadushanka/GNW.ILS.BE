using GNW.ILS.WPF.Models;

namespace GNW.ILS.WPF.ViewModels
{
    public class ClientViewModel:ViewModelBase
    {
        private Client _client;
        public Client Client
        {
            get
            {
                return _client;
            }
            set
            {
                _client = value;
                NotifyPropertyChanged("Client");
            }
        }
    }
}
