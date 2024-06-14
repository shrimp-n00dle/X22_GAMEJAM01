using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomManager : MonoBehaviour
{
    [SerializeField] private GameObjectPool shroomPool;

    //Change code to listen for correct inputs instead
    private int increment = 1;

    // Start is called before the first frame update
    void Start()
    {
        this.shroomPool.Initialize();
        EventBroadcaster.Instance.AddObserver(EventNames.Mushroom_Game_Jam.ON_SPAWNER_CLICKED, this.OnRequestPoolable);

    }

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Mushroom_Game_Jam.ON_SPAWNER_CLICKED);
    }

    // Update is called once per frame
    void Update()
    {
               
    }

    private void OnRequestPoolable()
    {
        //2 x (2 x increment)
        for (int i = 0; i < 2; i++)
        {
            //2 x increment
            for(int j = 0; j < increment; j++)
            {
                if(this.shroomPool.HasObjectAvailable(1))
                    this.shroomPool.RequestPoolable();
            }
            //assume that every call of OnRequestPoolable() takes place on successful input
            this.increment++;
        }
    }

}
