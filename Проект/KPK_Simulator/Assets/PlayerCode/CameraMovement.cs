using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

// Класс движения камерой
public class CameraMovement : MonoBehaviour
{
    // Чувствительность камеры
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public Transform cam;

    // Врещение по Х и У
    private float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        // Блокировка курсора мыши на центре экрана и скрытие его
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float XCameraMove = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        playerBody.Rotate(Vector3.up * XCameraMove);
        float YCameraMove = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= YCameraMove;
        // Ограничение вращения камеры (чтобы не было как у совы)
        xRotation = Mathf.Clamp(xRotation, -60f, 20f);
        cam.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
