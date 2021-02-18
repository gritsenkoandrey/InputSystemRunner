public interface ICollision : IGlobalSubscriber
{
    void PickObstacle();
    void PickCoin();
    void PickBlock();
}