using System;
using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using Microsoft.Extensions.DependencyInjection;
using Pinfluencer.SocialWrangler.Crosscutting.DIModule;
using Pinfluencer.SocialWrangler.UI.Bootstrapper.ViewModels;

namespace Pinfluencer.SocialWrangler.UI.Bootstrapper
{
    public class Bootstrapper : BootstrapperBase
    {
        private readonly IServiceCollection _services;
        private IServiceProvider _serviceProvider;

        public Bootstrapper( )
        {
            _services = new ServiceCollection( );
            Initialize(  );
        }

        protected override void Configure( )
        {
            _services.BindCrosscuttingLayer( )
                .AddTransient<ShellViewModel>( );
            _serviceProvider = _services.BuildServiceProvider( );
        }

        protected override object GetInstance( Type service, string key )
        {
            if( service == typeof( IWindowManager ) )
            {
                service = typeof( WindowManager );
                return Activator.CreateInstance(service);
            }
            return _serviceProvider.GetService( service );
        }

        protected override IEnumerable<object> GetAllInstances( Type service )
        {
            return _serviceProvider.GetServices( service );
        }

        protected override void OnStartup( object sender, StartupEventArgs e )
        {
            DisplayRootViewFor<ShellViewModel>(  );
        }
    }
}