using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    Transform currentPlayer;

    public Transform CurrentPlayer
    {
        get { return currentPlayer; }
        set { currentPlayer = value; }
    }

    public virtual void Setup(Transform _player)
    {
        CurrentPlayer = _player;
    }
}
