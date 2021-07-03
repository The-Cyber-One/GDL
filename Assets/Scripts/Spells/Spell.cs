using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    Transform currentPlayer;
    public Gradient spellColor;
    protected GameObject[] players;

    public Transform CurrentPlayer
    {
        get { return currentPlayer; }
        set { currentPlayer = value; }
    }

    public virtual void Setup(Transform _player, GameObject[] _players)
    {
        CurrentPlayer = _player;
        players = _players;
    }

    private void OnEnable()
    {
        SetColor();
    }

    public void SetColor()
    {
        foreach (GameObject player in players)
        {
            var color = player.transform.Find("ShootParticle").GetComponent<ParticleSystem>().colorOverLifetime;
            color.enabled = true;
            color.color = spellColor;

            player.transform.Find("MagicBall").GetComponent<Renderer>().material.color = spellColor.colorKeys[0].color;
            player.transform.Find("MagicBall").GetComponent<Renderer>().material.SetColor("_EmissionColor", spellColor.colorKeys[0].color);

            player.transform.Find("MagicLight").GetComponent<Light>().color = spellColor.colorKeys[0].color;
        }
    }
}
