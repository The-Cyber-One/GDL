using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concentrating : MonoBehaviour
{
    PlayersController playersController;

    public bool concentrate;

    public bool Concentrate
    {
        get { return concentrate; }
        set { concentrate = value; }
    }
}
