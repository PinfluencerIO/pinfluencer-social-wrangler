using System.Windows;
using Caliburn.Micro;
using Pinfluencer.SocialWrangler.UI.Bootstrapper.ViewModels;

namespace Pinfluencer.SocialWrangler.UI.Bootstrapper
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper( )
        {
            Initialize(  );
        }

        protected override void OnStartup( object sender, StartupEventArgs e )
        {
            DisplayRootViewFor<ShellViewModel>(  );
        }
    }
}