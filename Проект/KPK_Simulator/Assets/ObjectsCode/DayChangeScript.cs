using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;


public class DayChangeScript : MonoBehaviour
{
    
    // Адрес на солнце
    public Light Sun;
    // Интенсивность свечения солнца
    private float sunIntensity;
    


    // Start is called before the first frame update
    void Start()
    {
        // Установка интенсивности свечения солнца
        sunIntensity = Sun.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (new WorkWithJSON().Read_partOfTheDay().ToString() == "Утро")
        {
            // Солнце в восходит
            Sun.transform.localRotation = Quaternion.Euler(50f, 180, 0);
            Sun.intensity = sunIntensity * 0.2f;
        } else if (new WorkWithJSON().Read_partOfTheDay().ToString() == "День")
        {
            // Солнце в зените
            Sun.transform.localRotation = Quaternion.Euler(100f, 180, 0);
            Sun.intensity = sunIntensity * 0.5f;
        } else if (new WorkWithJSON().Read_partOfTheDay().ToString() == "Вечер")
        {
            // Солнце в заходит
            Sun.transform.localRotation = Quaternion.Euler(180f, 180, 0);
            Sun.intensity =  0.3f;
        } else if (new WorkWithJSON().Read_partOfTheDay().ToString() == "Ночь")
        {
            // Солнце в зашло
            Sun.transform.localRotation = Quaternion.Euler(270f, 180, 0);
            Sun.intensity = 0.0f;
        }

    }
}
