using System.Collections.Generic;
using UnityEngine;

public static class AnimationHelper
{
    private static readonly Dictionary<AnimationType, int> _types;

    static AnimationHelper()
    {
        _types = new Dictionary<AnimationType, int>
        {
            { AnimationType.Jump, Animator.StringToHash("Jump") }
        };
    }

    public static int GetName(AnimationType type)
    {
        return _types[type];
    }
}