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
    private float correctNumber;
    public TextMeshProUGUI PrintInput;

    public string input;

    public bool bCorrect;

    /*Player Movmeent*/
    [SerializeField] private float speed = 10.0f;

    private enum Direction {FORWARD,BACKWARD,LEFT,RIGHT,NONE}

    private Direction currentDir = Direction.NONE;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        correctNumber = GameObject.FindGameObjectWithTag("CANVAS_UI").GetComponent<TelephoneUI>().contactline;
         
        bCorrect = false;
        PrintInput.text = input;

        this.InputListen();
        this.Move();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Dial")
        {
            compareNumbers(input, correctNumber);

            //clear the text 
            input = input.Remove(input.Length - input.Length);
        }
        //if the name is a number
        else if (other.gameObject.name != "Fruit Dime" || other.gameObject.name != "Fruit Dime(Clone)")
        {
            for (int i = 1; i <= 9; i++)
            {
                if (other.gameObject.name == i.ToString()) 
                {
                    //Debug.Log(i);
                    input  += i.ToString();
                }
                    
            }
        //iF its the fruit dime
        }
        
        if(other.gameObject.name == "Fruit Dime" || other.gameObject.name == "Fruit Dime(Clone)") 
        {
            EventBroadcaster.Instance.PostEvent(EventNames.Mushroom_Game_Jam.COLLECT_FRUIT_DIME);
        }
    }

    public bool compareNumbers(string input, float correctNumber)
    {

        Debug.Log("CORRECT NUMBER is "  + correctNumber);
        if (float.Parse(input) == correctNumber)
        {
            Debug.Log("Correct");

            //ADDS POINTS TO THE UI
            //EventBroadcaster.Instance.PostEvent(EventNames.Mushroom_Game_Jam.ADD_SCORE);

            bCorrect = true;
        } 
        else
        {
            Debug.Log("False");

            //DEDUCTS FIVE SECONDS FROM THE UI
            EventBroadcaster.Instance.PostEvent(EventNames.Mushroom_Game_Jam.PENALTY_EVENT);

            bCorrect = false;
            
        } 

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
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            input = input.Remove(input.Length - 1);
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
