using System.Collections.Generic;

public sealed class AssetsPathGameObject
{
    public static readonly Dictionary<GameObjectType, string> GameObjects = new Dictionary<GameObjectType, string>
    {
        {
            GameObjectType.CharacterOrtiz, "Prefabs/Characters/Character_Ortiz"
        },
        {
            GameObjectType.CharacterElvis, "Prefabs/Characters/Character_Elvis"
        },
        {
            GameObjectType.Background, "Prefabs/Backgrounds/Background"
        },
        {
            GameObjectType.Canvas, "Prefabs/Canvas/Canvas"
        }
    };
}