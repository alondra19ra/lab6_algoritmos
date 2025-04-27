using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

#region Priority Queue Custom
public class PriorityQueueCustom<T>
{
    private List<(T item, int priority)> queue = new List<(T item, int priority)>();

    #region Enqueue (Agregar a la cola)
    public void Enqueue(T item, int priority)
    {
        queue.Add((item, priority));
        queue.Sort((x, y) => y.priority.CompareTo(x.priority));
    }
    #endregion

    #region Dequeue (Eliminar de la cola)
    public T Dequeue()
    {
        if (queue.Count == 0)
            throw new InvalidOperationException("La cola está vacía");

        T item = queue[0].item;
        queue.RemoveAt(0);
        return item;
    }
    #endregion

    #region TryPeek (Ver el siguiente sin eliminar)
    public bool TryPeek(out T item, out int priority)
    {
        if (queue.Count == 0)
        {
            item = default;
            priority = default;
            return false;
        }

        item = queue[0].item;
        priority = queue[0].priority;
        return true;
    }
    #endregion

    #region Propiedad Count
    public int Count => queue.Count;
    #endregion

    #region GetAllElements (Debug)
    public List<(T item, int priority)> GetAllElements()
    {
        return new List<(T item, int priority)>(queue);
    }
    #endregion
}
#endregion

