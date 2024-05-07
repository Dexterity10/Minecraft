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
        //makeWall(x, y, z, "x");
        //makeWall(x, y, z, "z");

        //make doorways
        //make ceiling

    }
    void makeFloor(int x, int y, int z, string block) //also makes ceiling; alternatively, creates stairs
    {
        //make floor
        for (int a = 0; a < 8; a++)
        {

            for (int c = 0; c < 8; c++)
            {
                world[new Vector3Int(x + a, y, z + c)] = block;

                // if the coord is touching the corner of the room, make a wall
                if ((x + a) % 8 == 0 || (z + c) % 8 == 0)
                {
                    for (int b = 0; b < 8; b++)
                    {
                        world[new Vector3Int(x + a, y + 1, z + c)] = block;
                    }
                }
            }

        }
        for (int b = 0; b < 8; b++)
        {
            world[new Vector3Int(x, y + b, z)] = block;
        }
        if (Random.Range(0, floor.Length + 1) == floor.Length)
        {
            int stairDir = Random.Range(0, 2); //pick 0 or 1
            int stairAbs = Random.Range(1, 3); //pick 1 or 2
            //make stairs
            for (int ab = 0; ab < 8; ab++) //can I put an if statement inside a for loop?
            {

                for (int c = 0; c < 8; c++)
                {
                    //if (stairDir == 0) //pick a random stair direction
                    //{
                        world[new Vector3Int(x + ab * ((-1) ^ stairAbs), y + ab, z)] = block;
                    //}
                    //else
                    //{
                    //    world[new Vector3Int(x, y + ab, z + ab * ((-1) ^ stairAbs))] = block;
                    //}
                }

            }
            //make space for stairs to connect to next floor
            for (int a = 0; a < 8; a++)
            {

                for (int c = 0; c < 8; c++)
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
    void makeWall(int x, int y, int z, string dir)
    {
        if (dir == "x")
        {
            for (int b = 0; b < 8; b++)
            {
                for (int a = 0; a < 8; a++)
                {
                    world[new Vector3Int(x + a, y + b, z)] = "stone";
                }
            }
        }

        else //if dir == "z"
        {
            for (int b = 0; b < 8; b++)
            {
                for (int c = 0; c < 8; c++)
                {
                    world[new Vector3Int(x, y + b, z + c)] = "stone";
                }
            }
        }
    }
}

