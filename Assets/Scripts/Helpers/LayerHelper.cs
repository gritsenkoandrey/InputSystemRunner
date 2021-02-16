using UnityEngine;

public static class LayerHelper
{
    private const string DEFAULT = "Default";
    private const string GROUND = "Ground";

    public static int DefaultLayer { get; }
    public static int GroundLayer { get; }

    static LayerHelper()
    {
        DefaultLayer = LayerMask.GetMask(DEFAULT);
        GroundLayer = LayerMask.GetMask(GROUND);
    }
}