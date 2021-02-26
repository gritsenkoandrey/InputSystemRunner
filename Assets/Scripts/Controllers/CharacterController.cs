public sealed class CharacterController : BaseController, IInitialization, IFixExecute
{
    private readonly CharacterData _data;
    private readonly InputManager _input;

    public CharacterController()
    {
        _input = InputManager.Instance;
        _data = Data.Instance.Character;
    }

    public void Initialization()
    {
        Services.Instance.EventService.OnCharacter += SpawnCharacter;
    }

    private void SpawnCharacter(CharacterType characterType)
    {
        _data.Initialization(characterType);
        Services.Instance.EventService.OnCharacter -= SpawnCharacter;
    }

    public void FixedExecute()
    {
        if (!IsActive)
        {
            if (_data.characterBehaviour && _data.characterBehaviour.IsVisible)
            {
                On(_data.characterBehaviour);
            }
            return;
        }
        else
        {
            if (!_data.characterBehaviour.IsVisible)
            {
                Off();
            }
        }
    }

    public override void On(params BaseModel[] model)
    {
        if (IsActive) return;
        if (model.Length > 0) _data.characterBehaviour = model[0] as CharacterBehaviour;
        if (_data.characterBehaviour == null) return;
        base.On(_data.characterBehaviour);

        _input.OnStartMove += MoveButton;
        _input.OnStartJump += JumpButton;
        _input.OnStartPause += PauseButton;
    }

    public override void Off()
    {
        if (!IsActive) return;
        base.Off();

        _input.OnStartMove -= MoveButton;
        _input.OnStartJump -= JumpButton;
        _input.OnStartPause -= PauseButton;
    }

    private void MoveButton(float input)
    {
        _data.characterBehaviour.Move(input);
    }

    private void JumpButton()
    {
        _data.characterBehaviour.Jump();
    }

    //todo подписка осуществляется только после спавна персонажа
    private void PauseButton()
    {
        if (uInterface.GameMenuBehaviour) uInterface.GameMenuBehaviour.PauseButton();
        else if (uInterface.MainMenuBehaviour) uInterface.MainMenuBehaviour.PauseButton();
    }
}