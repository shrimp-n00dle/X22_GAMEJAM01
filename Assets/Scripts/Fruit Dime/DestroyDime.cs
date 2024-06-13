using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDime : MonoBehaviour
{
    private float yOld = 0;
    private float yNew = 0;
    // Start is called before the first frame update
    void Start()
    {
        //EventBroadcaster.Instance.AddObserver();
    }

    // Update is called once per frame
    void Update()
    {
        this.yOld = this.yNew;
        this.yNew = this.gameObject.transform.position.y;
        if(yOld == yNew)
        {
            Destroy(this.gameObject, 5);
        }
    }
}
