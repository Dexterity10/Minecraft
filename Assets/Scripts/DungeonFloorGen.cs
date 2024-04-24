using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonFloorGen : MonoBehaviour
{
    public Vector3Int startPos;
    private Vector3Int DunGenPos;
    GameObject chosenRoom;
    GameObject chosenFloor;
    public GameObject[] floor;
    public GameObject[] room;

    // Start is called before the first frame update
    void Start()
    {

        for (int b = 0; b < 8; b++)
        {

            for (int i = 0; i < 8; i++)
            {
                int chooseRoom = Random.Range(0, room.Length);
                chosenRoom = room[chooseRoom];

                DunGenPos = startPos + new Vector3Int(b * 8, 0, 8 * i);


                int chooseItem = Random.Range(0, floor.Length);
                chosenFloor = floor[chooseItem];
                transform.Rotate(0, 0, Random.Range(0, 4) * 90);

                makeRoom(chosenRoom);

                makeFloor(chosenFloor);
            }

        }
    }

    void makeRoom(GameObject roomtype)
    {

        Instantiate(chosenRoom, DunGenPos, chosenRoom.transform.rotation);

    }
    void makeFloor(GameObject floortype)
    {

        Instantiate(chosenFloor, DunGenPos, chosenFloor.transform.rotation);

    }
}
