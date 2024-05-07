using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonFloorGen : MonoBehaviour
{
    public Vector3Int startPos; // should be -64,-64,-32 when completely finished
    public Vector3Int capPos; // the max amount of *rooms* that should spawn, not blocks
    Vector3Int DunGenPos;
    public GameObject stone;
    //GameObject air;
    public GameObject[] floor;
    public GameObject[] room;
    Dictionary<Vector3Int, string> world = new Dictionary<Vector3Int, string>();

    // Start is called before the first frame update
    void Start()
    {

        for (int y = startPos.y; y > startPos.y - capPos.y; y--)
        {

            for (int x = startPos.x; x < startPos.x + capPos.x; x++)
            {

                for (int z = startPos.z; z < startPos.z + capPos.z; z++)
                {
                    int chooseItem = Random.Range(0, room.Length);


                    DunGenPos = startPos + new Vector3Int(z * 8, y * 8, x * 8);

                    int chooseItem2 = Random.Range(0, floor.Length);



                    fillAir(DunGenPos.x, DunGenPos.y, DunGenPos.z);
                    makeRoom(DunGenPos.x, DunGenPos.y, DunGenPos.z, "stone");
                    makeFloor(DunGenPos.x, DunGenPos.y, DunGenPos.z, "stone");
                }

            }
        }
        //spawn from dictionary
        foreach (var block in world)
        {
            if (block.Value == "stone")
            {
                Instantiate(stone, block.Key, Quaternion.identity);
            }
        }
    }

    void makeRoom(int x, int y, int z, string block)
    {
        makeWall(x, y, z, block);
        makeDoor(x, y, z);

    }
    void makeDoor(int x, int y, int z)
    {


        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            int doorDir = Random.Range(0, 2); // pick between 0 and 1
            int doorAbs = Random.Range(0, 2); // pick between 0 and 1

            if (doorDir == 0) // 0 is X, 1 is Z
            { //X
                if (doorAbs == 0) // 0 is positive, 1 is negative
                {
                    for (int a = 1; a < 8; a++)
                    {
                        if (a > 2 && a < 6)
                        {
                            world[new Vector3Int(x + a, y + 1, z)] = "air";
                            world[new Vector3Int(x + a, y + 2, z)] = "air";
                        }
                    }
                    world[new Vector3Int(x + 4, y + 3, z)] = "air";
                }
                else
                {
                    for (int a = 1; a < 8; a++)
                    {
                        if (a > 2 && a < 5)
                        {
                            world[new Vector3Int(x + a, y, z + 8)] = "air";
                            world[new Vector3Int(x + a, y + 1, z + 8)] = "air";
                        }
                    }
                    world[new Vector3Int(x + 4, y + 3, z + 8)] = "air";
                }
            }
            else
            { //Z
                if (doorAbs == 0) // 0 is positive, 1 is negative
                {
                    for (int c = 1; c < 8; c++)
                    {
                        if (c > 2 && c < 6)
                        {
                            world[new Vector3Int(x, y + 1, z + c)] = "air";
                            world[new Vector3Int(x, y + 2, z + c)] = "air";
                        }
                    }
                    world[new Vector3Int(x, y + 3, z + 4)] = "air";
                }
                else
                {
                    for (int c = 1; c < 8; c++)
                    {
                        if (c > 2 && c < 5)
                        {
                            world[new Vector3Int(x + 8, y, z + c)] = "air";
                            world[new Vector3Int(x + 8, y + 1, z + c)] = "air";
                        }
                    }
                    world[new Vector3Int(x + 8, y + 2, z + 4)] = "air";
                }
            }
        }
    }


    void makeWall(int x, int y, int z, string block)
    {
        for (int a = 0; a < 8; a++)
        {

            for (int c = 0; c < 8; c++)
            {
                {
                    for (int b = 0; b < 8; b++)
                    {
                        if ((x + a) % 8 == 0 || (z + c) % 8 == 0)
                        {
                            world[new Vector3Int(x + a, y + b, z + c)] = block;
                        }
                    }
                }
            }

        }
    }
    void makeFloor(int x, int y, int z, string block) //also makes ceiling; alternatively, creates stairs
    {
        //make floor
        for (int a = 0; a < 8; a++)
        {

            for (int c = 0; c < 8; c++)
            {
                world[new Vector3Int(x + a, y, z + c)] = block;

            }

        }
        for (int b = 0; b < 8; b++)
        {
            world[new Vector3Int(x, y + b, z)] = block;
        }
        if (Random.Range(0, floor.Length + 1) == floor.Length)
        {
            int stairDir = Random.Range(0, 2); //pick 0 or 1
            int stairAbs = Random.Range(0, 2); //pick 0 or 1
                                               //make stairs
            for (int ab = 0; ab < 8; ab++)
            {

                for (int c = 0; c < 8; c++)
                {
                    if (stairDir == 0) //pick a random stair direction
                    {
                        if (stairAbs == 0)
                        {
                            world[new Vector3Int(x + ab, y + ab, z + 1)] = block;
                        }
                        else world[new Vector3Int(x + 8 - ab, y + ab, z + 1)] = block;
                    }
                    else
                    {
                        if (stairAbs == 0)
                        {
                            world[new Vector3Int(x + 1, y + ab, z + ab)] = block;
                        }
                        else world[new Vector3Int(x + 1, y + ab, z + 8 - ab)] = block;

                    }
                }

            }
            //make space for stairs to connect to next floor
            for (int a = 1; a < 7; a++)
            {

                for (int c = 1; c < 7; c++)
                {
                    world[new Vector3Int(x + a, y + 8, z + c)] = "air";

                }

            }

        }
        else
        { //make ceiling
            for (int a = 0; a < 8; a++)
            {

                for (int c = 0; c < 8; c++)
                {
                    world[new Vector3Int(x + a, y + 8, z + c)] = block;

                }

            }
        }



    }
    void fillAir(int x, int y, int z)
    {
        //fill 8x8x8 area with air
        for (int c = 0; c < 8; c++)
        {
            for (int b = 0; b < 8; b++)
            {

                for (int a = 0; a < 8; a++)
                {
                    world[new Vector3Int(x + a, y + b, z + c)] = "air";
                }
            }
        }
    }
}