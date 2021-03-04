using UnityEngine;

[CreateAssetMenu(fileName = "InputData", menuName = "Data/Input/InputData")]
public sealed class InputData : ScriptableObject
{
    [Header("Swipe Settings")]
    public float minDistance = 0.1f;
    public float maxTime = 1.0f;
    public float dirThreshold = 0.75f;
}