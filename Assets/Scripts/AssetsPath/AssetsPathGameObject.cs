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
            GameObjectType.CharacterJammo, "Prefabs/Characters/Character_Jammo"
        },
        {
            GameObjectType.BackgroundOne, "Prefabs/Backgrounds/Background_01"
        },
        {
            GameObjectType.Canvas, "Prefabs/Canvas/Canvas"
        },
        {
            GameObjectType.BackgroundTwo, "Prefabs/Backgrounds/Background_02"
        },
        {
            GameObjectType.BackgroundThree, "Prefabs/Backgrounds/Background_03"
        },
    };
}