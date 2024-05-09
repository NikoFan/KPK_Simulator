using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class Contact : MonoBehaviour
{
    // Проверка что пользователь контактирует с дверью
    void OnTriggerEnter(Collider palyer)
    {
        // Если Тег объекта - Door
        if (palyer.gameObject.tag == "Player")
        {
            // Действие
            Debug.Log("DoorOpen");
            SceneManager.LoadScene("SecondScene");
        }
    }
}
