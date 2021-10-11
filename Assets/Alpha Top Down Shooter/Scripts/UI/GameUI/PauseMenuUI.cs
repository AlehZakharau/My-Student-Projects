using System;
using Pool;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using PlayerInput = Characters.Player.PlayerInput;

namespace Alpha.UI
{
    
    
    public class PauseMenuUI : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private AudioSource clickSound;

        [SerializeField] private Canvas panels;
        [SerializeField] private Canvas pausePanel;
        [SerializeField] private Canvas settingPanel;
        [SerializeField] private Canvas endGamePanel;
        [SerializeField] private BulletPoolSO[] bulletPools;
        [SerializeField] private EnemyPoolSO[] enemyPools;
        [SerializeField] private BonusPoolSO[] bonusPools;
        [SerializeField] private EffectPoolSO[] effectPools;


        private void Update()
        {
            var pause = playerInput.Input.UI.Pause.triggered;

            if(!pause) return;
            //Debug.Log($"Cursor status: {Cursor.visible}");
            OpenPauseMenu();
        }


        private void OpenPauseMenu()
        {
            panels.enabled = !panels.enabled;
            if (panels.enabled)
            {
                playerInput.Input.Player.Disable();
                Time.timeScale = 0.001f;
                clickSound.Play();
                Cursor.visible = true;
                Debug.Log($"If panel enable");
            }
            else
            {
                playerInput.Input.Player.Enable();
                Time.timeScale = 1f;
                Cursor.visible = false;
                clickSound.Play();
                Debug.Log($"If panel disable");
            }
        }


        public void Exit()
        {
            Application.Quit();
        }

        public void Repeat()
        {
            foreach (var pool in bulletPools)
            {
                pool.DestroyPool();
            }

            foreach (var pool in enemyPools)
            {
                pool.DestroyPool();
            }
            
            foreach (var pool in bonusPools)
            {
                pool.DestroyPool();
            }
            foreach (var pool in effectPools)
            {
                pool.DestroyPool();
            }
            
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }

        public void OpenSettingMenu()
        {
            settingPanel.enabled = true;
            pausePanel.enabled = false;
        }

        public void CloseSettingMenu()
        {
            settingPanel.enabled = false;
            pausePanel.enabled = true;
        }

        public void OpenEndGamePanel()
        {
            endGamePanel.enabled = true;
            OpenPauseMenu();
            playerInput.Input.Player.Disable();
        }
    }
}