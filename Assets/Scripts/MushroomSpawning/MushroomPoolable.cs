using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPoolable : APoolable
{
    [SerializeField] private Rigidbody mushroomRB;
    
    private Vector3 originPos;

    void Awake()
    {
        this.originPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //don't need rigidbody script for this part
        //just need to spawn the shrooms
        //note that if I added force to this, it wouldn't fall on a random position
        //it'd just shoot right to (0,0,0)
    }

    public override void Initialize()
    {

    }

    public override void OnActivate()
    {
        //no update, just let it fall towards the level floor
        this.transform.localPosition = this.transform.position;
        this.transform.localPosition += Vector3.right * Random.Range(-5.5f, 5.5f);
        this.transform.localPosition += Vector3.forward * Random.Range(-5.5f, 5.5f);
    }

    public override void Release()
    {
        //this just makes it so that it doesn't move again I guess
        //oh so this thing is so it doesn't go out of bounds.
        //well oop fall physics is gonna make it go out of bounds anyway.
        this.mushroomRB.velocity = Vector3.zero;
    }
}
