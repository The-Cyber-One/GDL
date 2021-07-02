using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject[] buttons;
    public Color selectedColor;
    public Color normalColor;
    public Camera camera;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);

        if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, Mathf.Infinity))
        {
            GameObject hittedGameObject = hit.transform.gameObject;
            if (hittedGameObject.CompareTag("MenuButton"))
            {
                SwitchActive(hittedGameObject);

                if (Input.GetMouseButtonDown(0))
                {
                    Click(hittedGameObject.name);
                }
            }
            else
            {
                SwitchActive();
            }
        }
    }

    void SwitchActive(GameObject gameObject = null)
    {
        foreach (GameObject button in buttons)
        {
            button.GetComponent<TextMeshPro>().color = normalColor;
        }

        if (gameObject)
        {
            gameObject.GetComponent<TextMeshPro>().color = selectedColor;
        }
    }

    void Click(string name)
    {
        switch (name)
        {
            case "Play":
                animator.SetTrigger("Fade");
                break;
            case "Credits":
                break;
            case "Quit":
                Application.Quit();
                break;
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level");
    }
}
