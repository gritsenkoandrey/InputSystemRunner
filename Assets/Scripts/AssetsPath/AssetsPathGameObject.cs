using System.Collections.Generic;

public sealed class AssetsPathGameObject
{
    public static readonly Dictionary<GameObjectType, string> GameObjects = new Dictionary<GameObjectType, string>
    {
        {
            GameObjectType.Character, "Prefabs/Characters/Character_FatBoy"
        },
        {
            GameObjectType.Background, "Prefabs/Backgrounds/Background"
        },
        {
            GameObjectType.Canvas, "Prefabs/Canvas/Canvas"
        }
    };
}