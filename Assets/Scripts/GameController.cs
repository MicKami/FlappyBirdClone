using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public UnityEvent OnGameStart;

    private bool gameStarted = false;

    private void Update()
    {       
        if(Input.GetButtonDown("Jump") && !gameStarted)
        {
            OnGameStart?.Invoke();
            gameStarted = true;
        }
    }
    
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }    
}