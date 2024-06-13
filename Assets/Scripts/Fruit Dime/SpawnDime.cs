using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnDime : MonoBehaviour
{
    [SerializeField] private GameObject template;
    [SerializeField] private List<GameObject> activeObjectList;
    [SerializeField] private TMP_InputField inputField;

    private string numBalls;

    // Start is called before the first frame update
    void Start()
    {
        this.template.SetActive(false);

        //EventBroadcaster.Instance.AddObserver(EventNames.TestEvents.ON_SPAWN_CLICKED, this.OnSpawnEvent);
    }

    void OnDestroy()
    {
        //EventBroadcaster.Instance.RemoveObserver(EventNames.TestEvents.ON_SPAWN_CLICKED);
    }

    // Update is called once per frame
    void Update()
    {
        this.numBalls = this.inputField.GetComponent<TMP_InputField>().text;
    }

    private void OnSpawnEvent()
    {
        for(int i = 0; i < int.Parse(this.numBalls); i++)
        {
            GameObject instance = GameObject.Instantiate(this.template, this.transform);
            instance.SetActive(true);
            this.activeObjectList.Add(instance);
        }
    }

    public List<GameObject> GetObjectList()
    {
        return activeObjectList;
    }
}
