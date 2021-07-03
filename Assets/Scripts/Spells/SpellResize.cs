using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellResize : Spell
{
    Transform otherPlayer;

    public LayerMask targetMask, ignoreTargetMask;

    float _originalScale, originalDistance;

    public Transform test;

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
            var positionOffset = CurrentPlayer.transform.forward * otherPlayer.transform.localScale.x;

            otherPlayer.position = hit.point;
            //do
            //{
            //    otherPlayer.position -= transform.forward * 0.1f;

            float distance = Vector3.Distance(CurrentPlayer.transform.position, otherPlayer.transform.position);
            float scaleMultiplier = distance / originalDistance;

            Vector3 scale = scaleMultiplier * _originalScale * Vector3.one;
            otherPlayer.localScale = scale;

            while (Physics.OverlapBox(otherPlayer.position, (otherPlayer.Find("Top").transform.position - otherPlayer.Find("Bottom").transform.position) / 2, Quaternion.identity, LayerMask.NameToLayer("Player")).Length > 0)
            {
                Debug.Log("hoi");
                otherPlayer.position -= CurrentPlayer.transform.forward * 0.1f;

                test.localScale = (otherPlayer.Find("Top").transform.position - otherPlayer.Find("Bottom").transform.position);
                test.position = otherPlayer.position;

                distance = Vector3.Distance(CurrentPlayer.transform.position, otherPlayer.transform.position);
                scaleMultiplier = distance / originalDistance;

                scale = scaleMultiplier * _originalScale * Vector3.one;
                otherPlayer.localScale = scale;
            }
            //    Debug.DrawLine(otherPlayer.position - otherPlayer.localScale / 2, otherPlayer.position + otherPlayer.localScale / 2);
            //}
            //while (Physics.CheckBox());
            //Physics.OverlapBox



            //foreach (GameObject player in players)
            //{
            //    player.transform.Find("MagicLight").GetComponent<Light>().range = scale.x;
            //    var main = player.transform.Find("ShootParticle").GetComponent<ParticleSystem>().main;
            //    main.startSize = scale.x;
            //}
        }
    }
}
