using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellResize : Spell
{
    Transform otherPlayer;

    public LayerMask targetMask, ignoreTargetMask;
    public float minScalePlayer = 0.1f, maxScalePlayer = 3f, minScaleObject = 0.1f, maxScaleObject = 10f;
    public bool movingCheese = false;

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
                otherPlayer = hit.transform;
                _originalScale = otherPlayer.localScale.x;
                originalDistance = Vector3.Distance(CurrentPlayer.transform.position, otherPlayer.transform.position);
                if (otherPlayer.TryGetComponent(out PlayerMovement playerMovement))
                {
                    playerMovement.useGravity = false;
                }
                else
                {
                    otherPlayer.GetComponent<Rigidbody>().isKinematic = true;
                    movingCheese = true;
                }

            }
        }
        if (Input.GetMouseButtonUp(0) && otherPlayer != null)
        {
            if (otherPlayer.TryGetComponent(out PlayerMovement playerMovement))
            {
                playerMovement.useGravity = true;
            }
            else
            {
                otherPlayer.GetComponent<Rigidbody>().isKinematic = false;
                movingCheese = false;
            }
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
            Debug.Log(LayerMask.LayerToName(hit.transform.gameObject.layer));
            otherPlayer.position = hit.point;

            ReScale();

            Transform boundingBox = otherPlayer.Find("BoundingBox");

            while (Physics.OverlapBox(otherPlayer.position, boundingBox.lossyScale / 2, boundingBox.rotation, ignoreTargetMask).Length > 0)
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

        if (otherPlayer.CompareTag("Player"))
        {
            if (scale.x < minScalePlayer) scale = Vector3.one * minScalePlayer;
            if (scale.x > maxScalePlayer) scale = Vector3.one * maxScalePlayer;
        }
        else
        {
            if (scale.x < minScaleObject) scale = Vector3.one * minScaleObject;
            if (scale.x > maxScaleObject) scale = Vector3.one * maxScaleObject;
        }

        otherPlayer.localScale = scale;
    }
}
