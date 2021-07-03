using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    private Light[] lights;
    
    [SerializeField]
    private Animator lightsOffAnim;

    void Start()
    {
        lights = FindObjectsOfType(typeof(Light)) as Light[];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
		{
            lightsOffAnim.SetTrigger("PlayAnim");
        }
    }
}
