

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using TaskSharedWpf.Models;

namespace WpfAppTask.ViewsModels;

 public partial class AddContactViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;

    public AddContactViewModel(IServiceProvider sp)
    {
        _sp = sp;
    }

    [ObservableProperty]
    private Contact contact = new();

    [RelayCommand]
    private void Add()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ListContactViewModel>();
    }


}
