using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;

	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				T[] managers = Object.FindObjectsOfType(typeof(T)) as T[];
				if (managers.Length != 0)
				{
					if (managers.Length == 1)
					{
						_instance = managers[0];
						_instance.gameObject.name = typeof(T).Name;
						return _instance;
					}
					else
					{
						CustomDebug.LogError($"Class {typeof(T).Name} exists multiple times in violation of singleton pattern.Destroying all copies");
						foreach (T manager in managers)
						{
							Destroy(manager.gameObject);
						}
					}
				}
                var obj = new GameObject(typeof(T).Name, typeof(T));
                _instance = obj.GetComponent<T>();
                //DontDestroyOnLoad(obj);
            }
			return _instance;
		}
		set
		{
			_instance = value as T;
		}
	}

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}