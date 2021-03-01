using UnityEngine;

public abstract class BaseModel : MonoBehaviour
{
    protected CharacterBehaviour character;
    protected BackgroundBehaviour background;
    protected ObstacleBehaviour obstacle;
    protected BlockBehaviour block;
    protected CoinBehaviour coin;
    protected EffectBehaviour effect;

    public bool IsVisible { get; protected set; }
}