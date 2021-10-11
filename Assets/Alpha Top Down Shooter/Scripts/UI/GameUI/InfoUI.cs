using System;
using Alpha.Characters;
using Alpha.Data;
using TMPro;
using UnityEngine;

namespace Alpha.UI
{
    public class InfoUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI ammoText;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highScoreText;
        [SerializeField] private DataManager data;
        

        private string ammoInfo;
        private string scoreInfo;
        private string highScoreInfo;
        private int score;
        
        private void Start()
        {
            ammoInfo = ammoText.text;
            scoreInfo = scoreText.text;
            highScoreInfo = highScoreText.text;
            highScoreText.text = highScoreInfo + " " + data.Score.ToString();
            UpdateAmmoText(50);
        }

        public void UpdateAmmoText(int ammo)
        {
            ammoText.text = ammoInfo + " " + ammo.ToString();
        }

        public void UpdateScoreText(int addScore)
        {
            score += addScore;
            scoreText.text = scoreInfo + " " + score.ToString();
            
            if (score > data.Score)
            {
                data.Score += addScore;
                highScoreText.text = highScoreInfo + " " + data.Score.ToString();
            }
        }
        
        
    }
}