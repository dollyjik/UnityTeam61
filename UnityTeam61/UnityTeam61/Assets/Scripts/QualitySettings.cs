using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualitySettings : MonoBehaviour
{
    public Dropdown Menu;



    private void Start()
    {
        if (PlayerPrefs.HasKey("qualityPreference"))
        {
            Menu.value = PlayerPrefs.GetInt("qualityPreference");
            UnityEngine.QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualityPreference"));

        }
            else
        {
            PlayerPrefs.SetInt("qualityPreference", 1);
            Menu.value = 1;
        }

    }
    public void setQualityPreference(int qualityPreference)

    {
        UnityEngine.QualitySettings.SetQualityLevel(qualityPreference);
        PlayerPrefs.SetInt("qualityPreference", qualityPreference);
    }

}