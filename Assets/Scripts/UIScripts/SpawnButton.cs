using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SpawnButton : MonoBehaviour
{
    [SerializeField] private TMP_Text friendText;

    private float friendCounter = 0;
    private float friendCap = 500;

    private int increment = 1;

    public void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.Mushroom_Game_Jam.ON_MUSHROOM_SPAWN, this.OnButtonClicked);
        this.friendText.text = "Friends: " + this.friendCounter;
    }

    public void Destroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Mushroom_Game_Jam.ON_MUSHROOM_SPAWN);

    }

    public void Update()
    {
        
    }

    public void OnButtonClicked()
    {
        /*
         * Hard-coded solution, based off of the logic that OnButtonClicked()
         * will ONLY be triggered on correct inputs
        */

        if (this.friendCounter < friendCap)
        {
            float f = Mathf.FloorToInt(Mathf.Pow(2, increment));

            EventBroadcaster.Instance.PostEvent(EventNames.Mushroom_Game_Jam.ON_SPAWNER_CLICKED);
            this.friendCounter += f;

            this.friendText.text = "Friends: " + this.friendCounter;

            this.increment++;
        }
        else if (this.friendCounter >= friendCap)
        {
            this.friendCounter = this.friendCap;
            this.friendText.text = "Friends: " + this.friendCounter;

            this.friendCounter = 0;
            this.increment = 1;

            SceneManager.LoadScene(2);
        }
    }
}
