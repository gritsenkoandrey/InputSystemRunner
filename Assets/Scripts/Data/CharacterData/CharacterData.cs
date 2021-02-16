using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Data/Character/CharacterData")]
public sealed class CharacterData : ScriptableObject
{
    [Header("Prefab Character")] public GameObject prefab;

    [Header("Lines")]
    public float maxPos = 3.0f;
    public float minPos = -3.0f;
    public float middlePos = 0f;

    [Header("Character Speed & Jump")]
    public float speed = 3.0f;
    public float jump = 5.0f;

    [Header("Ray cast Distance")] public float rayDis = 0.5f;

    internal CharacterModel characterModel;
    public void InitializationCharacter()
    {
        characterModel = FindObjectOfType<CharacterModel>();
    }
}