using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeManager : MonoBehaviour
{
    [SerializeField] private GameObjectPool sporePool;

    private float ticks = 0.0f;
    private float spawnInterval = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        this.sporePool.Initialize();
        EventBroadcaster.Instance.AddObserver(EventNames.Mushroom_Game_Jam.ON_SPAWNER_CLICKED, this.OnRequestPoolable);

    }

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Mushroom_Game_Jam.ON_SPAWNER_CLICKED);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.ticks < spawnInterval)
        {
            this.ticks += Time.deltaTime;
        }
        else if (this.sporePool.HasObjectAvailable(1))
        {
            //spawn
            this.ticks = 0.0f;
            this.sporePool.RequestPoolable();

            //randomize next spawn interval
            this.spawnInterval = Random.Range(0.15f, 0.5f);
        }
        
    }

    private void OnRequestPoolable()
    {
        for (int i = 0; i < 15; i++)
        {
            if (this.sporePool.HasObjectAvailable(1))
                this.sporePool.RequestPoolable();
        }
    }
}
