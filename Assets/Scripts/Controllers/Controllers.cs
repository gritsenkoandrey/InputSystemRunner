public sealed class Controllers : IInitialization, ICleanUp
{
    private readonly IExecute[] _executeControllers;
    private readonly IFixExecute[] _fixExecuteController;
    private readonly ICleanUp[] _cleanUps;
    private readonly IInitialization[] _initializations;

    public int ExecuteLength => (int)_executeControllers.Length;
    public byte FixedLength => (byte)_fixExecuteController.Length;

    public IExecute this[int index] => _executeControllers[index];
    public IFixExecute this[byte index] => _fixExecuteController[index];

    public Controllers()
    {
        _initializations = new IInitialization[3];
        _initializations[0] = new CharacterController();
        _initializations[1] = new ScreenController();
        _initializations[2] = new LevelController();

        _executeControllers = new IExecute[1];
        _executeControllers[0] = new TimeRemainingController();

        _fixExecuteController = new IFixExecute[2];
        _fixExecuteController[0] = new SpawnController();
        _fixExecuteController[1] = new BackgroundController();

        _cleanUps = new ICleanUp[2];
        _cleanUps[0] = new TimeRemainingCleanUp();
        _cleanUps[1] = new SpawnController();
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

        for (var i = 0; i < _fixExecuteController.Length; i++)
        {
            var fixExecute = _fixExecuteController[i];
            if (fixExecute is IInitialization initialization)
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