using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer sprite;

    private int _curTile;
    private int _tileCount;

    private bool _isMove = true;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        _tileCount = GameManager.Instance._tile.Count;
        _curTile = _tileCount / 2;

        transform.position = tilePos();
    }

    private void Update()
    {
        if (GameManager.Instance._isClick && _isMove)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (_curTile < _tileCount - 1)
                    _curTile++;

                transform.position = tilePos();
                sprite.flipX = true;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (_curTile > 0)
                    _curTile--;

                transform.position = tilePos();
                sprite.flipX = false;
            }

            _isMove = false;
        }
        else
            _isMove = true;
    }

    private Vector3 tilePos()
    {
        return GameManager.Instance._tile[_curTile].position + new Vector3(0, 1, 0);
    }

    public void Damage()
    {

    }
}
