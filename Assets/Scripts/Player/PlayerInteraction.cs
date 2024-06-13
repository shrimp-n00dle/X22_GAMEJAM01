using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class PlayerInteraction : MonoBehaviour
{
    /*Telephone*/
    private TelephoneUI correctNumber;
    public TextMeshProUGUI PrintInput;

    public string input;

    public float empty;

    private bool bCorrect = false;

    [SerializeField] private float speed = 10.0f;
    bool bPressed = false;

    private enum Direction {FORWARD,BACKWARD,LEFT,RIGHT,NONE}

    private Direction currentDir = Direction.NONE;

    // Start is called before the first frame update
    void Start()
    {   
        empty = 0.0f;
    
        //EventBroadcaster.Instance.AddObserver(EventNames.Mushroom_Game_Jam.PHONE_CALLING););

    }

    // Update is called once per frame
    void Update()
    {
        PrintInput.text = input.ToString();

        this.InputListen();
        this.Move();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Dial")
        {
            Debug.Log("Dial");
            compareNumbers(input,correctNumber);
        }
        //if the name is a number
        else if (other.gameObject.name != "FruitDime")
        {
            for (int i = 1; i <= 9; i++)
            {
                if (other.gameObject.name == i.ToString()) 
                {
                    Debug.Log(i);
                    input  += i.ToString();
                }
                    
            }
        //iF its the fruit dime
        } else 
        {
           EventBroadcaster.Instance.PostEvent(EventNames.Mushroom_Game_Jam.COLLECT_FRUIT_DIME);
        }
    }

    // void OnDestroy()
    // {
    //     EventBroadcaster.Instance.RemoveObserver(EventNames.Mushroom_Game_Jam.PHONE_CALLING);
    // }

    public bool compareNumbers(string input, TelephoneUI correctNumber)
    {
        //comparision
        if (input.CompareTo(correctNumber.PhoneNumber.ToString()) == 0)
        {
            Debug.Log("Correct");

            //ADDS POINTS TO THE UI 
            EventBroadcaster.Instance.PostEvent(EventNames.Mushroom_Game_Jam.ADD_SCORE);

            bCorrect = true;
        } 
        else
        {
            Debug.Log("False");

            //DEDUCTS FIVE SECONDS FROM THE UI
            EventBroadcaster.Instance.PostEvent(EventNames.Mushroom_Game_Jam.PENTALY_EVENT);

            bCorrect = false;
        } 

        //reset the string to empty
        input = null;
        PrintInput.text = " ";

        return bCorrect;
    }

    private void InputListen()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.currentDir = Direction.FORWARD;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            this.currentDir = Direction.BACKWARD;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.currentDir = Direction.LEFT;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.currentDir = Direction.RIGHT;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
             this.gameObject.transform.Translate(Vector3.up * Time.deltaTime * 250.0f);
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            this.currentDir = Direction.NONE;
        }
    }

    private void Move()
    {
        if (this.currentDir == Direction.FORWARD)
        {
            this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * this.speed);
        }
        else if (this.currentDir == Direction.BACKWARD)
        {
            this.gameObject.transform.Translate(Vector3.back * Time.deltaTime * this.speed);
        }
        else if (this.currentDir == Direction.RIGHT)
        {
            this.gameObject.transform.Translate(Vector3.right * Time.deltaTime * this.speed);
        }
        else if (this.currentDir == Direction.LEFT)
        {
            this.gameObject.transform.Translate(Vector3.left * Time.deltaTime * this.speed);
        }
    }
}
