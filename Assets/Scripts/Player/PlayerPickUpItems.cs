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

    public SpellHandler spellHandler;

    public Image[] itemBoxes;

    bool playerHasCollisionItem;
    bool playerPicksUpItem;

    // Start is called before the first frame update
    void Start()
    {
        pickUp.enabled = false;

        foreach (Image image in itemBoxes)
        {
            image.GetComponent<Image>();
            image.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (item != null)
        {
            if (item.gameObject.CompareTag("Scroll") || item.gameObject.CompareTag("FinalScrollPart1"))
            {
                HandleScrolls();
            }
            else
            {
                HandleItem();
            }
        }

    }
    private void HandleItem()
    {
        //If the player is already holding the item
        if (Input.GetKeyDown(KeyCode.X) && playerPicksUpItem)
        {
            item.transform.position = new Vector3(transform.forward.x * 0.6f, transform.forward.y * -10f, transform.forward.z * 0.6f) + transform.position;
            item.transform.position = new Vector3(item.transform.position.x, 0, item.transform.position.z);

            pickUp.SetText("Press X to pick up");
            playerPicksUpItem = false;
            item.transform.parent = null;
            item = null;
            playerHasCollisionItem = false;
            pickUp.enabled = false;
            playerHasCollisionItem = false;
        }
        //If the player wants to pick up the item
        else if (Input.GetKeyDown(KeyCode.X) && playerHasCollisionItem)
        {
            item.transform.position = new Vector3(transform.forward.x * 0.6f, transform.forward.y * -2f, transform.forward.z * 0.6f) + transform.position;

            item.transform.LookAt(transform.position);

            item.transform.rotation *= Quaternion.Euler(-90, 0, 0);

            item.transform.parent = transform;
            pickUp.SetText("Press X to release");
            playerPicksUpItem = true;

            Debug.Log("PickUp");
        }
    }
    private void HandleScrolls()
    {
        //If the player is already holding the item
        if (Input.GetKeyDown(KeyCode.X) && playerPicksUpItem)
        {
            itemImage = item.GetComponent<Image>();

            foreach (Image image in itemBoxes)
            {
                if (!image.enabled)
                {
                    image.sprite = itemImage.sprite;
                    image.enabled = true;
                    break;
                }
            }
            if (!item.gameObject.CompareTag("FinalScrollPart1"))
            {
                spellHandler.UnlockNextSpell();
            }

            item.SetActive(false);
            item = null;
            pickUp.SetText("Press X to pick up");
            pickUp.enabled = false;
            playerPicksUpItem = false;

        }
        //If the player wants to pick up the item
        else if (Input.GetKeyDown(KeyCode.X) && playerHasCollisionItem)
        {
            item.transform.position = transform.position + transform.forward / 2;

            item.transform.LookAt(transform);

            item.transform.Rotate(new Vector3(0, 90, 90));

            item.transform.parent = transform;
            pickUp.SetText("Press X to put away");
            playerPicksUpItem = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Scroll" || other.gameObject.tag == "FinalScrollPart1" || other.gameObject.tag == "Item")
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
