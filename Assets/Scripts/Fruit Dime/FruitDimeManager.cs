using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDimeManager : MonoBehaviour
{
    [SerializeField] private GameObjectPool pinballPool;

    private float ticks = 0.0f;
    private float spawnInterval = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.pinballPool.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.ticks < spawnInterval)
        {
            this.ticks += Time.deltaTime;
        }
        else if(this.pinballPool.HasObjectAvailable(1))
        {
            this.ticks = 0.0f;
            this.pinballPool.RequestPoolable();

            this.spawnInterval = Random.Range(5.0f, 10.0f);
        }
    }
}
