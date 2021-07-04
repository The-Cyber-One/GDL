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
    DarknessSpell darknessSpell;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Spell spell in spells)
        {
            spell.transform.gameObject.SetActive(false);
            if (spell is DarknessSpell)
            {
                darknessSpell = (spell as DarknessSpell);
            }
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
        for (int i = keyCodes.Count - 1; i >= 0; i--)
        {
            if (Input.GetKeyDown(keyCodes[i]) && unlocked[i])
            {
                activeSpell = spells[i];
                MakeActive();
            }
        }

        bool anyConcentrating = false;
        foreach (GameObject player in playersController.players)
        {
            if (player.GetComponent<Concentrating>().Concentrate)
            {
                anyConcentrating = true;
            }
        }

        darknessSpell.lightsOffAnim.SetBool("concentrating", anyConcentrating);
        if (darknessSpell.scrollLight.gameObject.activeInHierarchy)
        {
            darknessSpell.scrollLight.SetBool("concentrating", anyConcentrating);
        }
    }

    public void SpellSetup(GameObject[] players, Camera cam)
    {
        foreach (Spell spell in spells)
        {
            if (activeSpell = spell)
            {
                spell.Setup(cam.transform, players);
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