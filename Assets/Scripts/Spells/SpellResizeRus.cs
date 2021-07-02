using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellResizeRus : MonoBehaviour
{
    private Transform _target = null;

    public LayerMask ObjectLayerMask;
    public LayerMask NoObjectLayerMask;

    private float _originalScale;
    private float _originalDistance;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit objectHit;
            if (Physics.Raycast(transform.position, transform.forward, out objectHit, Mathf.Infinity, ObjectLayerMask))
            {
                _target = objectHit.transform;
                _target.GetComponent<Rigidbody>().isKinematic = true;
                _originalScale = _target.localScale.x;
                _originalDistance = Vector3.Distance(transform.position, _target.position);
            }
        }
        if (Input.GetMouseButtonUp(0) && null != _target)
        {
            _target.GetComponent<Rigidbody>().isKinematic = false;
            _target = null;
        }
    }

    private void FixedUpdate()
    {
        if (null == _target)
            return;

        RaycastHit noObjectHit;
        if (Physics.Raycast(transform.position, transform.forward, out noObjectHit, Mathf.Infinity, NoObjectLayerMask))
        {
            var positionOffset = transform.forward * _target.localScale.x;

            float distance = Vector3.Distance(transform.position, _target.position);
            float scaleMultiplier = distance / _originalDistance;

            _target.localScale = scaleMultiplier * _originalScale * Vector3.one;

            // float angle = transform.localRotation.x;
            // var x = angle > 0 : x=
            // Vector3 responsiveOffset = new Vector3(0,,0)

            // _target.position = noObjectHit.point - positionOffset + responsiveOffset;
            _target.position = noObjectHit.point - positionOffset;
            
        }
    }
}