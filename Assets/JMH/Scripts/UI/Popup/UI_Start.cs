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
        ExitButton,
    }

    enum Texts
    {
        StartText,
        ExitText,
    }

    enum Images
    {

    }

    enum GameObjects
    {

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
        GetButton((int)Buttons.ExitButton).gameObject.AddUIEvent(OnClickExitButton);
    }

    void OnClickStartButton(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.Game);
    }
    void OnClickExitButton(PointerEventData data)
    {
        Application.Quit();
    }
}
