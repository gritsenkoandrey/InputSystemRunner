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
                    { ScreenElementType.MainMenu, "MainMenu" }
                }
            }
        },
        {
            ScreenType.GameMenu, new ScreenPath
            {
                screen = "Prefabs/UI/Screen/Game_Menu",
                elements = new Dictionary<ScreenElementType, string>
                {
                    { ScreenElementType.GameMenu, "GameMenu" }
                }
            }
        },
        {
            ScreenType.GameOverMenu, new ScreenPath
            {
                screen = "Prefabs/UI/Screen/Game_Over_Menu",
                elements = new Dictionary<ScreenElementType, string>
                {
                    { ScreenElementType.GameOverMenu, "GameOverMenu" }
                }
            }
        },
        {
            ScreenType.PauseMenu, new ScreenPath
            {
                screen = "Prefabs/UI/Screen/Pause_Menu",
                elements = new Dictionary<ScreenElementType, string>
                {
                    { ScreenElementType.PauseMenu, "PauseMenu" }
                }
            }
        },
        {
            ScreenType.SettingsMenu, new ScreenPath
            {
                screen = "Prefabs/UI/Screen/Settings_Menu",
                elements = new Dictionary<ScreenElementType, string>
                {
                    { ScreenElementType.SettingsMenu, "SettingsMenu" }
                }
            }
        }
    };
}