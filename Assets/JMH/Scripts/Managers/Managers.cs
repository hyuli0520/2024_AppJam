using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_Instance;
    public static Managers instance { get { Init(); return s_Instance; } }

    #region Managers
    ResourceManager _resource = new ResourceManager();
    UIManager _ui = new UIManager();
    SceneManagerEx _scene = new SceneManagerEx();
    RankManager _rank = new RankManager();
    SoundManager _sound = new SoundManager();

    public static ResourceManager Resource { get { return instance._resource; } }
    public static UIManager UI { get { return instance._ui; } }
    public static SceneManagerEx Scene { get {  return instance._scene; } }
    public static RankManager Rank { get {  return instance._rank; } }
    public static SoundManager Sound { get {  return instance._sound; } }
    #endregion

    void Start()
    {
        Init();
    }

    static void Init()
    {
        if(s_Instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_Instance = go.GetComponent<Managers>();
        }
    }
}
