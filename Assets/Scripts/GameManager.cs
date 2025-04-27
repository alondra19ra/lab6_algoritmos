using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Game Manager
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Referencias")]
    public TaskeSystem taskSystem;

    private void Awake()
    {
        // Singleton (solo 1 GameManager en escena)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (taskSystem != null)
        {
            taskSystem.InitTasks(); // Iniciar las tareas automáticamente al empezar
        }
    }

    public void CompleteTask()
    {
        if (taskSystem != null)
        {
            taskSystem.CompleteCurrentTask();
        }
    }
}
#endregion

