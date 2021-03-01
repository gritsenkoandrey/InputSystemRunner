using UnityEngine;

[CreateAssetMenu(fileName = "EffectData", menuName = "Data/Effect/EffectData")]
public sealed class EffectData : ScriptableObject
{
    [Header("Particle Prefabs")] public GameObject effect;
}