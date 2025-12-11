using UnityEngine;
using UnityEngine.SceneManagement;

namespace Skogen.UI.Menus
{
    public class GameOverMenu : MonoBehaviour
    {
        public static GameOverMenu Instance { get; private set; }

        [Header("UI")]
        [SerializeField] private GameObject gameOverPanel;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(false);
            }
        }

        public void Show()
        {
            Time.timeScale = 0f;
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
        }

        public void TryAgain()
        {
            Time.timeScale = 1f;
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex);
        }

        public void QuitToMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }

        public void QuitGame()
        {
            Time.timeScale = 1f;
            Application.Quit();
        }
    }
}
