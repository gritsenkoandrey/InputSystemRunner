using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/Game/GameData")]
public sealed class GameData : ScriptableObject
{
    private string _coin = "Coin";
    private string _ortiz = "Ortiz";
    private string _elvis = "Elvis";
    private string _jammo = "Jammo";

    private int _maxCoin;
    private int _curCoin;

    public Dictionary<CharacterType, bool> CharacterIsUnloked;
    public int Coins { get; private set; }

    public void LoadData()
    {
        CharacterIsUnloked = new Dictionary<CharacterType, bool>
        {
            {
                CharacterType.Ortiz, Services.Instance.SaveData.GetBool(_ortiz, true)
            },
            {
                CharacterType.Elvis, Services.Instance.SaveData.GetBool(_elvis, false)
            },
            {
                CharacterType.Jammo, Services.Instance.SaveData.GetBool(_jammo, false)
            }
        };

        Coins = LoadMaxCoin();
    }

    public void SaveCharacterData(CharacterType character, bool value)
    {
        CharacterIsUnloked[character] = value;

        switch (character)
        {
            case CharacterType.Ortiz:
                Services.Instance.SaveData.SetBool(_ortiz, value);
                break;
            case CharacterType.Elvis:
                Services.Instance.SaveData.SetBool(_elvis, value);
                break;
            case CharacterType.Jammo:
                Services.Instance.SaveData.SetBool(_jammo, value);
                break;
        }

        CustomDebug.Log($"Save Data: {character} is {value}");
    }

    public void SaveCoinsData(int coin)
    {
        _curCoin = coin;
        _maxCoin = LoadMaxCoin();
        _maxCoin += _curCoin;
        SaveMaxCoin();

        CustomDebug.Log($"Save Data: maximum coin is {_maxCoin}");
    }

    private int LoadMaxCoin()
    {
        return Services.Instance.SaveData.GetInt(_coin);
    }

    private void SaveMaxCoin()
    {
        Services.Instance.SaveData.SetInt(_coin, _maxCoin);
    }

    public void CleanData()
    {
        Services.Instance.SaveData.DeleteAll();

        CustomDebug.Log("Clean Data");
    }
}