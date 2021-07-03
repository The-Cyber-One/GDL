using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPickUpItems : MonoBehaviour
{

    public TMP_Text pickUp;
    GameObject item;
    Image itemImage;

    public Image itemBox1Forground;
    public Image itemBox2Forground;
    public Image itemBox3Forground;

    bool playerHasCollisionItem;
    bool playerPicksUpItem;

    bool boxOneTaken;
    bool boxTwoTaken;
    bool boxThreeTaken;

    // Start is called before the first frame update
    void Start()
    {
        pickUp.enabled = false;

        itemBox1Forground.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && playerPicksUpItem)
        {
            itemImage = item.GetComponent<Image>();

            if (!boxOneTaken)
            {
                itemBox1Forground.sprite = itemImage.sprite;
                boxOneTaken = true;
            }else if (!boxTwoTaken)
            {
                itemBox2Forground.sprite = itemImage.sprite;
                boxTwoTaken = true;
            }
            else if (!boxThreeTaken)
            {
                itemBox3Forground.sprite = itemImage.sprite;
                boxThreeTaken = true;
            }

            item.SetActive(false);
            pickUp.SetText("Press X to put away");
            pickUp.enabled = false;
            playerPicksUpItem = false;

        }
        else if (Input.GetKeyDown(KeyCode.X) && playerHasCollisionItem)
        {
            item.transform.position = new Vector3(0, 0.5f, transform.forward.z * 1.5f) + transform.position;

            item.transform.LookAt(transform.position);

            item.transform.rotation *= Quaternion.Euler(45, 0, 0);

            item.transform.parent = transform;
            pickUp.SetText("Press X to put away");
            playerPicksUpItem = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            pickUp.enabled = true;
            item = other.gameObject;
            playerHasCollisionItem = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (!playerPicksUpItem)
        {
            pickUp.enabled = false;
            playerHasCollisionItem = false;
        }
    }
}
