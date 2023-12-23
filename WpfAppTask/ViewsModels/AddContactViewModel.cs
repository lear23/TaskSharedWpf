

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using TaskSharedWpf.Models;
using TaskSharedWpf.Services;

namespace WpfAppTask.ViewsModels;

 public partial class AddContactViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly ContactService _contactService;

    public AddContactViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;
    }

    [ObservableProperty]
    private Contact contact = new();

    [RelayCommand]
    private void Add()
    {

        _contactService.AddContact(Contact);

        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ListContactViewModel>();
    }


}
