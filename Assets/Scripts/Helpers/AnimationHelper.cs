using System.Collections.Generic;

public static class AnimationHelper
{
    private static readonly Dictionary<AnimationType, string> _types;

    static AnimationHelper()
    {
        _types = new Dictionary<AnimationType, string>
        {
            { AnimationType.Jump, "Jump" }
        };
    }

    public static string GetName(AnimationType type)
    {
        return _types[type];
    }
}