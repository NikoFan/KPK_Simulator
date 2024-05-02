using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Contact : MonoBehaviour
{
    // Проверка что пользователь контактирует с дверью
    void contact(Collider palyer)
    {
        // Если Тег объекта - Door
        if (palyer.gameObject.tag == "Door")
        {
            // Действие
            Debug.Log("DoorOpen");
        }
    }
}
