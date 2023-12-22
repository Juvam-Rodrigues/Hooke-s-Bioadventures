using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOndaTexto : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("DisableTexto", 2f);
    }

    private void DisableTexto()
    {
        gameObject.SetActive(false);
    }
}
