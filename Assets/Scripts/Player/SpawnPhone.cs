using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPhone : MonoBehaviour
{
    [SerializeField] public GameObject cover,cover2,cover3,cover4;

    public void Start()
    {
      //GameObject.FindGameObjectWithTag("C").SetActive(false);
        cover.SetActive(true);
        cover2.SetActive(true);
        cover3.SetActive(true);
        cover4.SetActive(true);

        openPhone();
    }

    public void openPhone()
    {
          int open = Random.Range(1,4);

          switch(open)
          {
            case 1:
            cover.SetActive(false);
            break;

            case 2:
            cover2.SetActive(false);
            break;

            case 3:
            cover3.SetActive(false);
            break;

            case 4:
            cover4.SetActive(false);
            break;
          }
    }
}