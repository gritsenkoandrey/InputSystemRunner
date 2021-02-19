using UnityEngine;

[CreateAssetMenu(fileName = "CanvasData", menuName = "Data/UI/CanvasData")]
public sealed class CanvasData : ScriptableObject
{
    internal GameMenuBehaviour gameMenuBehaviour;
    public void Initialization()
    {
        var gameMenu = CustomResources.Load<GameMenuBehaviour>
            (AssetsPathGameObject.GameObjects[GameObjectType.Canvas]);
        gameMenuBehaviour = Instantiate(gameMenu);
    }
}