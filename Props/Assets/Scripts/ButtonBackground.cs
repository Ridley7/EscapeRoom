using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBackground : MonoBehaviour
{
    public GameObject window;

    public void DisableBackground()
    {
        window.gameObject.SetActive(false);
    }
}
