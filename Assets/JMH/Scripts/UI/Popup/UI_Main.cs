using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Main : UI_Popup
{
    enum Buttons
    {
        RetryButton,
    }

    enum Texts
    {
        ComboText,
        DeadText,
        RetryText,
    }

    enum GameObjects
    {
        Alive,
        Dead,
    }

    enum Images
    {
        PlayerHp1,
        PlayerHp2,
        PlayerHp3,
        PlayerHpBorder1,
        PlayerHpBorder2,
        PlayerHpBorder3,
        ItemBackgournd,
        ItemIcon,
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

        Get<GameObject>((int)GameObjects.Alive).SetActive(true);
        Get<GameObject>((int)GameObjects.Dead).SetActive(false);
        GetButton((int)Buttons.RetryButton).gameObject.AddUIEvent(OnClickRetry);
    }

    public void OnDeleteHp(PointerEventData data)
    {
        Managers.UI.playerHp--;

        Debug.Log($"버튼 클릭됨 남은 체력 : {Managers.UI.playerHp}");

        if (Managers.UI.playerHp == 2)
            GetImage((int)Images.PlayerHp3).gameObject.SetActive(false);
        if (Managers.UI.playerHp == 1)
            GetImage((int)Images.PlayerHp2).gameObject.SetActive(false);
        if (Managers.UI.playerHp == 0)
        {
            GetImage((int)Images.PlayerHp1).gameObject.SetActive(false);
            Get<GameObject>((int)GameObjects.Alive).SetActive(false);
            Get<GameObject>((int)GameObjects.Dead).SetActive(true);
        }

    }
    public void OnClickRetry(PointerEventData data)
    {
        Debug.Log("Retry");
    }

}
