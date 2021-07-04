using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellResize : Spell
{
    Transform otherPlayer;

    public LayerMask targetMask, ignoreTargetMask;
    public float minScale = 0.1f, maxScale = 3f;

    float _originalScale, originalDistance;

    //public Transform test;

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
                Debug.DrawLine(CurrentPlayer.transform.position, hit.point, Color.red);
                otherPlayer = hit.transform;
                _originalScale = otherPlayer.localScale.x;
                originalDistance = Vector3.Distance(CurrentPlayer.transform.position, otherPlayer.transform.position);
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
            otherPlayer.position = hit.point;

            ReScale();

            Transform boundingBox = otherPlayer.Find("BoundingBox");

            while (Physics.OverlapBox(otherPlayer.position, boundingBox.lossyScale / 2, boundingBox.rotation, LayerMask.NameToLayer("Player")).Length > 0)
            {
                otherPlayer.position -= CurrentPlayer.transform.forward * 0.1f;
                ReScale();

                //test.localScale = boundingBox.lossyScale;
                //test.position = boundingBox.position;
                //test.rotation = boundingBox.rotation;

            }

            //foreach (GameObject player in players)
            //{
            //    player.transform.Find("MagicLight").GetComponent<Light>().range = scale.x;
            //    var main = player.transform.Find("ShootParticle").GetComponent<ParticleSystem>().main;
            //    main.startSize = scale.x;
            //}
        }
    }

    private void ReScale()
    {
        float distance = Vector3.Distance(CurrentPlayer.transform.position, otherPlayer.transform.position);
        float scaleMultiplier = distance / originalDistance;

        Vector3 scale = scaleMultiplier * _originalScale * Vector3.one;

        if (scale.x < minScale) scale = Vector3.one * minScale;
        if (scale.x > maxScale) scale = Vector3.one * maxScale;

        otherPlayer.localScale = scale;
    }
}
