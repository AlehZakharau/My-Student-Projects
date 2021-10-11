using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : SingletonAsComponent<LevelController>
{
    public static LevelController Instance
    {
        get => ((LevelController)_Instance);
        set => _Instance = value;
    }

    [HideInInspector]public string time;

    public delegate void TryOpenDoor();
    public event TryOpenDoor OpenDoor;

    public delegate void TryFinish();
    public event TryFinish Finish;

    /// <summary>
    /// Открывает дверь
    /// </summary>
    public void Open()
    {
        OpenDoor?.Invoke();
    }

    /// <summary>
    /// Завершает уровень
    /// </summary>
    public void FinishLevel()
    {
        Debug.Log("Finish");
        Finish?.Invoke();
    }
}
