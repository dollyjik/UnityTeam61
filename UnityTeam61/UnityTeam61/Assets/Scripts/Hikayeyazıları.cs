using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hikayeyazıları : MonoBehaviour
{
    public GameObject nesne;
    public bool gec = true;
    public void AcKapa()
    {
        if (gec)
        {
            nesne.SetActive(false);
           
            gec = false;
        }
        else if (!gec)
        {
            nesne.SetActive(true);
            gec = true;
        }

    }
}

