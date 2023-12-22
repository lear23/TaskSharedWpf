using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfAppTask.Views;
using WpfAppTask.ViewsModels;

namespace WpfAppTask
{

    public partial class App : Application
    {

        private IHost? _host {  get; set; }

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {

                services.AddTransient<ListContactViewModel>();
                services.AddTransient<ListContactView>();

                services.AddTransient<AddContactViewModel>();
                services.AddTransient<AddContactView>();

                services.AddTransient<EditContactViewModel>();
                services.AddTransient<EditContactView>();

                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainViewModel>();



            }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host!.StartAsync();

            var mainWindow = _host!.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();


            base.OnStartup(e);
        }
        

    }

}


