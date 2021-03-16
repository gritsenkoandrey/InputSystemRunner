using UnityEngine;

public sealed class LightService : Service
{
    public void InitLight()
    {
        var light = CustomResources.Load<GameObject>
            (AssetsPathGameObject.GameObjects[GameObjectType.Light]).GetComponent<Light>();
        Object.Instantiate(light);
    }
}