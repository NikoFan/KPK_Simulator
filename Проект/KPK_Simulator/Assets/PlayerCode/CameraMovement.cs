using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс движения камерой
public class CameraMovement : MonoBehaviour
{
    // Чувствительность камеры
    public float mouseSensitivity = 100f;

    // Врещение по Х и У
    private float xRotation = 0f;
    private float yRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        // Блокировка курсора мыши на центре экрана и скрытие его
        Cursor.lockState = CursorLockMode.Locked;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // Считывание движения по Х и У осям * на чувствительность камеры и время движения
        // S = V * t
        // S = Расстояние смещения
        // V = Положение на Оси * Чувствительность
        // t = Время затраченное на действие (Ti,e.deltaTime)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Контроль вращения вокруг X оси (Вправо и влево)
        xRotation -= mouseY;

        // Ограничение вращения камеры (чтобы не было как у совы)
        xRotation = Mathf.Clamp(xRotation, -60f, 20f);

        // Контроль подъема головы (вверх и вниз)
        yRotation += mouseX;

        // Устанавка результатов вращения
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);


    }
}
