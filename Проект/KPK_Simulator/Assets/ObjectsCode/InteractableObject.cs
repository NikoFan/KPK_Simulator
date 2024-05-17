using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс для возврата имени объекта
public class InteractableObject : MonoBehaviour
{
    public string ObjectName;

    public string GetItemName()
    {
        return ObjectName;
    }
}
