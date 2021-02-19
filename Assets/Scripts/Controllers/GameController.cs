using UnityEngine;


public sealed class GameController : MonoBehaviour
{
    private Controllers _controllers;

    private void Start()
    {
        _controllers = new Controllers();
        Cleaner();
        //todo обдумать
        Services.Instance.CameraServices.SetCamera(Camera.main);
        Initialization();
    }

    private void FixedUpdate()
    {
        for (var i = 0; i < _controllers.Length; i++)
        {
            _controllers[i].Execute();
        }
    }

    public void Cleaner()
    {
        _controllers.Cleaner();
    }

    public void Initialization()
    {
        _controllers.Initialization();
    }
}