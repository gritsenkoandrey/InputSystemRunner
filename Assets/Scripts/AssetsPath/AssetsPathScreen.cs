using System.Collections.Generic;

public sealed class AssetsPathScreen
{
    public struct ScreenPath
    {
        public string screen;
        public Dictionary<ScreenElementType, string> elements;
    }

    public static readonly Dictionary<ScreenType, ScreenPath> screens = new Dictionary<ScreenType, ScreenPath>
    {
        {
            ScreenType.MainMenu, new ScreenPath
            {
                screen = "Prefabs/UI/Screen/Main_Menu",
                elements = new Dictionary<ScreenElementType, string>
                {
                    {ScreenElementType.MainMenu, "MainMenu"}
                }
            }
        },
        {
            ScreenType.GameMenu, new ScreenPath
            {
                screen = "Prefabs/UI/Screen/Game_Menu",
                elements = new Dictionary<ScreenElementType, string>
                {
                    {ScreenElementType.GameMenu, "GameMenu"}
                }
            }
        }
    };
}