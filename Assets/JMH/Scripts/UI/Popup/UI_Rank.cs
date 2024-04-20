using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Rank : UI_Popup
{
    enum Buttons
    {
        CloseButton,
        RegisterNameButton,
    }

    enum Texts
    {
        CloseText,
        InputNameText,
        RegisterNameText,

        RankName1,
        RankName2,
        RankName3,
        RankName4,
        RankName5,

        RankScore1,
        RankScore2,
        RankScore3,
        RankScore4,
        RankScore5,
    }

    enum Images
    {

    }

    enum GameObjects
    {
        RankPanel,
        ShowRankPanel,
        InputName,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));

        GetButton((int)Buttons.CloseButton).gameObject.AddUIEvent(OnClickCloseButton);
        GetButton((int)Buttons.RegisterNameButton).gameObject.AddUIEvent(OnClickRegisterName);
    }

    void OnClickCloseButton(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.Start);
    }
    void OnClickRegisterName(PointerEventData data)
    {
        Managers.Rank._name = GetText((int)Texts.InputNameText).text;

        Managers.Rank.AddRank();

        GetText((int)Texts.RankName1).text = Managers.Rank._ranks[0]._bestName;
        GetText((int)Texts.RankName2).text = Managers.Rank._ranks[1]._bestName;
        GetText((int)Texts.RankName3).text = Managers.Rank._ranks[2]._bestName;
        GetText((int)Texts.RankName4).text = Managers.Rank._ranks[3]._bestName;
        GetText((int)Texts.RankName5).text = Managers.Rank._ranks[4]._bestName;

        GetText((int)Texts.RankScore1).text = Managers.Rank._ranks[0]._bestScore.ToString();
        GetText((int)Texts.RankScore2).text = Managers.Rank._ranks[1]._bestScore.ToString();
        GetText((int)Texts.RankScore3).text = Managers.Rank._ranks[2]._bestScore.ToString();
        GetText((int)Texts.RankScore4).text = Managers.Rank._ranks[3]._bestScore.ToString();
        GetText((int)Texts.RankScore5).text = Managers.Rank._ranks[4]._bestScore.ToString();
    }
}
