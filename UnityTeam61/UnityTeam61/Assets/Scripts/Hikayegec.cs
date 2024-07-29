using UnityEngine;
using TMPro;

public class PageTurner : MonoBehaviour
{
    public TextMeshProUGUI[] pages; // Tüm sayfalarý buraya atayýn
    public GameObject panel; // Panelin GameObject'i
    private int currentPageIndex = 0;

    public void NextPage()
    {
        // Mevcut sayfayý kapat
        pages[currentPageIndex].gameObject.SetActive(false);

        // Son sayfaya gelindiyse paneli kapat
        if (currentPageIndex == pages.Length - 1)
        {
            panel.SetActive(false);
            return;
        }

        // Bir sonraki sayfaya geç
        currentPageIndex++;
        pages[currentPageIndex].gameObject.SetActive(true);
    }
}
