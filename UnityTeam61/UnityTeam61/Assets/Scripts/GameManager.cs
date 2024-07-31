using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMovement PlayerMovementScript;
    
    public int enemyCount;

    public bool isGamePaused = false;
    
    public GameObject winUI;
    public GameObject loseUI;
    public GameObject pauseUI;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        winUI.SetActive(false);
        loseUI.SetActive(false);
        pauseUI.SetActive(false);
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("EnemyTag");
        enemyCount = taggedObjects.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovementScript.isMoveMade == true)
        {
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("EnemyTag");
            enemyCount = taggedObjects.Length;
        }
        
        if (enemyCount == 0)
        {
            winUI.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.P) && isGamePaused == false)
        {
            Debug.Log("Game Paused");
            isGamePaused = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (enemyCount > 0 && PlayerMovementScript.isMoveMade == true)
        {
            Time.timeScale = 0;
            loseUI.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Debug.Log("Game Unpaused");
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void TryAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
