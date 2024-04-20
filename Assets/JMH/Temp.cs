using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    void Start()
    {
        Managers managers = Managers.instance;

        UI_Popup ui = Managers.UI.ShowPopupUI<UI_Main>();

    }
}
