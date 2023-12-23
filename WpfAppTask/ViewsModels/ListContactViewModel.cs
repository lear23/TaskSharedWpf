

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using TaskSharedWpf.Models;
using TaskSharedWpf.Services;


namespace WpfAppTask.ViewsModels
{
    public partial class ListContactViewModel: ObservableObject
    {
        private readonly IServiceProvider _sp;
        private readonly ContactService _contactService;

        public ListContactViewModel(IServiceProvider sp, ContactService contactService)
        {
            _sp = sp;
            _contactService = contactService;

            _contacts = new ObservableCollection<Contact>(_contactService.GetContactsFromList());
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

        public void NavigateToEdit(Contact contact)
        {
            _contactService.currentContact = contact;

            var mainViewModel = _sp.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _sp.GetRequiredService<EditContactViewModel>();
        }
        [RelayCommand]

        public void Remove(Contact contact)
        {
             _contactService.Remove(contact);
            Contacts = new ObservableCollection<Contact>(_contactService.GetContactsFromList());

        }
    }
}
