using UnityEngine;


public sealed class CameraServices : Service
{
    public CameraServices()
    {
        SetCamera(Camera.main);
    }

    public Camera CameraMain { get; private set; }

    public void SetCamera(Camera camera)
    {
        CameraMain = camera;
    }
}