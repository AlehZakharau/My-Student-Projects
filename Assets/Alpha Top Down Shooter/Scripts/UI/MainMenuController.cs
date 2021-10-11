using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alpha.UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private Canvas settingPanel;
        [SerializeField] private Canvas mainMenuPanel;


        public void LoadLevel()
        {
            SceneManager.LoadScene(1);
        }
        
        public void OpenSettingMenu()
        {
            settingPanel.enabled = true;
            mainMenuPanel.enabled = false;
        }

        public void CloseSettingMenu()
        {
            settingPanel.enabled = false;
            mainMenuPanel.enabled = true;
        }

        
        public void Exit()
        {
            Application.Quit();
        }
    }
}