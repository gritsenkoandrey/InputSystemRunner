using UnityEngine;

public sealed class GamePlayController : BaseController, IInitialization, ICleanUp
{
    public void Initialization()
    {
        SetCamera();
        LoadData();
    }

    private void SetCamera()
    {
        Services.Instance.CameraServices.SetCamera(Camera.main);
    }

    private void LoadData()
    {
        Data.Instance.GameData.LoadData();
    }

    private void CleanScreenInterface()
    {
        ScreenInterface.CleanScreenInterface();
    }

    public void Cleaner()
    {
        CleanScreenInterface();
    }
}