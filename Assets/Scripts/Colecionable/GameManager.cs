//using UnityEngine;
//using TMPro;

//public class GameManager : MonoBehaviour
//{
//    public static GameManager instance;

//    [Header("Coleccionables")]
//    public int totalCollectibles = 5;
//    private int currentCollectibles = 0;
//    public TMP_Text collectibleText;

//    [Header("UI Final")]
//    public GameObject winText;
//    public GameObject loseText;

//    void Awake()
//    {
//        instance = this;
//    }

//    void Start()
//    {
//        currentCollectibles = 0;
//        collectibleText.text = "0 / " + totalCollectibles;

//        winText.SetActive(false);
//        loseText.SetActive(false);
//    }

//    public void AddCollectible()
//    {
//        currentCollectibles++;
//        collectibleText.text = currentCollectibles + " / " + totalCollectibles;

//        if (currentCollectibles >= totalCollectibles)
//        {
//            WinGame();
//        }
//    }

//    public void WinGame()
//    {
//        winText.SetActive(true);
//        Time.timeScale = 0;
//    }

//    public void LoseGame()
//    {
//        loseText.SetActive(true);
//        Time.timeScale = 0;
//    }
//}

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Coleccionables")]
    public int totalCollectibles = 5;
    private int currentCollectibles = 0;
    public TMP_Text collectibleText;

    [Header("UI Final")]
    public GameObject winText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentCollectibles = 0;
        collectibleText.text = "0 / " + totalCollectibles;

        winText.SetActive(false);
    }

    public void AddCollectible()
    {
        currentCollectibles++;
        collectibleText.text = currentCollectibles + " / " + totalCollectibles;

        if (currentCollectibles >= totalCollectibles)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        winText.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoseGame()
    {
        Time.timeScale = 1f; // asegurarse de que el tiempo esté normal
        SceneManager.LoadScene("MainMenu");
    }
}