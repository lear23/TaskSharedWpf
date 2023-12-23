

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using TaskSharedWpf.Models;
using TaskSharedWpf.Services;

namespace WpfAppTask.ViewsModels;

public partial class EditContactViewModel : ObservableObject
{

    private readonly IServiceProvider _sp;
    private readonly ContactService _contactService;



    public EditContactViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;

        Contact = _contactService.currentContact;
    }

    [ObservableProperty]
    private Contact contact = new();

    [RelayCommand]
    private void Update()
    {
        _contactService.Update(contact);

        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ListContactViewModel>();
    }

}
