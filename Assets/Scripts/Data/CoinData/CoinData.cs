using UnityEngine;

[CreateAssetMenu(fileName = "CoinData", menuName = "Data/Coin/CoinData")]
public sealed class CoinData : ScriptableObject
{
    [Header("Spawn Position")] public Vector3[] spawnPoints;

    [Header("Prefabs Coin")] public GameObject[] prefabs;

    [Header("Settings Coin")]
    public float speed = -0.5f;
}