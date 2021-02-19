using DG.Tweening;
using UnityEngine;

public sealed class CameraServices : Service
{
    private readonly Sequence _sequence = null;
    private ShakeInfo _shakeInfo;

    public CameraServices()
    {
        SetCamera(Camera.main);
    }

    public Camera CameraMain { get; private set; }

    public void SetCamera(Camera camera)
    {
        CameraMain = camera;
    }

    public void CreateShake(ShakeType shakeType)
    {
        _shakeInfo = Data.Instance.CameraShake.GetShakeInfo(shakeType);

        _sequence
            .Insert(0f, CameraMain.transform.DOMove(_shakeInfo.defaultCameraPos, 0f))
            .Append(CameraMain.DOShakePosition(_shakeInfo.duration, _shakeInfo.strength, _shakeInfo.vibrato, _shakeInfo.randomness));
    }
}