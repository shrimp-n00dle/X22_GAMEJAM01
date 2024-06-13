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
    private int friendCap = 100;

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
