using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    public BufferRoomManager BRM;
    // Start is called before the first frame update
    void Start()
    {
        BRM = GameObject.Find("BufferRoomManager").GetComponent<BufferRoomManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        BRM.enterBuffer(other.gameObject);
    }
}
