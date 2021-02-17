using UnityEngine;


public sealed class CharacterController : BaseController, IInitialization
{
    private readonly InputMaster _inputMaster;
    private readonly CharacterData _characterData;

    public CharacterController()
    {
        _inputMaster = new InputMaster();
        _characterData = Data.Instance.Character;
        _characterData.Initialization(_characterData.characterMove);
    }

    public void Initialization()
    {
        Switch(_characterData.characterMove);
    }

    public override void On(params BaseModel[] model)
    {
        if (IsActive) return;
        if (model.Length > 0) _characterData.characterMove = model[0] as CharacterMove;
        if (_characterData.characterMove == null) return;
        base.On(_characterData.characterMove);

        _inputMaster.Enable();
        _inputMaster.Player.Move.performed += context => _characterData.characterMove.Move(context.ReadValue<float>());
        _inputMaster.Player.Jump.performed += context => _characterData.characterMove.Jump();
        _inputMaster.Player.Pause.performed += context => Pause();
    }

    public override void Off()
    {
        if (!IsActive) return;
        base.Off();

        _inputMaster.Disable();
    }

    private void Pause()
    {

        if (Time.timeScale.Equals(0f))
        {
            Debug.Log("Start");
            Services.Instance.TimeService.SetTimeScale(1.0f);
        }
        else
        {
            Debug.Log("Pause");
            Services.Instance.TimeService.SetTimeScale(0f);
        }
    }
}