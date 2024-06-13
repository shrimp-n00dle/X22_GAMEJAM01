using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnButton : MonoBehaviour
{
    [SerializeField] private TMP_Text friendText;
    //private ScoreManager shrooms;

    private int friendCounter = 0;

    //change later to track combined size of both shroomLists in MushroomSpawn
    private int friendCap = 15;

    public void Start()
    {
        this.friendText.text = "Friends: " + this.friendCounter;
    }

    public void Update()
    {
        
    }

    public void OnButtonClicked()
    {
        if(this.friendCounter < friendCap)
        {
            EventBroadcaster.Instance.PostEvent(EventNames.Mushroom_Game_Jam.ON_SPAWNER_CLICKED);
            this.friendCounter += 2;
            this.friendText.text = "Friends: " + this.friendCounter;
        }        
    }
}
