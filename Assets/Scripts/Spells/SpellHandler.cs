using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHandler : MonoBehaviour
{
    public Transform playerEyes;
    public Spell activeSpell;
    public Spell[] spells;
    public bool[] unlocked;
    public List<KeyCode> keyCodes;
    public KeyCode resize = KeyCode.Alpha1, open = KeyCode.Alpha2, lightSwitch = KeyCode.Alpha3;

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
                switch (activeSpell)
                {
                    case SpellResize spellResize:
                        (spells[i] as SpellResize).Setup(playerEyes);
                        break;
                    case OpenSpell openSpell:
                        // (spells[i] as OpenSpell).Setup(playerEyes);
                        break;
                    case Darkness darkness:
                        // (spells[i] as Darkness).Setup(playerEyes);
                        break;
                    default:
                        Debug.Log("undefined spell");
                        break;
                }
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