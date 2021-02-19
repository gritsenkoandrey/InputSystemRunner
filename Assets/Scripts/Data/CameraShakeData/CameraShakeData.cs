using UnityEngine;

[CreateAssetMenu(fileName = "CameraShakeData", menuName = "Data/Camera/CameraShakeData")]
public class CameraShakeData : ScriptableObject
{
    [SerializeField] private SerializeShakeData[] _shakes = null;

    public ShakeInfo GetShakeInfo(ShakeType type)
    {
        ShakeInfo result = default;
        foreach (var shakeData in _shakes)
        {
            if (shakeData.shakeType == type)
            {
                result = shakeData.shakeInfo;
            }
        }

        return result;
    }
}