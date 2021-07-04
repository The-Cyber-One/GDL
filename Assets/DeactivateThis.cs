using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateThis : MonoBehaviour
{
    public void DeactivateSelf()
    {
        gameObject.SetActive(false);
    }
}
