using System.Collections.Generic;

public static class AnimationHlper
{
    private static readonly Dictionary<AnimationType, string> _types;

    static AnimationHlper()
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