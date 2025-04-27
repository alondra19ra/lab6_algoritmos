using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;


#region Sistema de Gestión de Tareas
public class TaskeSystem : MonoBehaviour
{
    #region Referencias UI
    [Title("Referencias UI")]
    public TextMeshProUGUI taskText;
    public TextMeshProUGUI rewardText;
    #endregion

    #region Variables Internas
    private PriorityQueueCustom<Task> taskQueue = new PriorityQueueCustom<Task>();
    private int completedTasks = 0;

    // Nuevo: Sonidos por tipo de tarea
    public AudioClip buscarSound;
    public AudioClip recolectarSound;
    public AudioClip derrotarSound;
    public AudioClip hablarSound;
    private AudioSource audioSource;
    #endregion

    #region Unity Methods
    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtener el AudioSource
        completedTasks = PlayerPrefs.GetInt("CompletedTasks", 0); // Recuperar el progreso guardado
        UpdateRewardUI();
    }
    #endregion

    #region Botón Odin - Inicializar Tareas
    [Button("Inicializar Lista de Tareas")]
    public void InitTasks()
    {
        taskQueue = new PriorityQueueCustom<Task>();

        taskQueue.Enqueue(new BuscarTask("Busca el mapa perdido", 3), 3);
        taskQueue.Enqueue(new RecolectarTask("Recolecta 5 manzanas", 2), 2);
        taskQueue.Enqueue(new DerrotarTask("Derrota al jefe goblin", 5), 5);
        taskQueue.Enqueue(new HablarTask("Habla con el anciano del bosque", 1), 1);

        UpdateTaskUI();
    }
    #endregion

    #region Botón Odin - Completar Tarea Actual
    [Button("Completar Tarea Actual")]
    public void CompleteCurrentTask()
    {
        if (taskQueue.Count > 0)
        {
            Task currentTask = taskQueue.Dequeue();
            currentTask.ExecuteTask();
            PlaySoundForTask(currentTask.Type);

            completedTasks++;
            PlayerPrefs.SetInt("CompletedTasks", completedTasks); 
            PlayerPrefs.Save();

            UpdateTaskUI();
            UpdateRewardUI();
        }
        else
        {
            taskText.text = "¡Todas las tareas completadas!";
            GiveReward();
        }
    }
    #endregion

    #region Actualizar Texto de UI
    private void UpdateTaskUI()
    {
        if (taskQueue.TryPeek(out Task nextTask, out int priority))
        {
            taskText.text = "Próxima tarea: " + nextTask.Description + " (Prioridad: " + priority + ")";
        }
        else
        {
            taskText.text = "No hay tareas pendientes.";
        }
    }

    private void UpdateRewardUI()
    {
        rewardText.text = "Tareas completadas: " + completedTasks;
    }
    #endregion

    #region Sonidos por Tipo de Tarea
    private void PlaySoundForTask(TaskType type)
    {
        switch (type)
        {
            case TaskType.Buscar:
                audioSource.PlayOneShot(buscarSound);
                break;
            case TaskType.Recolectar:
                audioSource.PlayOneShot(recolectarSound);
                break;
            case TaskType.Derrotar:
                audioSource.PlayOneShot(derrotarSound);
                break;
            case TaskType.Hablar:
                audioSource.PlayOneShot(hablarSound);
                break;
        }
    }
    #endregion

    #region Recompensas
    private void GiveReward()
    {
        rewardText.text = "¡Ganaste una recompensa por completar todas las tareas!";

    }
    #endregion
}
#endregion

