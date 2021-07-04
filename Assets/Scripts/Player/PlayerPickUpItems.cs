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

    public Animator bookcaseAnimator;
    public GameObject cheeseDetector;

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
            HandleScrolls();
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
            else
            {
                bookcaseAnimator.SetTrigger("Move");
                cheeseDetector.SetActive(true);
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

            item.transform.SetParent(transform);
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
