using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUiController : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Debug.Log($"Pause {isPaused}");
            pauseMenu.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;
        }
    }
}
