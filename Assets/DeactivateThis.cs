using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateThis : MonoBehaviour
{
    public void DeactivateSelf()
    {
        Debug.Log("im off");
        gameObject.SetActive(false);
    }
}
