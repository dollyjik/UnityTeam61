using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;

    public string metin;
    public float yaz�H�z� = 0.1f;
   
    private void Start()
    {
        textLabel.text = "Next level, next challenge! Are you up for it?";
        metin = textLabel.text;
        StartCoroutine(Yazd�r());
    }
    IEnumerator Yazd�r()
    {
        metin = "";
        foreach (char c in metin)
        {
            metin += c;
            yield return new WaitForSeconds(yaz�H�z�);
        }
    }
}
