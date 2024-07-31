using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
    }

    public void OpenLevel(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }
}