using System.Collections.ObjectModel;
using GNW.ILS.WPF.Models;

namespace GNW.ILS.WPF.ViewModels
{
    public class ClientListViewModel:ViewModelBase
    {
        private ObservableCollection<Client> _clientList;
        public ObservableCollection<Client> ClientList
        {
            get
            {
                return _clientList;
            }
            set
            {
                _clientList = value;
                NotifyPropertyChanged("ClientList");
            }
        }

        public ClientListViewModel()
        {
            ClientList=new ObservableCollection<Client>
            {
                new Client{Name = "Gayan"}
            };
        }
    }
}
