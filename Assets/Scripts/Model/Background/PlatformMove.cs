using System.Collections;
using UnityEngine;


public class PlatformMove : MonoBehaviour
{
    private readonly WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();
    private readonly float _speed = -0.25f;
    private readonly float _reSpawnPos = -10.0f;

    private void Awake()
    {
        StartCoroutine(Move());
    }

    private void Update()
    {
        if (transform.position.x < _reSpawnPos)
        {
            transform.position = Vector3.zero;
        }
    }

    private IEnumerator Move()
    {
        yield return _waitForFixedUpdate;
        transform.Translate(new Vector3(_speed, 0.0f, 0.0f));
        StartCoroutine(Move());
    }
}