using UnityEngine;

public sealed class GameLevelService : Service
{
    public void InitGame()
    {
        ScreenInterface.GetScreenInterface().Execute(ScreenType.MainMenu);

        Services.Instance.LightService.InitLight();
        Services.Instance.CameraServices.SetCamera(Camera.main);
        Data.Instance.GameData.LoadData();
    }

    public void StartGame(CharacterType character, BackgroundType background)
    {
        ScreenInterface.GetScreenInterface().Execute(ScreenType.GameMenu);

        Services.Instance.EventService.EnableCharacter(character);
        Services.Instance.EventService.EnableBackground(background);
        Services.Instance.EventService.StartSpawn();
        Services.Instance.EventService.StartTimer();
    }

    public void EndGame()
    {
        ScreenInterface.GetScreenInterface().Execute(ScreenType.GameOverMenu);

        Services.Instance.EventService.DisableCharacter();
        Services.Instance.EventService.DisableBackground();
        Services.Instance.EventService.StopSpawn();
        Services.Instance.EventService.StopTimer();
    }

    public void PauseGame()
    {
        ScreenInterface.GetScreenInterface().Execute(ScreenType.PauseMenu);

        Services.Instance.AudioService.PauseMusic();
        Services.Instance.EventService.VisibleCharacter(false);
        Services.Instance.TimeService.SetTimeScale(0f);
    }

    public void UnpauseGame()
    {
        ScreenInterface.GetScreenInterface().Execute(ScreenType.GameMenu);

        Services.Instance.AudioService.UnpauseMusic();
        Services.Instance.EventService.VisibleCharacter(true);
        Services.Instance.TimeService.SetTimeScale(1.0f);
    }
}