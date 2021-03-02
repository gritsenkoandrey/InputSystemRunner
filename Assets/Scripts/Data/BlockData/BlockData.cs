using UnityEngine;

[CreateAssetMenu(fileName = "BlockData", menuName = "Data/Block/BlockData")]
public sealed class BlockData : ScriptableObject
{
    [Header("Spawn Position")] public Vector3[] spawnPoints;
    [Header("Prefabs Blocks")] public GameObject[] prefabs;
    [Header("Settings Blocks")] public float speed = -0.5f;
}