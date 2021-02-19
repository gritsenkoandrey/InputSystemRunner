using System;
using UnityEngine;

[Serializable]
public struct ShakeInfo
{
    public float duration;
    public float strength;
    public int vibrato;
    [Range(0.0f, 90.0f)] public float randomness;
    public Vector3 defaultCameraPos;
}