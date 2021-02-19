using System.Collections.Generic;

public static class CoinList
{
    private readonly static List<CoinBehaviour> _coinsList;

    static CoinList()
    {
        _coinsList = new List<CoinBehaviour>();
    }

    public static void AddCoinToList(CoinBehaviour coin)
    {
        if (!_coinsList.Contains(coin))
        {
            _coinsList.Add(coin);
            coin.OnDieChange += RemoveCoinToList;
        }
    }

    private static void RemoveCoinToList(CoinBehaviour coin)
    {
        if (!_coinsList.Contains(coin))
        {
            return;
        }
        coin.OnDieChange -= RemoveCoinToList;
        _coinsList.Remove(coin);
    }

    public static void Execute(float speed)
    {
        for (var i = 0; i < _coinsList.Count; i++)
        {
            _coinsList[i].Move(speed);
        }
    }

    public static void ClearList()
    {
       _coinsList.Clear();
    }
}