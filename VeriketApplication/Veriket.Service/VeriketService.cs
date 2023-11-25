using System;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace Veriket.Service
{
    public partial class VeriketService : ServiceBase
    {
        private CancellationTokenSource cancellationTokenSource;
        public VeriketService()
        {
            InitializeComponent();
        }
        public void onDebug()
        {
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
            try
            {
                Log.writeEventLog("Service started");
                cancellationTokenSource = new CancellationTokenSource();
                Task.Run(() => WorkerMethod(cancellationTokenSource.Token));
            }
            catch (Exception ex)
            {
                Log.writeEventLog(ex.ToString());
            }
        }
        private async void WorkerMethod(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                VeriketLog.writeEventLog(DateTime.Now, GetEnvironment.MachineName(), GetEnvironment.UserName());
                await Task.Delay(60000, cancellationToken); // 1 dakika
            }
        }
        protected override void OnStop()
        {
            try
            {
                cancellationTokenSource.Cancel();
                Log.writeEventLog("Service has been stopped");
            }
            catch (Exception ex)
            {
                Log.writeEventLog(ex.ToString());
            }
        }
    }
}
