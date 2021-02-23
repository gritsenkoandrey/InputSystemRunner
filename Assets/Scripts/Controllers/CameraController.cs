using UnityEngine;

public sealed class CameraController : IInitialization
{
    public void Initialization()
    {
        Services.Instance.CameraServices.SetCamera(Camera.main);
    }
}