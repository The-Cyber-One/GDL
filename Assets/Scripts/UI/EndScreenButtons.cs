using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreenButtons : MonoBehaviour
{

    public TMP_Text text;

    string currentText;

    public Color selectionColor;

    bool menuButton;
    // Start is called before the first frame update
    void Start()
    {
        currentText = text.text;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnMouseOver()
    {
        text.color = selectionColor;

        if (Input.GetMouseButtonDown(0) && currentText == "Menu")
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (Input.GetMouseButtonDown(0) && currentText == "Quit")
        {
            Application.Quit();
        }
    }

    private void OnMouseExit()
    {
        text.color = Color.black;
    }
}
