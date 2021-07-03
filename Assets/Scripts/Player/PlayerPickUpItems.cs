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

    int count;
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
            if (item.gameObject.tag == "Scroll")
            {
                //spellHandler.UnlockNextSpell();
            }

            item.SetActive(false);
            item = null;
            pickUp.SetText("Press X to pick up");
            pickUp.enabled = false;
            playerPicksUpItem = false;

        }
        else if (Input.GetKeyDown(KeyCode.X) && playerHasCollisionItem)
        {
            item.transform.position = new Vector3(transform.forward.x * 0.5f, transform.forward.y * -0.5f, 0) + transform.position;

            item.transform.LookAt(transform.position);

            item.transform.rotation *= Quaternion.Euler(0, 90, 75);

            item.transform.parent = transform;
            pickUp.SetText("Press X to put away");
            playerPicksUpItem = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Scroll" || other.gameObject.tag == "FinalScrollPart1")
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
