using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDimeManager : MonoBehaviour
{
    [SerializeField] private GameObjectPool fruitDimePool;
    [SerializeField] private float spawnMin = 10.0f;
    [SerializeField] private float spawnMax = 15.0f;

    private float ticks = 0.0f;
    private float spawnInterval = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.fruitDimePool.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.ticks < spawnInterval)
        {
            this.ticks += Time.deltaTime;
        }
        else if(this.fruitDimePool.HasObjectAvailable(1))
        {
            this.ticks = 0.0f;
            this.fruitDimePool.RequestPoolable();

            this.spawnInterval = Random.Range(this.spawnMin, this.spawnMax);
        }
    }
}
