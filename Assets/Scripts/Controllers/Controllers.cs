public sealed class Controllers : IInitialization, ICleanUp
{
    private readonly IExecute[] _executeControllers;
    private readonly ICleanUp[] _cleanUps;
    private readonly IInitialization[] _initializations;

    public int Length => _executeControllers.Length;

    public IExecute this[int index] => _executeControllers[index];

    public Controllers()
    {
        _initializations = new IInitialization[2];
        _initializations[0] = new CharacterController();
        _initializations[1] = new LevelController();

        _executeControllers = new IExecute[3];
        _executeControllers[0] = new TimeRemainingController();
        _executeControllers[1] = new SpawnController();
        _executeControllers[2] = new BackgroundController();

        _cleanUps = new ICleanUp[1];
        _cleanUps[0] = new TimeRemainingCleanUp();
    }

    public void Initialization()
    {
        for (var i = 0; i < _initializations.Length; i++)
        {
            var initialization = _initializations[i];
            initialization.Initialization();
        }

        for (var i = 0; i < _executeControllers.Length; i++)
        {
            var execute = _executeControllers[i];
            if (execute is IInitialization initialization)
            {
                initialization.Initialization();
            }
        }
    }

    public void Cleaner()
    {
        for (var index = 0; index < _cleanUps.Length; index++)
        {
            var cleanUp = _cleanUps[index];
            cleanUp.Cleaner();
        }
    }
}