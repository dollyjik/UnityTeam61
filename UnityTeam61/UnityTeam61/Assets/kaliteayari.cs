using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class kaliteayari : MonoBehaviour
{
    public Dropdown Kalitemenu;



    private void Start()
    {
        if (PlayerPrefs.HasKey("kalitetercihi"))
        {
            Kalitemenu.value = PlayerPrefs.GetInt("kalitetercihi");
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("kalitetercihi"));

        }
        else
        {
            PlayerPrefs.SetInt("kalitetercihi", 1);
            Kalitemenu.value = 1;
        }

    }
    public void KaliteAyari(int kaliteTercihi)

    {
        QualitySettings.SetQualityLevel(kaliteTercihi);
        PlayerPrefs.SetInt("kalitetercihi", kaliteTercihi);
    }
   
}
