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
    public List<AudioClip> _sounds;
    public AudioSource _audio;

    public bool _isClick = false;
    public bool _isEndMusic = false;

    public int _soundCount = 0;
    public float _time = 0;

    public void NextState(State state)
    {
        int next = ((int)state + 1) % 4;

        curState = (State)next;
    }

    void OnEnable()
    {
        SetAudio();
    }

    void Update()
    {
        _time += Time.deltaTime;
        Managers.Rank._score += (int)_time;

        if(_time >= 90 && _soundCount <= 2)
        {
            _audio.Stop();
            ReMoveTile();
            SetAudio();
            _time = 0;
        }

        if (_soundCount == 3)
            Managers.Scene.LoadScene(Define.Scene.Rank);
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

            _soundCount++;
        }
    }

    private void ReMoveTile(Transform trm)
    {
        trm.position -= Vector3.down * Time.deltaTime * 3;

        //if(trm.position.y <= -10)
    }

    public void SetAudio()
    {
        _audio.clip = _sounds[_soundCount];
        _audio.Play();
    }
}
