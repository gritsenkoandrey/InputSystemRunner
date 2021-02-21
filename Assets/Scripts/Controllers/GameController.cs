using UnityEngine;

public sealed class GameController : MonoBehaviour
{
    private Controllers _controllers;

    private void Start()
    {
        _controllers = new Controllers();

        Cleaner();
        Initialization();
    }

    private void Update()
    {
        for (var i = 0; i < _controllers.ExecuteLength; i++)
        {
            _controllers[i].Execute();
        }
    }

    private void FixedUpdate()
    {
        for (var i = 0; i < _controllers.FixedLength; i++)
        {
            _controllers[(byte)i].FixedExecute();
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