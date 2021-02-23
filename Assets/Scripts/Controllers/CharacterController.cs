public sealed class CharacterController : BaseController, IInitialization
{
    private readonly CharacterData _data;
    private readonly InputManager _input;

    public CharacterController()
    {
        _input = InputManager.Instance;
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

    private void PauseButton()
    {
        if (uInterface.GameMenuBehaviour) uInterface.GameMenuBehaviour.PauseButton();
        else if (uInterface.MainMenuBehaviour) uInterface.MainMenuBehaviour.PauseButton();
    }
}