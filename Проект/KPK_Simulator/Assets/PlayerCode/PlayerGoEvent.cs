using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

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
    public float groundDistance = 1.2f;
    public LayerMask groundMask;

    // Быстрота (скорее всего падения)
    private Vector3 velocity;

    // Проверка что Игрок на земле
    private bool isGrounded;


    // Update is called once per frame
    void Update()
    {
        
        // Проверка : если есть столкновение с поверхностью - пересчитать скорость падения, в ином случае скорость падения будет возрастать
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

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

        // Изменяем показатели Вертикали
        velocity.y += peaceGravity * Time.deltaTime;
        // Передвижение Игрока
        controller.Move(velocity * Time.deltaTime);

    }
}
