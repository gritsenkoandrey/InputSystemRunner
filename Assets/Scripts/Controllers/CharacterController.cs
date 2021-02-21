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

        _input.OnStartMove += _data.characterBehaviour.Move;
        _input.OnStartJump += _data.characterBehaviour.Jump;
    }

    public override void Off()
    {
        if (!IsActive) return;
        base.Off();

        _input.OnStartMove -= _data.characterBehaviour.Move;
        _input.OnStartJump -= _data.characterBehaviour.Jump;
    }
}