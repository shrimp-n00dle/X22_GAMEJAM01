using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDimePoolable : APoolable
{
    private float yOld = 0;
    private float yNew = 0;

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
            Destroy(this.gameObject, 5);
        }
    }

    public override void Initialize() //initializes the property of this object.
    {

    }
    public override void Release() //releases this object back to the pool and clean up any data.
    {
        
    }

    //events for APoolable Object
    public override void OnActivate() //throws this event when this object has been activated from the pool.
    {
        this.transform.localPosition = new Vector3(-5.63f, Random.Range(5, 15), -6.09f);
    }
}
