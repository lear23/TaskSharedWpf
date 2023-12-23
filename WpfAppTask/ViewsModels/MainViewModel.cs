
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace WpfAppTask.ViewsModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IServiceProvider _sp;

        public MainViewModel(IServiceProvider sp)
        {
            _sp = sp;
            CurrentViewModel = _sp.GetRequiredService<ListContactViewModel>();
         
        }


        [ObservableProperty]
        private ObservableObject currentViewModel = null!;

    }
}
