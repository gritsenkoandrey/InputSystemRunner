public sealed class CharacterController : BaseController, IInitialization
{
    private readonly CharacterData _data;
    private bool _isPaused = false;

    public CharacterController()
    {
        _data = Data.Instance.Character;
        _data.Initialization();
    }

    public void Initialization()
    {
        Switch(_data.characterBehaviour);
    }

    public override void On(params BaseModel[] model)
    {
        if (IsActive) return;
        if (model.Length > 0) _data.characterBehaviour = model[0] as CharacterBehaviour;
        if (_data.characterBehaviour == null) return;
        base.On(_data.characterBehaviour);

        _data.characterBehaviour.input.Player.Move.performed +=
            context => _data.characterBehaviour.Move(context.ReadValue<float>());
        _data.characterBehaviour.input.Player.Jump.performed += context => _data.characterBehaviour.Jump();
        _data.characterBehaviour.input.Player.Pause.performed += context => Pause();
    }

    public override void Off()
    {
        if (!IsActive) return;
        base.Off();
    }

    private void Pause()
    {
        if (!_isPaused)
        {
            Services.Instance.TimeService.SetTimeScale(1.0f);
            _isPaused = true;
        }
        else
        {
            Services.Instance.TimeService.SetTimeScale(0f);
            _isPaused = false;
        }
    }
}