

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using TaskSharedWpf.Models;

namespace WpfAppTask.ViewsModels;

public partial class EditContactViewModel : ObservableObject
{

    private readonly IServiceProvider _sp;

    public EditContactViewModel(IServiceProvider sp)
    {
        _sp = sp;
    }

    [ObservableProperty]
    private Contact contact = new();

    [RelayCommand]
    private void Update()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ListContactViewModel>();
    }

}
