using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDimePoolable : APoolable
{
    private float yOld = 0.0f;
    private float yNew = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.yOld = this.yNew;
        this.yNew = this.gameObject.transform.position.y;

        if (yOld == yNew)
        {
            StartCoroutine(this.Despawn());
        }
    }

    public override void Initialize() //initializes the property of this object.
    {
        this.yOld = 0.0f;
        this.yNew = 1.0f;
    }
    public override void Release() //releases this object back to the pool and clean up any data.
    {
        this.yOld = 0.0f;
        this.yNew = 1.0f;
    }

    IEnumerator Despawn()
    {
        //Wait for 10 seconds
        yield return new WaitForSeconds(25);
        this.poolRef.ReleasePoolable(this);
    }

    //events for APoolable Object
    public override void OnActivate() //throws this event when this object has been activated from the pool.
    {
        this.transform.position = this.transform.parent.transform.position; // spawner position
    }
}
