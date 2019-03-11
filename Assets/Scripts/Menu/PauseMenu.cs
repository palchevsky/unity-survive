using UnityEngine;

namespace Survive
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool IsPaused = false;
        [SerializeField]
        private GameObject _pauseMenuUI;
        [SerializeField]
        private GameObject _optionsMenuUI;
        [SerializeField]
        private GameObject _menuUI;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            _pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
        }

        public void Pause()
        {
            _pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
        }

        public void Options()
        {
            _pauseMenuUI.SetActive(false);
            _menuUI.SetActive(false);
            _optionsMenuUI.SetActive(true);
        }

        public void Back()
        {
            _pauseMenuUI.SetActive(true);
            _menuUI.SetActive(true);
            _optionsMenuUI.SetActive(false);
        }
    }
}