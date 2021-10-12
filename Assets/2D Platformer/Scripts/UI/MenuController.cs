using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class MenuController : MonoBehaviour
    {
        public void LoadLevel()
        {
            SceneManager.LoadScene("Well");
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
