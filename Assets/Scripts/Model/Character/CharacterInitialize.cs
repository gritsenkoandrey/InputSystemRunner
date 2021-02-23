public sealed class CharacterInitialize
{
    private readonly CharacterData _data;

    public readonly int health;
    public readonly int power;
    public readonly float maxPos;
    public readonly float minPos;
    public readonly float middlePos;
    public readonly float speed;
    public readonly float jump;
    public readonly float rayDis;

    public CharacterInitialize()
    {
        _data = Data.Instance.Character;

        health = _data.health;
        power = _data.power;
        maxPos = _data.maxPos;
        minPos = _data.minPos;
        middlePos = _data.middlePos;
        speed = _data.speed;
        jump = _data.jump;
        rayDis = _data.rayDis;
    }
}