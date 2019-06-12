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
        
    }

    public int RandomDrop(float[] droprate) {

        // normalize droprate
        float tdr = 0;
        foreach (float d in droprate)
        {
            tdr += d;
        }
        for (int i = 0; i < itemdroprate.Length; i++)
        {

            droprate[i] = droprate[i] / tdr;
        }


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
    public int RandomDrop()
    {

        float randomfactor = Random.value;
        int returnvalue = Random.Range(0, items.Length - 1);

        Debug.Log("random " + randomfactor);

        float currend = 0;
        for (int i = 0; i < itemdroprate.Length; i++)
        {
            currend += itemdroprate[i];
            if (currend >= randomfactor)
            {
                returnvalue = i;
                break;
            }
        }
        Debug.Log("return " + returnvalue);
        return returnvalue;

    }

    public void ItemSpawn(int itemid, Vector3 pos) {

        Instantiate(items[itemid], pos, Quaternion.identity);
    }



}
