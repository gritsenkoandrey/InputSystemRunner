using System;

public sealed class Services
{
    private static readonly Lazy<Services> _instance = new Lazy<Services>();

    public Services()
    {
        Initialize();
    }

    public static Services Instance => _instance.Value;
    public CameraServices CameraServices { get; private set; }
    public ITimeService TimeService { get; private set; }
    public ISaveData SaveData { get; private set; }
    public JsonService JsonService { get; private set; }
    public EventService EventService { get; private set; }
    public GameLevelService GameLevelService { get; private set; }

    private void Initialize()
    {
        CameraServices = new CameraServices();
        TimeService = new UnityTimeService();
        SaveData = new PrefsService();
        JsonService = new JsonService();
        EventService = new EventService();
        GameLevelService = new GameLevelService();
    }
}