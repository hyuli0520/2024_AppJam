using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Intro,
    Main,
    InGame,
    Ending
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public State curState;

    public bool _isClick = false;

    private void Start()
    {
        instance = this;
    }

    public void NextState(State state)
    {
        int next = ((int)state + 1) % 4;

        curState = (State)next;

    }
}
