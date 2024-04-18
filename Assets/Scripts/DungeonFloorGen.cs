using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonFloorGen : MonoBehaviour
{
    public Vector3Int startPos = new Vector3Int(0, 0, 0);
    GameObject chosenRoom;
    public GameObject floor;
    public GameObject[] room;
    public GameObject[] hall;
    //public GameObject[] roomlist = {
    //    none,
    //    simple

    //};

    // Start is called before the first frame update
    void Start()
    {

        for (int b = 0; b < 8; b++)
        {

            for (int i = 0; i < 8; i++)
            {


                startPos = new Vector3Int(b * 8, 0, 8 * i);
                if ((i+b) % 2 == 0)
                {
                    
                    int chooseItem = Random.Range(0, room.Length);
                    Debug.Log(room.Length);
                    Debug.Log(chooseItem);
                    chosenRoom = room[chooseItem];

                }
                else
                {
                    int chooseItem = Random.Range(0, hall.Length);
                    chosenRoom = hall[chooseItem];
                }
                makeRoom(chosenRoom);

            }


        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void makeRoom(GameObject roomtype)
    {
        Instantiate(floor, startPos, floor.transform.rotation);
        Instantiate(chosenRoom, startPos, chosenRoom.transform.rotation);

    }
}
