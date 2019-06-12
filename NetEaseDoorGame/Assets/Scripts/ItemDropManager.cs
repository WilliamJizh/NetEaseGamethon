using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] items;
    [SerializeField]
    float[] itemdroprate;

    Dictionary<GameObject, float> itemposs;
    // Start is called before the first frame update
    void Start()
    {
        

        float totaldroprate =0;
        foreach (float droprate in itemdroprate) {
            totaldroprate += droprate;
        }
        for (int i = 0; i < itemdroprate.Length; i++) {

            itemdroprate[i] = itemdroprate[i] / totaldroprate;
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p")) {
            int i = RandomDrop(itemdroprate);
            Instantiate(items[i], Vector3.zero, Quaternion.identity);
        }
    }

    int RandomDrop(float[] droprate) {

        float randomfactor = Random.value;
        int returnvalue = Random.Range(0, items.Length-1);

        Debug.Log("random " + randomfactor);

        float currend = 0;
        for (int i = 0; i < droprate.Length; i++) {
            currend += droprate[i];
            if (currend >= randomfactor) {
                returnvalue = i;
                break;
            }
        }
        Debug.Log("return " +returnvalue);
        return returnvalue;

    }


}
