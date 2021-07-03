using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    public PlayersController playersController;
    public Spell activeSpell;
    public Spell[] spells;
    public bool[] unlocked;

    KeyCode resize = KeyCode.Alpha1, open = KeyCode.Alpha2, lightSwitch = KeyCode.Alpha3;
    List<KeyCode> keyCodes;
    public Camera playerEyes;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        playerEyes = playersController.ActivePlayerCamera();
        foreach (Spell spell in spells)
        {
            if (activeSpell = spell)
            {
                spell.Setup(playerEyes.transform);
            }
        }

        for (int i = keyCodes.Count - 1; i >= 0; i--)
        {
            if (Input.GetKeyDown(keyCodes[i]) && unlocked[i])
            {
                activeSpell = spells[i];
                MakeActive();
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

    public void UnlockNextSpell()
    {
        for (int i = 0; i < unlocked.Length; i++)
        {
            if (!unlocked[i])
            {
                unlocked[i] = true;
                return;
            }
        }
    }
}