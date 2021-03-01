using UnityEngine;

public sealed class EffectService : Service
{
    private readonly EffectData _data;

    public GameObject Particle { get; }

    public EffectService()
    {
        _data = Data.Instance.EffectData;
        Particle = _data.effect;
    }

    public void CreateEffectWithColorObject(BaseItem item, Vector3 pos)
    {
        var color = item.GetComponentInChildren<MeshRenderer>().material.color;
        var particle = PoolManager.SpawnObject(Particle, pos, Quaternion.identity)
            .GetComponent<ParticleSystem>().main;
        particle.startColor = color;
    }
}