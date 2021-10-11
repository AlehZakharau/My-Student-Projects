using System;
using Alpha.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Alpha
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private DataManager data;
        [SerializeField] private Canvas tutorialPanel;
        [SerializeField] private Toggle repeatTutorial;
        private void Start()
        {
            Cursor.visible = false;
            Time.timeScale = 1f;
            if(!data.TutorialLearned)
                OpenTutorialPanel();
        }

        private void OpenTutorialPanel()
        {
            tutorialPanel.enabled = true;
            Cursor.visible = true;
            Time.timeScale = 0.001f;
        }

        public void CloseTutorialPanel()
        {
            tutorialPanel.enabled = false;
            Time.timeScale = 1f;
            Cursor.visible = false;
            data.TutorialLearned = repeatTutorial.isOn;
        }
    }
}