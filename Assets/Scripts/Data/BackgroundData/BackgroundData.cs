using UnityEngine;

[CreateAssetMenu(fileName = "BackgroundData", menuName = "Data/Background/BackgroundData")]

public sealed class BackgroundData : ScriptableObject
{
    [Header("Platform Settings")]
    public float speed = -0.25f;
    public float destroyPos = -10.0f;
}