

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using TaskSharedWpf.Models;


namespace WpfAppTask.ViewsModels
{
    public partial class ListContactViewModel: ObservableObject
    {
        private readonly IServiceProvider _sp;

        public ListContactViewModel(IServiceProvider sp)
        {
            _sp = sp;
        }


        [ObservableProperty]
        private ObservableCollection<Contact> _contacts = [];

        [RelayCommand]

        public void NavigateToAdd()
        {
            var mainViewModel = _sp.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _sp.GetRequiredService<AddContactViewModel>();
        }
        [RelayCommand]

        public void NavigateToEdit()
        {
            var mainViewModel = _sp.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _sp.GetRequiredService<EditContactViewModel>();
        }
        [RelayCommand]

        public void Remove()
        {

        }
    }
}
