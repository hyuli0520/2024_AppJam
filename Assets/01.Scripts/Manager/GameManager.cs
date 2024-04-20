using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    public bool _isEndMusic = false;

    public void NextState(State state)
    {
        int next = ((int)state + 1) % 4;

        curState = (State)next;
    }

    public void ReMoveTile()
    {
        if (_tile.Count >= 2)
        {
            Transform left = _tile[0];
            Transform right = _tile[_tile.Count - 1];

            _tile.Remove(left);
            _tile.Remove(right);

            Destroy(left.gameObject);
            Destroy(right.gameObject);

            ReMoveTile(left);
            ReMoveTile(right);
        }
    }

    private void ReMoveTile(Transform trm)
    {
        trm.position -= Vector3.down * Time.deltaTime * 3;

        //if(trm.position.y <= -10)
    }
}
