public sealed class GameLevelService : Service
{
    public void StartGame(CharacterType characterType)
    {
        Services.Instance.EventService.SpawnCharacter(characterType);
        Services.Instance.EventService.SpawnBackground();
        Services.Instance.EventService.StartSpawnItems();
        Services.Instance.EventService.StartLevelTimer();
    }

    public void GameOver()
    {
        Services.Instance.EventService.DestroyCharacter();
        Services.Instance.EventService.DestroyBackground();
        Services.Instance.EventService.StopSpawnItems();
        Services.Instance.EventService.StopLevelTimer();
    }
}