using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class CharacterControl : MonoBehaviour
{
    private CharacterData _characterData;

    private float _maxPos;
    private float _minPos;
    private float _middlePos;
    private float _speed;
    private float _jump;
    private float _rayDis;

    private Vector3 _tempPos;
    private Rigidbody _body;

    private void Awake()
    {
        InitializationData();
        _body = GetComponent<Rigidbody>();
    }

    //private void OnEnable()
    //{
    //    InputController.Instance.inputMaster.Enable();
    //}

    //private void OnDisable()
    //{
    //    InputController.Instance.inputMaster.Disable();
    //}

    public void Jump()
    {
        if (CheckGround())
        {
            _body.AddForce(Vector3.up * _jump, ForceMode.Impulse);
        }
    }

    public void Move(float input)
    {
        if (CheckGround())
        {
            _tempPos = transform.position;

            if (Mathf.Approximately(_tempPos.z, _middlePos))
            {
                _body.MovePosition(new Vector3(0f, 0f, input * _speed));
            }
            else if (Mathf.Approximately(_tempPos.z, _minPos) && input > 0 || Mathf.Approximately(_tempPos.z, _maxPos) && input < 0)
            {
                _body.MovePosition(Vector3.zero);
            }
        }
    }

    private bool CheckGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, _rayDis, LayerHelper.GroundLayer);
    }

    private void InitializationData()
    {
        _characterData = Data.Instance.Character;
        _maxPos = _characterData.maxPos;
        _minPos = _characterData.minPos;
        _middlePos = _characterData.middlePos;
        _speed = _characterData.speed;
        _jump = _characterData.jump;
        _rayDis = _characterData.rayDis;
    }
}