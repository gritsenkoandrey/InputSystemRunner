public sealed class BackgroundInitialize
{
    private readonly BackgroundData _data;

    public readonly float speed;
    public readonly float destroyPos;

    public BackgroundInitialize()
    {
        _data = Data.Instance.Background;

        speed = _data.speed;
        destroyPos = _data.destroyPos;
    }
}