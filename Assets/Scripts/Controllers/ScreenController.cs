public sealed class ScreenController : BaseController, ICleanUp
{
    public void Cleaner()
    {
        ScreenInterface.CleanScreenInterface();
    }
}