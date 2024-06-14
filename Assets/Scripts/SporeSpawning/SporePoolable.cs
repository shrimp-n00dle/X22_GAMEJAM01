using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporePoolable : APoolable
{
    [SerializeField] private Rigidbody sporeRB;

    private const float Y_BOUNDARY = 0.5f;
    private Vector3 originPos;

    // Start is called before the first frame update
    void Awake()
    {
        this.originPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.localPosition.y <= Y_BOUNDARY)
        {
            this.poolRef.ReleasePoolable(this);
        }        
    }

    public override void Initialize()
    {

    }

    public override void OnActivate()
    {
        //no update, just let it fall towards the level floor
        this.transform.localPosition = this.transform.position;
        this.transform.localPosition += Vector3.right * Random.Range(-12.5f, 12.5f);
        this.transform.localPosition += Vector3.forward * Random.Range(-12.5f, 12.5f);
    }

    public override void Release()
    {
        this.sporeRB.velocity = Vector3.zero;
    }
}
