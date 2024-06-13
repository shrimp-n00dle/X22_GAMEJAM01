using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //SOURCES
    private TimerScript timer;
    private MushroomSpawn mushrooms;

    //VALUES
    private int currentShrooms;
    private TMP_Text currentTime;

    //DISPLAY TEXT
    public TMP_Text friendText;
    public TMP_Text timeText;

    void Start()
    {
        
    }

    void Update()
    {
   
    }

    public int setFriends()
    {
        return this.currentShrooms = mushrooms.getMushroomCount();
    }
    public TMP_Text setTime()
    {
        return this.currentTime = timer.getTimeText();
    }

}
