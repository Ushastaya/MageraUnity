using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _quitButton;

    private void Awake()
    {
        _quitButton.onClick.AddListener(() => { Application.Quit(); });
        _startButton.onClick.AddListener(() => { StartGame(); });
    }
    public void StartGame ()
    {
        SceneManager.LoadScene(1);
    }
}
