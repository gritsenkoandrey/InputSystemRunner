using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Data/Character/CharacterData")]
public sealed class CharacterData : ScriptableObject
{
    [Header("Lines")]
    public float maxPos = 3.0f;
    public float middlePos = 0f;
    public float minPos = -3.0f;

    [Header("Character Settings")]
    public float speed = 3.0f;
    public float jump = 5.0f;
    public float rayDis = 0.5f;
    public int health = 5;

    internal CharacterBehaviour characterBehaviour;
    public void Initialization()
    {
        var character = CustomResources.Load<CharacterBehaviour>
            (AssetsPathGameObject.GameObjects[GameObjectType.Character]);
        characterBehaviour = Instantiate(character);
    }
}