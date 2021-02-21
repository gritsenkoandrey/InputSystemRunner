using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "Data/Obstacle/ObstacleData")]
public sealed class ObstacleData : ScriptableObject
{
    [Header("Spawn Position")] public Vector3[] spawnPoints;
    [Header("Prefabs Obstacles")] public GameObject[] prefabs;
    [Header("Settings Obstacles")] public float speed = -0.5f;
}