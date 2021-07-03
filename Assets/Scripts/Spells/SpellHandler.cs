using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    public KeyCode resize = KeyCode.Alpha1, open = KeyCode.Alpha2, lightSwitch = KeyCode.Alpha3;
    public PlayersController playersController;
    public Transform playerEyes;
    public Spell activeSpell;
    public Spell[] spells;
    public bool[] unlocked;

    List<KeyCode> keyCodes;
    Camera FPS;

    // Start is called before the first frame update
    void Start()
    {
        FPS = playerEyes.GetComponent<Camera>();

        spells = GetComponentsInChildren<Spell>();
        foreach (Spell spell in spells)
        {
            spell.transform.gameObject.SetActive(false);
        }
        unlocked = new bool[spells.Length];

        keyCodes = new List<KeyCode>();
        keyCodes.Add(resize);
        keyCodes.Add(open);
        keyCodes.Add(lightSwitch);

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = keyCodes.Count - 1; i >= 0; i--)
        {
            if (Input.GetKeyDown(keyCodes[i]) && unlocked[i])
            {
                activeSpell = spells[i];
                MakeActive();
                (spells[i] as Spell).Setup(playerEyes);
            }
        }
    }

    void MakeActive()
    {
        foreach (Spell spell in spells)
        {
            if (activeSpell == spell)
            {
                spell.gameObject.SetActive(true);
            }
            else
            {
                spell.gameObject.SetActive(false);
            }
        }
    }
}