public sealed class BackgroundInitialize
{
    public readonly BackgroundData data;
    public readonly float speed;
    public readonly float destroyPos;

    public BackgroundInitialize()
    {
        data = Data.Instance.Background;
        speed = data.speed;
        destroyPos = data.destroyPos;
    }
}