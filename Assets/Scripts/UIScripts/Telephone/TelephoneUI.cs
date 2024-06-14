using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TelephoneUI : MonoBehaviour
{
    //TELEPHONE MECHANICS
    private bool bCorrect;
    public TextMeshProUGUI PhoneNumber;
    public float contactline = 0;
    public List<float> numberList = new List<float>();

    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.Mushroom_Game_Jam.GENERATE_NUMBER,generatePhoneNumber);
        generatePhoneNumber();
    }


    void Update()
    {
        bCorrect = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>().bCorrect;
        PhoneNumber.text = contactline.ToString();

        //if the number is correctly inputted
        if (bCorrect) 
        {  
            GameObject.FindGameObjectWithTag("Cover").GetComponent<SpawnPhone>().Start();
            EventBroadcaster.Instance.PostEvent(EventNames.Mushroom_Game_Jam.ON_MUSHROOM_SPAWN);
            generatePhoneNumber();
        }
    }

    private void generatePhoneNumber()
    {
        float digit;
        contactline = 0;

        for (int i = 0; i < 7; i++)
        {
            digit = Random.Range(1,9);
            
            if (i == 0) contactline +=  digit;
            else contactline += digit * Mathf.Pow(10, i);

        }
        //add it to list
        numberList.Add(contactline);

        //print in UI
        PhoneNumber.text = contactline.ToString();
    }

     void OnDestroy()
     {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Mushroom_Game_Jam.GENERATE_NUMBER);
     }

}
