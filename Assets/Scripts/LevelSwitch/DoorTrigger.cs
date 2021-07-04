using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public string sceneToLoad;
    Animator anim;
    GameObject doorTrigger;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("StartFading", true);
        }
    }

    public void SwitchScene()
    {
        SceneManager.LoadSceneAsync(sceneToLoad);
    }
}
