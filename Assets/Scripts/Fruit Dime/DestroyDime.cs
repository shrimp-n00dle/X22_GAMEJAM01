using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDime : MonoBehaviour
{
    private void OnCollect()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Mushroom_Game_Jam.COLLECT_FRUIT_DIME);
    }

    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.Mushroom_Game_Jam.COLLECT_FRUIT_DIME, this.OnCollect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
