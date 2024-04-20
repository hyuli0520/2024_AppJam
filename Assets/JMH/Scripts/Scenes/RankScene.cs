using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankScene : BaseScene
{
    void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Rank;

        Managers.UI.ShowPopupUI<UI_Rank>();
    }

    public override void Clear()
    {

    }
}
