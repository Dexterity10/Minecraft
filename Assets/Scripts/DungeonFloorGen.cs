using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonFloorGen : MonoBehaviour
{
    public Vector3Int startPos;
    public Vector3Int capPos;
    private Vector3Int DunGenPos;
    GameObject chosenRoom;
    GameObject chosenFloor;
    public GameObject[] floor;
    public GameObject[] room;
    Dictionary<Vector3Int, string> world = new Dictionary<Vector3Int, string>();

    // Start is called before the first frame update
    void Start()
    {

        for (int y = startPos.y; y < startPos.y + 8; y++)
        {

            for (int x = startPos.x; x < startPos.x + 8; x++)
            {

                for (int z = startPos.z; z < startPos.z + 8; z++)
                {
                    int chooseItem = Random.Range(0, room.Length);
                    chosenRoom = room[chooseItem];

                    DunGenPos = startPos + new Vector3Int(z * 8, y * 8, x * 8);


                    int chooseItem2 = Random.Range(0, floor.Length);
                    chosenFloor = floor[chooseItem2];
                    transform.Rotate(0, 0, Random.Range(0, 4) * 90);

                    valueRoom(DunGenPos.x, DunGenPos.y, DunGenPos.z, "stone");
                    valueFloor(DunGenPos.x, DunGenPos.y, DunGenPos.z, "stone");
                    foreach (var thing in world)
                    {
                        Debug.Log(thing);
                    }
                }

            }
        }
    }

    void valueRoom(int x, int y, int z, string block)
    {

        for (int b = 0; b < y + 7; b++)
        {
            // "make four pillars at the corners"
            world[new Vector3Int(x, y + b, z)] = block;
            world[new Vector3Int(x + 7, y + b, z)] = block;
            world[new Vector3Int(x, y + b, z + 7)] = block;
            world[new Vector3Int(x + 7, y + b, z + 7)] = block;
        }
        for (int a = 0; a < x + 7; a++)
        {
            // "make an 8x8 ring"

            if (a % 7 == 0)
            {
                for (int c = 0; c < z + 7; c++)
                {
                    // "make a line"
                    world[new Vector3Int(x + a, y + 8, z + c)] = block;

                }
            }
            else
            {
                for (int c = 0; c < z + 7; c += 7)
                {

                    world[new Vector3Int(x + a, y + 8, z + c)] = block;

                }
            }
        }
    }
    void valueFloor(int x, int y, int z, string block)
    {
        //basic 8x8 floor
        for (int c = 0; c < y + 7; c++)
        {
            for (int a = 0; a < x + 7; a++)
            {
                world[new Vector3Int(x + a, y, z + c)] = block;
            }
        }
    }
    void makeFloor(GameObject floortype)
    {
        //
        Instantiate(chosenFloor, DunGenPos, chosenFloor.transform.rotation);

    }
}

