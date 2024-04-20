using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_Instance;
    public static Managers instance { get { Init(); return s_Instance; } }

    #region Managers
    ResourceManager _resource = new ResourceManager();

    public static ResourceManager Resource { get { return instance._resource; } }
    #endregion

    void Start()
    {
        Init();
    }

    static void Init()
    {
        if(s_Instance == null)
        {
            GameObject obj = GameObject.Find("@Managers");
            if(obj == null)
            {
                obj = new GameObject { name = "@Managers" };
                obj.AddComponent<Managers>();
            }

            DontDestroyOnLoad(obj);
            s_Instance = obj.GetComponent<Managers>();
        }
    }
}
