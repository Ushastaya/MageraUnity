using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MyGames
{
    public class EspMenu : MonoBehaviour
    {

        [SerializeField] private Button _playButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private GameObject _menuPause;
        private bool _open = false;


        private void Awake()
        {
            _menuButton.onClick.AddListener(() => { MenuGame(); });
            _playButton.onClick.AddListener(() => { PlayGame(); });
        }

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (_open == false)
                {

                    _menuPause.SetActive(true);
                    Time.timeScale = 0;
                    _open = true;
                }
                else
                {

                    _menuPause.SetActive(false);
                    Time.timeScale = 1;
                    _open = false;
                }

            }
        }

        public void MenuGame()
        {
            SceneManager.LoadScene(0);
        }

        public void PlayGame()
        {
            Time.timeScale = 1;
        }
    }
}