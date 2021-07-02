using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSpell : MonoBehaviour
{

    public bool openSpellUnlocked;
    bool openTheDoor;
    public GameObject doorRight;
    public GameObject doorLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (openSpellUnlocked)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                openTheDoor = true;
            }
            if (openTheDoor)
            {
                doorLeft.transform.rotation = Quaternion.Lerp(doorLeft.transform.rotation, Quaternion.Euler(-90, 0, -120), 0.001f);
                doorRight.transform.rotation = Quaternion.Lerp(doorRight.transform.rotation, Quaternion.Euler(-90, -0, 120), 0.001f);
            }
        }
    }
}
