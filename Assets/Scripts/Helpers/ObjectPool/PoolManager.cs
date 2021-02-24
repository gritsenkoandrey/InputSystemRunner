using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
	[SerializeField] private bool _logStatus;
    private bool _dirty = false;

	private Transform _root;

	private Dictionary<GameObject, ObjectPool<GameObject>> _prefabLookup;
	private Dictionary<GameObject, ObjectPool<GameObject>> _instanceLookup; 
	
	private void Awake ()
    {
        _root = new GameObject().transform;
        _root.name = "Created Pool";

		_prefabLookup = new Dictionary<GameObject, ObjectPool<GameObject>>();
		_instanceLookup = new Dictionary<GameObject, ObjectPool<GameObject>>();
	}

	private void Update()
	{
		if(_logStatus && _dirty)
		{
			PrintStatus();
			_dirty = false;
		}
	}

	private void Warm(GameObject prefab, int size)
	{
		prefab.gameObject.SetActive(false);

		if(_prefabLookup.ContainsKey(prefab))
		{
			throw new Exception("Pool for prefab " + prefab.name + " has already been created");
		}
		var pool = new ObjectPool<GameObject>(() => { return InstantiatePrefab(prefab); }, size);
		_prefabLookup[prefab] = pool;
		_dirty = true;
	}

	private GameObject Spawn(GameObject prefab)
	{
		return Spawn(prefab, Vector3.zero, Quaternion.identity);
	}

	private GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
	{
		if (!_prefabLookup.ContainsKey(prefab))
		{
			WarmPool(prefab, 1);
		}

		var pool = _prefabLookup[prefab];

		var clone = pool.GetItem();
		clone.transform.position = position;
		clone.transform.rotation = rotation;
		clone.SetActive(true);

		_instanceLookup.Add(clone, pool);
		_dirty = true;
		return clone;
	}

	private void Release(GameObject clone)
	{
		clone.SetActive(false);

		if(_instanceLookup.ContainsKey(clone))
		{
			_instanceLookup[clone].ReleaseItem(clone);
			_instanceLookup.Remove(clone);
			_dirty = true;
		}
		else
		{
			Debug.LogWarning("No pool contains the object: " + clone.name);
		}
	}


	private GameObject InstantiatePrefab(GameObject prefab)
	{
		var go = Instantiate(prefab) as GameObject;
        if (_root != null)
        {
            go.transform.parent = _root;
        }
		return go;
	}

	public void PrintStatus()
	{
		foreach (KeyValuePair<GameObject, ObjectPool<GameObject>> keyVal in _prefabLookup)
		{
			Debug.Log(string.Format("Object Pool for Prefab: {0} In Use: {1} Total {2}", keyVal.Key.name, keyVal.Value.CountUsedItems, keyVal.Value.Count));
		}
	}

	#region Static API

	public static void WarmPool(GameObject prefab, int size)
	{
		Instance.Warm(prefab, size);
	}

	public static GameObject SpawnObject(GameObject prefab)
	{
		return Instance.Spawn(prefab);
	}

	public static GameObject SpawnObject(GameObject prefab, Vector3 position, Quaternion rotation)
	{
		return Instance.Spawn(prefab, position, rotation);
	}

	public static void ReleaseObject(GameObject clone)
	{
		Instance.Release(clone);
	}

	#endregion
}