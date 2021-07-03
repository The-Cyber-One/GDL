using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellResize : Spell
{
    Transform otherPlayer;

    public LayerMask targetMask, ignoreTargetMask;
    public Vector3 minScale = new Vector3(.3f, .3f, .3f), maxScale = new Vector3(5, 5, 5);

    float _originalScale, originalDistance;
    LayerMask _target1Mask, _target2Mask;

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        ResizeRescaleOther();
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(CurrentPlayer.transform.position, CurrentPlayer.transform.forward, out hit, Mathf.Infinity, targetMask))
            {
                if (CurrentPlayer.transform.parent != hit.transform)
                {
                    otherPlayer = hit.transform;
                    _originalScale = otherPlayer.localScale.x;
                    originalDistance = Vector3.Distance(CurrentPlayer.transform.position, otherPlayer.transform.position);
                }
            }
        }
        if (Input.GetMouseButtonUp(0) && otherPlayer != null)
        {
            otherPlayer = null;
        }
    }

    void ResizeRescaleOther()
    {
        if (otherPlayer == null)
        {
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(CurrentPlayer.position, CurrentPlayer.transform.forward, out hit, Mathf.Infinity, ignoreTargetMask))
        {
            float offset;
            if (CurrentPlayer.GetComponentInChildren<Camera>().transform.rotation.x < 0)
            {
                offset = 0;
            }
            else
            {
                offset = otherPlayer.transform.localScale.y;
            }

            var positionOffset = CurrentPlayer.transform.forward * otherPlayer.transform.localScale.x;

            otherPlayer.position = hit.point - positionOffset + new Vector3(0, offset, 0);

            float distance = Vector3.Distance(CurrentPlayer.transform.position, otherPlayer.transform.position);
            float scaleMultiplier = distance / originalDistance;

            Vector3 scale = scaleMultiplier * _originalScale * Vector3.one;

            //minmax
            if (scale.x < minScale.x)
            {
                scale = minScale;
            }
            else if (scale.x > maxScale.x)
            {
                scale = maxScale;
            }

            otherPlayer.localScale = scale;

            //foreach (GameObject player in players)
            //{
            //    player.transform.Find("MagicLight").GetComponent<Light>().range = scale.x;
            //    var main = player.transform.Find("ShootParticle").GetComponent<ParticleSystem>().main;
            //    main.startSize = scale.x;
            //}
        }
    }
}
