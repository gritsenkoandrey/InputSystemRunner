using System.Collections.Generic;

public static class CoinList
{
    private readonly static List<CoinModel> _coinsList;

    static CoinList()
    {
        _coinsList = new List<CoinModel>();
    }

    public static void AddCoinToList(CoinModel coin)
    {
        if (!_coinsList.Contains(coin))
        {
            _coinsList.Add(coin);
            coin.OnDieChange += RemoveCoinToList;
        }
    }

    private static void RemoveCoinToList(CoinModel coin)
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