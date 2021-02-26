public interface ICollisionItem : IGlobalSubscriber
{
    void PickObstacle();
    void PickCoin();
    void PickBlock();
}