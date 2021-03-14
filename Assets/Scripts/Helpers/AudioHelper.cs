using System.Collections.Generic;

public static class AudioHelper
{
    private static readonly Dictionary<AudioType, string> _types;

    static AudioHelper()
    {
        _types = new Dictionary<AudioType, string>
        { 
            { AudioType.GameTheme, "Sounds/GameTheme" },
            { AudioType.MainTheme, "Sounds/MainTheme" },
            { AudioType.GameOver, "Sounds/GameOver" },
            { AudioType.Jump, "Sounds/Jump" },
            { AudioType.Move, "Sounds/Move" },
            { AudioType.PickBlock, "Sounds/PickBlock" },
            { AudioType.PickCoin, "Sounds/PickCoin" },
            { AudioType.PickObstacle, "Sounds/PickObstacle" },
            { AudioType.Click, "Sounds/Click" },
            { AudioType.Buy, "Sounds/Buy" },
            { AudioType.Reset, "Sounds/Reset" }
        };
    }

    public static string GetName(AudioType type)
    {
        return _types[type];
    }
}