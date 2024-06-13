using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MushroomSpawn : MonoBehaviour
{
    //private TelephoneUI totalCorrect;

    [SerializeField] private GameObject mushroom1;
    [SerializeField] private List<GameObject> shroomList1;

    [SerializeField] private GameObject mushroom2;
    [SerializeField] private List<GameObject> shroomList2;

    //update when player inputs a thing correctly
    //more notes in OnSpawnEvent
    //change later to ObjectPooling
    private int increment = 1;
    private int friendCap = 100;

    // Start is called before the first frame update
    void Start()
    {
        this.mushroom1.SetActive(false);
        this.mushroom2.SetActive(false);

        /*
        //for loop for increment testing
        for(int i = 0; i < increment; i++) 
        {
           this.increment++;
           this.OnSpawnEvent();        
        }
        */

        EventBroadcaster.Instance.AddObserver(EventNames.Mushroom_Game_Jam.ON_SPAWNER_CLICKED, this.OnSpawnEvent);

        //Add Observer here for SceneChange, friendCapReached
        //EventBroadcaster.Instance.AddObserver(EventNames.Mushroom_Game_Jam.SCENE_CHANGE, this.friendCapReached)

        //Add Observer here for AddScore, getMushroomCount
        //EventBroadcaster.Instance.AddObserver(EventNames.Mushroom_Game_Jam.ON_SPAWNER_CLICKED, this.getMushroomCount)
    }

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Mushroom_Game_Jam.ON_SPAWNER_CLICKED);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSpawnEvent()
    {
        //oh my fucking goodness this is not exponential.
        //2 x (2 x increment)
        for (int i = 0; i < 2; i++)
        {
            //2 x increment
            for (int j = 0; j < increment; j++) 
            {            
                GameObject obj1 = ObjectUtils.SpawnDefault(this.mushroom1, this.transform, this.mushroom1.transform.localPosition);
                this.shroomList1.Add(obj1);

                GameObject obj2 = ObjectUtils.SpawnDefault(this.mushroom2, this.transform, this.mushroom1.transform.localPosition);
                this.shroomList2.Add(obj2);
            }
        }
        
        //assume that every call of OnSpawnEvent() takes place on successful input
        this.increment++;

    }

    public int getMushroomCount()
    {
        //Send to function in SpawnButton (?)
        return this.shroomList1.Count + this.shroomList2.Count;
    }

    public bool friendCapReached()
    {
        if(this.getMushroomCount() >= this.friendCap)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
