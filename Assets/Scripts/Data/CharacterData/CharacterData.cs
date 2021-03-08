using UnityEngine;
using UnityEngine.UI;

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
    public int power = 15;

    [Header("Character Image")]
    [SerializeField] private RawImage[] _images = null;
    [SerializeField] private GameObject _rendererTexture = null;

    internal CharacterBehaviour characterBehaviour;
    public void Initialization(CharacterType characterType)
    {
        CharacterBehaviour character;

        switch (characterType)
        {
            case CharacterType.Ortiz:
                character = CustomResources.Load<CharacterBehaviour>(AssetsPathGameObject.GameObjects[GameObjectType.CharacterOrtiz]);
                characterBehaviour = Instantiate(character);
                break;
            case CharacterType.Elvis:
                character = CustomResources.Load<CharacterBehaviour>(AssetsPathGameObject.GameObjects[GameObjectType.CharacterElvis]);
                characterBehaviour = Instantiate(character);
                break;
            case CharacterType.Jammo:
                character = CustomResources.Load<CharacterBehaviour>(AssetsPathGameObject.GameObjects[GameObjectType.CharacterJammo]);
                characterBehaviour = Instantiate(character);
                break;
        }
    }

    public void InitializationImage(Transform pos)
    {
        Instantiate(_rendererTexture, pos);

        for (int i = 0; i < _images.Length; i++)
        {
            Instantiate(_images[i], pos);
        }
    }
}