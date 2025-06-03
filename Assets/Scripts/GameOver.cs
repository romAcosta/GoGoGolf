using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverText;
    
    public void EndGame(float distance)
    {
       if(gameOverPanel.activeSelf) return; 
       gameOverPanel.SetActive(true);
       Time.timeScale = 0;
       gameOverText.text = distance.ToString("F2") + " m" ;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
