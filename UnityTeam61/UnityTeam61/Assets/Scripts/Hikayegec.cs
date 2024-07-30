using UnityEngine;
using TMPro;

public class PageTurner : MonoBehaviour
{
    public TextMeshProUGUI[] pages; 
    public GameObject panel; 
    private int currentPageIndex = 0;

    public void NextPage()
    {
        
        pages[currentPageIndex].gameObject.SetActive(false);

        
        if (currentPageIndex == pages.Length - 1)
        {
            panel.SetActive(false);
            return;
        }
        

        
        currentPageIndex++;
        pages[currentPageIndex].gameObject.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextPage();
        }
    }
}
