using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{

    private static T instance = null;


    public static T Instance
    {
        get
        {

            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<T>() as T;

                if (instance)
                    instance = new GameObject("Monosingleton Of " + typeof(T).ToString(), typeof(T)).GetComponent<T>();
            }
            return instance;
        }
    }


    public void Awake()
    {
        if (instance == null)
            instance = this as T;
    }

    private void OnApplicationQuit()
    {
        instance = null;
    }
}
