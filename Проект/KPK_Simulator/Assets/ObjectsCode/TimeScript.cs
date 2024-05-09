using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Для настройки часов
using System;
using System.IO;
using Debug = UnityEngine.Debug;


public class TimeScript : MonoBehaviour
{
    // Текстовое поле часов
    [SerializeField] TextMeshProUGUI timerText;

    // Часы со скольки началось
    private int hours = Convert.ToInt32(DateTime.Now.ToString("HH"));
    // Минуты со скольки началось
    private int minutes = Convert.ToInt32(DateTime.Now.ToString("mm"));
    // Секунды со скольки началось
    private int seconds = Convert.ToInt32(DateTime.Now.ToString("ss"));
    private string partOfTheDay;
    private float elapsedTomeInt = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        // При начале работы программы - Установка системного времени
        timerText.text = DateTime.Now.ToString("HH:mm:ss");
    }

    // Update is called once per frame
    void Update()
    {
        // Отсчет времени с начала работы игры
        elapsedTomeInt += 2.9f;
        // Рассчет сек мин час
        int visualSec = Mathf.FloorToInt((elapsedTomeInt + seconds) % 60);        
        int visualMin = Mathf.FloorToInt((elapsedTomeInt + seconds) / 60 + minutes);
        int visualHour = Mathf.FloorToInt((visualMin) / 60 + hours) % 24;

        timerText.text = $"{SetPartOfTheDay(visualHour)}\n" +
            $"{visualHour:00}:" +
            $"{visualMin % 60:00}\n" +
            $"{visualSec:00}";
    }

    // Установка части суток
    private string SetPartOfTheDay(int hour)
    {
        
        if (hour < 12)
        {
            new WorkWithJSON().WriteDown_partOfTheDay("Утро");
            return "Утро";
        }
        if (hour < 15)
        {
            new WorkWithJSON().WriteDown_partOfTheDay("День");
            return "День";
        }
        if (hour < 21)
        {
            new WorkWithJSON().WriteDown_partOfTheDay("Вечер");
            return "Вечер";
        }
        new WorkWithJSON().WriteDown_partOfTheDay("Ночь");
        return "Ночь";

    }

}
