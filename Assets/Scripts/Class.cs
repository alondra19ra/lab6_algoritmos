using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

#region Enums
public enum TaskType
{
    Buscar,
    Recolectar,
    Derrotar,
    Hablar
}
#endregion

#region Interfaces
public interface ITask
{
    void ExecuteTask();
}
#endregion

#region Clases Base y Derivadas

public abstract class Task : ITask
{
    #region Variables Protegidas
    protected string description;
    protected int priority;
    protected TaskType taskType;
    #endregion

    #region Propiedades Encapsuladas
    public int Priority => priority;
    public string Description => description;
    public TaskType Type => taskType;
    #endregion

    #region Constructor
    public Task(string description, int priority, TaskType taskType)
    {
        this.description = description;
        this.priority = priority;
        this.taskType = taskType;
    }
    #endregion

    #region Método Virtual Ejecutar
    public virtual void ExecuteTask()
    {
        Debug.Log("Realizando tarea: " + description);
    }
    #endregion
}

// Clases Derivadas
public class BuscarTask : Task
{
    public BuscarTask(string description, int priority) : base(description, priority, TaskType.Buscar) { }

    public override void ExecuteTask()
    {
        Debug.Log("Buscando: " + description);
    }
}

public class RecolectarTask : Task
{
    public RecolectarTask(string description, int priority) : base(description, priority, TaskType.Recolectar) { }

    public override void ExecuteTask()
    {
        Debug.Log(" Recolectando: " + description);
    }
}

public class DerrotarTask : Task
{
    public DerrotarTask(string description, int priority) : base(description, priority, TaskType.Derrotar) { }

    public override void ExecuteTask()
    {
        Debug.Log(" Derrotando: " + description);
    }
}

public class HablarTask : Task
{
    public HablarTask(string description, int priority) : base(description, priority, TaskType.Hablar) { }

    public override void ExecuteTask()
    {
        Debug.Log(" Hablando: " + description);
    }
}
#endregion

