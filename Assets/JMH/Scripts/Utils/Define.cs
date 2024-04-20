using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{
    public enum Scene
    {
        Unkown,
        Start,
        Game,
        Rank,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }
}
