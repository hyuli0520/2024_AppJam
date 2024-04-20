using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : BaseScene
{
    void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Start;

        Managers.UI.ShowPopupUI<UI_Start>();
    }

    public override void Clear()
    {
       
    }
}
