using UnityEngine;

public sealed class ScreenController : BaseController, IInitialization
{
    private readonly CanvasData _data;

    public ScreenController()
    {
        _data = Data.Instance.Canvas;
        _data.Initialization();
    }

    public void Initialization()
    {
        Services.Instance.CameraServices.SetCamera(Camera.main);
    }
}