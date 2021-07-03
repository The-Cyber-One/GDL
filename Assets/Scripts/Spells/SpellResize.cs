using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellResize : Spell
{
    Transform otherPlayer;

    public LayerMask targetMask, ignoreTargetMask;

    float _originalScale, originalDistance;

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
                // otherPlayer.GetComponent<Rigidbody>().isKinematic = true;
                _originalScale = otherPlayer.localScale.x;
                originalDistance = Vector3.Distance(CurrentPlayer.transform.position, otherPlayer.transform.position);
            }
        }
        if (Input.GetMouseButtonUp(0) && otherPlayer != null)
        {
            // otherPlayer.GetComponent<Rigidbody>().isKinematic = false;
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

            otherPlayer.position = hit.point - positionOffset + new Vector3(0, otherPlayer.localScale.y, 0);

            float distance = Vector3.Distance(CurrentPlayer.transform.position, otherPlayer.transform.position);
            float scaleMultiplier = distance / originalDistance;

            otherPlayer.localScale = scaleMultiplier * _originalScale * Vector3.one;
        }
    }
}
