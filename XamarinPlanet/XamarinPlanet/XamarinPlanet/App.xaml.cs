using System;
using System.Threading.Tasks;
using MvvmCross;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinPlanet
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
        }

        #region Private Methods

        private static void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        {
            var newExc = new ApplicationUnhandledException(nameof(TaskSchedulerOnUnobservedTaskException), unobservedTaskExceptionEventArgs.Exception);
            LogUnhandledException(newExc);
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            var newExc = new ApplicationUnhandledException(nameof(CurrentDomainOnUnhandledException), unhandledExceptionEventArgs.ExceptionObject as Exception);
            LogUnhandledException(newExc);
        }

        private static void LogUnhandledException(ApplicationUnhandledException exception)
        {
            if (Mvx.IoCProvider.CanResolve<ILogger>())
            {
                var logger = Mvx.IoCProvider.Resolve<ILogger>();
                logger.LogError(exception);
            }
        }
        #endregion Private Methods
    }
}

