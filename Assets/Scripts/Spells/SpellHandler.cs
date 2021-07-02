using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    public List<Spell> spells;
    public ParticleSystem shootPS;
    public Transform playerEyes;
    public float range = 50f;
    public float fireRate = 1, nextFire;

    Camera FPS;

    // Start is called before the first frame update
    void Start()
    {
        FPS = playerEyes.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = FPS.ViewportToScreenPoint(new Vector3(.5f, .5f, .0f));
        Debug.DrawRay(FPS.transform.position, FPS.transform.forward * range, Color.green);

        RaycastHit hit;
        if (Physics.Raycast(playerEyes.transform.position, FPS.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawLine(playerEyes.transform.position, hit.point, Color.blue);
        }
    }
}
