using System;
using System.Collections;
using Alpha.UI;
using UnityEngine;

namespace Characters.Enemy
{
    public class VictoryCondition : MonoBehaviour
    {
        public EndGameMenuUI EndGame;


        private void OnDisable()
        {
            EndGame.FinishGame(true);
            StartCoroutine(PauseTheGame());
        }

        private IEnumerator PauseTheGame()
        {
            yield return new WaitForSeconds(5);
        }
    }
}