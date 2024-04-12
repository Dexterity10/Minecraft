using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonFloorGen : MonoBehaviour
{
    public Vector3Int startPos = new Vector3Int(0, 0, 0);
    public GameObject floor;
    public GameObject wall;
    //public GameObject[] roomlist = {
    //    none,
    //    simple

    //};

    // Start is called before the first frame update
    void Start()
    {
        int chooseRoom = Random.Range(0, 2);
        int chooseBlock = Random.Range(0, 2);
        makeRoom();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void makeRoom()
    {
        
        Instantiate(floor, startPos, floor.transform.rotation);
    }
}
