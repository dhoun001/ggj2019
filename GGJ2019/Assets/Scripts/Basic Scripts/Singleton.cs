using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    private static object _lock = new object();
    private static bool appIsQuitting = false;
    private static GameObject _singleton = null;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static T Instance
    {
        get
        {
            if (appIsQuitting)
            {
                return null;
            }

            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    if (_instance == null)
                    {
                        Debug.LogError("Object not found. Creating new object...");
                        _singleton = new GameObject();
                        _instance = _singleton.AddComponent<T>();
                        _singleton.name = typeof(T).ToString();
                        DontDestroyOnLoad(_singleton);
                    }
                    else
                    {
                        _singleton = _instance.gameObject;
                    }
                }
                return _instance;
            }
        }
    }

    public static GameObject GameObject
    {
        get { return Instance.gameObject; }
    }

    public static Transform Transform
    {
        get { return Instance.transform; }
    }

    public void OnApplicationQuit()
    {
        appIsQuitting = true;
    }
}