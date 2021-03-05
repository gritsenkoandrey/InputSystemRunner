using UnityEngine;

public sealed class CharacterController : BaseController, IInitialization, IFixExecute
{
    private readonly CharacterData _data;
    private readonly InputData _inputData;
    private readonly InputManager _input;

    private Vector2 _startPos;
    private Vector2 _endPos;
    private float _startTime;
    private float _endTime;
    private readonly float _minDistance;
    private readonly float _maxTime;
    private readonly float _dirThreshold;

    public CharacterController()
    {
        _input = InputManager.Instance;
        _data = Data.Instance.Character;

        _inputData = Data.Instance.InputData;
        _minDistance = _inputData.minDistance;
        _maxTime = _inputData.maxTime;
        _dirThreshold = _inputData.dirThreshold;
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
    //todo во время паузы нужно отключить управление
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
        _input.OnStartTouch += SwipeStart;
        _input.OnEndTouch += SwipeEnd;
    }

    public override void Off()
    {
        if (!IsActive) return;
        base.Off();

        _input.OnStartMove -= MoveButton;
        _input.OnStartJump -= JumpButton;
        _input.OnStartPause -= PauseButton;
        _input.OnStartTouch -= SwipeStart;
        _input.OnEndTouch -= SwipeEnd;
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
        if (uInterface.GameMenuBehaviour) uInterface.GameMenuBehaviour.PressPauseButton();
    }

    private void SwipeStart(Vector2 pos, float time)
    {
        _startPos = pos;
        _startTime = time;
    }

    private void SwipeEnd(Vector2 pos, float time)
    {
        _endPos = pos;
        _endTime = time;
        SwipeDetected();
    }

    private void SwipeDetected()
    {
        if ((_startPos -_endPos).sqrMagnitude > _minDistance && (_endTime - _startTime) < _maxTime)
        {
            var dir = (_endPos - _startPos).normalized;

            if (Vector2.Dot(Vector2.up, dir) > _dirThreshold)
            {
                _data.characterBehaviour.Jump();
            }
            else if (Vector2.Dot(Vector2.down, dir) > _dirThreshold)
            {
                return;
            }
            else if (Vector2.Dot(Vector2.right, dir) > _dirThreshold)
            {
                _data.characterBehaviour.Move(-1);
            }
            else if (Vector2.Dot(Vector2.left, dir) > _dirThreshold)
            {
                _data.characterBehaviour.Move(1);
            }
        }
    }
}