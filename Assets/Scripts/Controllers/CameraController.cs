using UnityEngine;

public sealed class CameraController : BaseController, IInitialization
{
    public void Initialization()
    {
        Services.Instance.CameraServices.SetCamera(Camera.main);
    }
}