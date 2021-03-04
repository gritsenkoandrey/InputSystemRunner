using System;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
public sealed class Data : ScriptableObject
{
    [SerializeField] private string _backgroundDataPath = null;
    [SerializeField] private string _characterDataPath = null;
    [SerializeField] private string _obstacleDataPath = null;
    [SerializeField] private string _blockDataPath = null;
    [SerializeField] private string _coinDataPath = null;
    [SerializeField] private string _cameraShakeDataPath = null;
    [SerializeField] private string _soundDataPath = null;
    [SerializeField] private string _effectDataPath = null;
    [SerializeField] private string _inputDataPath = null;

    private static BackgroundData _backgroundData;
    private static CharacterData _characterData;
    private static ObstacleData _obstacleData;
    private static BlockData _blockData;
    private static CoinData _coinData;
    private static CameraShakeData _cameraShakeData;
    private static SoundData _soundData;
    private static EffectData _effectData;
    private static InputData _inputData;

    private static readonly Lazy<Data> _instance = new Lazy<Data>(() => Load<Data>("Data/" + typeof(Data).Name));

    public static Data Instance => _instance.Value;

    public BackgroundData Background
    {
        get
        {
            if (_backgroundData == null)
            {
                _backgroundData = Load<BackgroundData>("Data/" + Instance._backgroundDataPath);
            }

            return _backgroundData;
        }
    }

    public CharacterData Character
    {
        get
        {
            if (_characterData == null)
            {
                _characterData = Load<CharacterData>("Data/" + Instance._characterDataPath);
            }

            return _characterData;
        }
    }

    public ObstacleData Obstacle
    {
        get
        {
            if (_obstacleData == null)
            {
                _obstacleData = Load<ObstacleData>("Data/" + Instance._obstacleDataPath);
            }

            return _obstacleData;
        }
    }

    public BlockData Block
    {
        get
        {
            if (_blockData == null)
            {
                _blockData = Load<BlockData>("Data/" + Instance._blockDataPath);
            }

            return _blockData;
        }
    }

    public CoinData Coin
    {
        get
        {
            if (_coinData == null)
            {
                _coinData = Load<CoinData>("Data/" + Instance._coinDataPath);
            }

            return _coinData;
        }
    }

    public CameraShakeData CameraShake
    {
        get
        {
            if (_cameraShakeData == null)
            {
                _cameraShakeData = Load<CameraShakeData>("Data/" + Instance._cameraShakeDataPath);
            }

            return _cameraShakeData;
        }
    }

    public SoundData SoundData
    {
        get
        {
            if (_soundData == null)
            {
                _soundData = Load<SoundData>("Data/" + Instance._soundDataPath);
            }

            return _soundData;
        }
    }

    public EffectData EffectData
    {
        get
        {
            if (_effectData == null)
            {
                _effectData = Load<EffectData>("Data/" + Instance._effectDataPath);
            }

            return _effectData;
        }
    }

    public InputData InputData
    {
        get
        {
            if (_inputData == null)
            {
                _inputData = Load<InputData>("Data/" + Instance._inputDataPath);
            }

            return _inputData;
        }
    }

    private static T Load<T>(string resourcesPath) where T : Object =>
        CustomResources.Load<T>(Path.ChangeExtension(resourcesPath, null));
}