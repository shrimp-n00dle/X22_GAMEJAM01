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

    private int increment = 1;

    // Start is called before the first frame update
    void Start()
    {
        this.mushroom1.SetActive(false);
        this.mushroom2.SetActive(false);

        for(int i = 0; i < 15; i++) 
        {
           this.increment++;
           this.OnSpawnEvent();        
        }

        EventBroadcaster.Instance.AddObserver(EventNames.Mushroom_Game_Jam.ON_SPAWNER_CLICKED, this.OnSpawnEvent);

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
        //increment twice each iteration (?)
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < increment; j++) 
            {            
                GameObject obj1 = ObjectUtils.SpawnDefault(this.mushroom1, this.transform, this.mushroom1.transform.localPosition);
                this.shroomList1.Add(obj1);

                GameObject obj2 = ObjectUtils.SpawnDefault(this.mushroom2, this.transform, this.mushroom1.transform.localPosition);
                this.shroomList2.Add(obj2);
            }
        }
    }

    public int getMushroomCount()
    {
        //Set it to ScoreManager
        return this.shroomList1.Count + this.shroomList2.Count;
    }

}
