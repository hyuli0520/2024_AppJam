using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Start : UI_Popup
{
    enum Buttons
    {
        StartButton,
        SettingButton,
        ExitButton,
        CloseSettingButton,
    }

    enum Texts
    {
        StartText,
        SettingText,
        ExitText,
        CloseSettingText,
    }

    enum Images
    {

    }

    enum GameObjects
    {
        SettingPanel,
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

        GetButton((int)Buttons.StartButton).gameObject.AddUIEvent(OnClickStartButton);
        GetButton((int)Buttons.SettingButton).gameObject.AddUIEvent(OnClickSettingButton);
        GetButton((int)Buttons.ExitButton).gameObject.AddUIEvent(OnClickExitButton);
        GetButton((int)Buttons.CloseSettingButton).gameObject.AddUIEvent(OnClickCloseSettingButton);

        Get<GameObject>((int)GameObjects.SettingPanel).gameObject.SetActive(false);
    }

    void OnClickStartButton(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.Game);
    }
    void OnClickSettingButton(PointerEventData data)
    {
        Get<GameObject>((int)GameObjects.SettingPanel).gameObject.SetActive(true);
    }
    void OnClickExitButton(PointerEventData data)
    {
        Application.Quit();
    }
    void OnClickCloseSettingButton(PointerEventData data)
    {
        Get<GameObject>((int)GameObjects.SettingPanel).gameObject.SetActive(false);
    }
}
