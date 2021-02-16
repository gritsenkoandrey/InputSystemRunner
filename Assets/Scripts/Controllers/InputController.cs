using UnityEngine;


public sealed class InputController : IInitialization, IExecute
{
    private InputMaster _inputMaster;
    private readonly CharacterData _characterData;

    public InputController()
    {
        _inputMaster = new InputMaster();
        _characterData = Data.Instance.Character;
        _characterData.InitializationCharacter();
    }

    public void Initialization()
    {
        _inputMaster.Enable();

        _inputMaster.Player.Move.performed += context => _characterData.characterControl.Move(context.ReadValue<float>());
        _inputMaster.Player.Jump.performed += context => _characterData.characterControl.Jump();
        _inputMaster.Player.Pause.performed += context => Pause();
    }

    public void Execute()
    {

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

    private void GameOver()
    {
        _inputMaster.Disable();
    }
}