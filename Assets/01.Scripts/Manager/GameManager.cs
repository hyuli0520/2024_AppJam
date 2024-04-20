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

public class GameManager : MonoSingleton<GameManager>
{
    public State curState;

    public List<Transform> _tile;
    public List<Monster> _monsters;

    public bool _isClick = false;

    public void NextState(State state)
    {
        int next = ((int)state + 1) % 4;

        curState = (State)next;
    }

    public void ReMoveTile()
    {
        if(_tile.Count >= 2)
        {
            _tile.RemoveAt(0);
            _tile.RemoveAt(_tile.Count - 1);
        }
    }
}
