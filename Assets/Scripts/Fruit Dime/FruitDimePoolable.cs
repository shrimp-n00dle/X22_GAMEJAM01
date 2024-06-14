using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FruitDimePoolable : APoolable
{
    private float yOld = 0.0f;
    private float yNew = 1.0f;

    [SerializeField] public TMP_Text inputField;
    private string numDimes;

    private int newNumDime = 0;

    public void OnCollect()
    {
        this.numDimes = this.inputField.text;

        this.newNumDime = int.Parse(this.numDimes);

        newNumDime += 1;

        this.inputField.text = newNumDime.ToString();

        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        newNumDime = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>().fruitCounter;

        EventBroadcaster.Instance.AddObserver(EventNames.Mushroom_Game_Jam.GET_DIME_UI, this.updateUI);
        
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

    public void updateUI()
    {
        newNumDime -= 1;
        this.inputField.text = newNumDime.ToString();
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
        yield return new WaitForSeconds(5);
        this.poolRef.ReleasePoolable(this);
    }

    //events for APoolable Object
    public override void OnActivate() //throws this event when this object has been activated from the pool.
    {
        this.transform.position = this.transform.parent.transform.position; // spawner position
    }

    public GameObjectPool getPoolRef()
    {
        return this.poolRef;
    }

    public void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Mushroom_Game_Jam.GET_DIME_UI);
    }
}
