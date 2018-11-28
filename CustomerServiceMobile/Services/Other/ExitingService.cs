using CustomerServiceMobile.Contracts.Other;

namespace CustomerServiceMobile.Services.Other
{
    public class ExitingService : IExitingService
    {
        public void Exit()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}
