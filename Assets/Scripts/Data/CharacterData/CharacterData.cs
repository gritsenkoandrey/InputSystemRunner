using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Data/Character/CharacterData")]
public sealed class CharacterData : ScriptableObject
{
    [Header("Character Prefab")] public GameObject prefab;

    [Header("Lines")]
    public float maxPos = 3.0f;
    public float middlePos = 0f;
    public float minPos = -3.0f;

    [Header("Character settings")]
    public float speed = 3.0f;
    public float jump = 5.0f;
    public int health = 5;

    [Header("Raycast Distance")] public float rayDis = 0.5f;

    internal CharacterMove characterMove;
    internal CharacterHealth characterHealth;

    public void Initialization(CharacterBase character)
    {
        if (character == characterMove)
        {
            characterMove = FindObjectOfType<CharacterBase>().GetComponent<CharacterMove>();
        }

        if (character == characterHealth)
        {
            characterHealth = FindObjectOfType<CharacterBase>().GetComponent<CharacterHealth>();
        }
    }
}