using UnityEngine;

public class EnemySpawn : Bolt.EntityBehaviour
{

    [SerializeField]
    int spawnnumber;

    [SerializeField]
    float radius = 20;

    [SerializeField]
    float threatmodifier = 1;

    [SerializeField]
    float randomfactor = 0.1f;

    [SerializeField]
    GameObject enemyprefab;

    [SerializeField]
    int roomnum;

    [SerializeField]
    Collider[] colliders;

   

    public void Spawn() {

        for(int i = 0; i< spawnnumber; i++)
        {
            Vector3 spawnpos = SpawnPos();
            GameObject e =  BoltNetwork.Instantiate(BoltPrefabs.Enemy, spawnpos, Quaternion.identity);
            AiStates es = e.GetComponent<AiStates>();
            es.threatmodifier = Random.Range(threatmodifier - randomfactor, threatmodifier + randomfactor);
            es.spawnposition = spawnpos;
            Debug.Log("Enemy spawn :" + i);
        }

    }


    Vector3 SpawnPos() {
        Vector3 spawnpos = transform.position;
        bool canspawn = false;
        int safety = 100;
        while (!canspawn && safety > 0) {
            spawnpos.x = Random.Range(transform.position.x - radius, transform.position.x + radius);
            spawnpos.z = Random.Range(transform.position.z - radius, transform.position.z + radius);
            canspawn = Overlapped(spawnpos);
            safety--;
        }
        

        return spawnpos;

    }


    bool Overlapped (Vector3 spawnpos) {
        colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders) {
            Vector3 centerpoint = collider.bounds.center;
            float width = collider.bounds.extents.x;
            float length = collider.bounds.extents.z;

            float leftextent = centerpoint.x - width;
            float rightextent = centerpoint.x + width;
            float lowerextent = centerpoint.z - length;
            float upperextent = centerpoint.z + length;

            if (spawnpos.x >= leftextent && spawnpos.x <= rightextent) {
                if (spawnpos.y >= lowerextent && spawnpos.x <= upperextent) {
                    return false;
                }
            }
        }
        return true;

    }
}
