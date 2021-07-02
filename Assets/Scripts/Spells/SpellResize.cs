using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellResize : Spell
{
    Transform otherPlayer;
    Transform root;
    float initialSize, initialDistance, finalDistance;
    public LayerMask NoObjectLayerMask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && otherPlayer != null)
        {
            otherPlayer = null;
        }
    }

    void FixedUpdate()
    {
        if (otherPlayer == null)
        {
            return;
        }

        RaycastHit noObjectHit;
        if (Physics.Raycast(root.transform.position, root.transform.forward, out noObjectHit, Mathf.Infinity, NoObjectLayerMask))
        {
            var positionOffset = root.transform.forward * otherPlayer.localScale.x;

            otherPlayer.transform.position = noObjectHit.point - positionOffset;

            float distance = noObjectHit.distance;
            float scaleMultiplier = distance / initialDistance;

            otherPlayer.localScale = scaleMultiplier * initialSize * Vector3.one;
        }
    }

    void OnDisable()
    {
        otherPlayer = null;
    }

    public void EnableMe(RaycastHit hit)
    {
        otherPlayer = hit.transform;
        root = hit.transform;
        initialSize = otherPlayer.transform.localScale.x;
        initialDistance = hit.distance;
    }
}
