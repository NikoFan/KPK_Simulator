using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

// Класс движения пользователя
public class PlayerGoEvent : MonoBehaviour
{
    public CharacterController controller;

    // Базовая скорость пользователя
    public float playerSpeed = 12f;
    // Гравитация для Игрока
    public float peaceGravity = -9.8f * 2;
    // Высота прыжка
    public float playerJumpHeight = 30f;

    // Проверка наличия материи под ногами
    public Transform groundCheck;

    // Расстояние от Ног игрока до Земли
    public float groundDistance = 1.36f;

    public LayerMask groundMask;
    public LayerMask doorActionMask;

    // Быстрота (скорее всего падения)
    private Vector3 velocity;

    // Проверка что Игрок на земле
    private bool isGrounded;
    private bool isDoorNear;


    /*
    02.05 12-54
    Ошибка 1:
    В момент, когда камера направлена на ноги - не прыгает;
    Фикс Ошибки 1:
    Вариант 1 - Уменьшил допустимые градусы  при движении камерой-
        Это позволило избежать наклона камеры в пол.
        --ЭТО КОСТЫЛЬ--
        Необходимо исправить
    */
    // Update is called once per frame
    void Update()
    {
        
        // Проверка : если есть столкновение с поверхностью - пересчитать скорость падения, в ином случае скорость падения будет возрастать
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isDoorNear = Physics.CheckSphere(groundCheck.position, groundDistance, doorActionMask);
        // Если косание есть и Y меньше 0
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // В Х помещается показатели горизонка
        float x = Input.GetAxis("Horizontal");
        // В Z показатели вертикали
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * playerSpeed * Time.deltaTime);

        // Проверка что Игрок стоит на земле
        // Если это так - Он может прыгнуть снова
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            
            // Если Игрок нажал "Прыжок" - идет рассчет его траектории
            velocity.y = Mathf.Sqrt(playerJumpHeight * -2f * peaceGravity);
        }
        

        // Если Игрок зашел в область действия
        if (isDoorNear && velocity.y < 0)
        {
            Debug.Log("Open");
            
            
        }

        // Изменяем показатели Вертикали
        velocity.y += peaceGravity * Time.deltaTime;
        // Передвижение Игрока
        controller.Move(velocity * Time.deltaTime);

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Stove")
        {
            Debug.Log("Open Door");
        }
    }
}
