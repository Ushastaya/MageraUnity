using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Button _menuButton;   

    private void Awake()
    {
        _menuButton.onClick.AddListener(() => { MenuGame(); });
        _restart.onClick.AddListener(() => { PlayGame(); });
    }

    private void Update()
    {
        Time.timeScale = 0;
    }

    public void MenuGame()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
        
        SceneManager.LoadScene(1);
    }
}
