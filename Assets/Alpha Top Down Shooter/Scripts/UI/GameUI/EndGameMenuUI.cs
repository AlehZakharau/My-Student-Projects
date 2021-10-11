using System;
using Alpha.Data;
using TMPro;
using UnityEngine;

namespace Alpha.UI
{
    public class EndGameMenuUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI endText;
        [SerializeField] private TextMeshProUGUI highScoreText;

        [SerializeField] private PauseMenuUI pauseMenuUi;
        [SerializeField] private DataManager data;

        

        public void FinishGame(bool isWin)
        {
            endText.text = isWin ? "Victory" : "You Lose";
            pauseMenuUi.OpenEndGamePanel();
            highScoreText.text = "HighScore: " + data.Score.ToString();
        }
    }
}