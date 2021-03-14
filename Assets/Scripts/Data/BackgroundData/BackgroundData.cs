using UnityEngine;

[CreateAssetMenu(fileName = "BackgroundData", menuName = "Data/Background/BackgroundData")]
public sealed class BackgroundData : ScriptableObject
{
    [Header("Platform Settings")]
    public float speed = -0.25f;
    public float destroyPos = -10.0f;

    internal BackgroundBehaviour backgroundBehaviour;
    public void Initialization(BackgroundType backgroundType)
    {
        BackgroundBehaviour background;

        switch (backgroundType)
        {
            case BackgroundType.BackgroundOne:
                background = CustomResources.Load<BackgroundBehaviour>(AssetsPathGameObject.GameObjects[GameObjectType.BackgroundOne]);
                backgroundBehaviour = Instantiate(background);
                break;
            case BackgroundType.BackgroundTwo:
                background = CustomResources.Load<BackgroundBehaviour>(AssetsPathGameObject.GameObjects[GameObjectType.BackgroundTwo]);
                backgroundBehaviour = Instantiate(background);
                break;
            case BackgroundType.BackgroundThree:
                background = CustomResources.Load<BackgroundBehaviour>(AssetsPathGameObject.GameObjects[GameObjectType.BackgroundThree]);
                backgroundBehaviour = Instantiate(background);
                break;
        }
    }
}