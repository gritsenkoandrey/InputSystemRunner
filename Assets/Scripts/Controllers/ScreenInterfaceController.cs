public sealed class ScreenInterfaceController : BaseController, ICleanUp
{
    public void Cleaner()
    {
        ScreenInterface.CleanScreenInterface();
    }
}