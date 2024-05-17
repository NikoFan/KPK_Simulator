using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Класс для определения объекта на который наведен указатель
public class OBJIdentifiScript : MonoBehaviour
{
    // Переменная для определения объекта внимания
    public GameObject interactionInformationUI;

    // Переменная для установки текста
    private Text interactionText;



    // Start is called before the first frame update
    void Start()
    {
        interactionText = interactionInformationUI.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Курсор всегда закреплен в центре (КОД ДВИЖЕНИЯ ПОЛЬЗОВАТЕЛЯ)
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Если курсор наведен на объект
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
            // Если у объекта наведения есть имя
            if (selectionTransform.GetComponent<InteractableObject>())
            {
                
                interactionText.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                interactionInformationUI.SetActive(true);
            }
            // Если у объекта наведения отсутствует имя
            else 
            {
                Debug.Log("00");
                interactionInformationUI.SetActive(false);
            }
        } 
        // Если курсор наведен на небо
        else
        {
            
            interactionInformationUI.SetActive(false);
        }

    }
}
