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

        for (int y = startPos.y; y < startPos.y + capPos.y; y++)
        {

            for (int x = startPos.x; x < startPos.x + capPos.x; x++)
            {

                for (int z = startPos.z; z < startPos.z + capPos.z; z++)
                {
                    int chooseItem = Random.Range(0, room.Length);


                    DunGenPos = startPos + new Vector3Int(z * 8, y * 8, x * 8);

                    int chooseItem2 = Random.Range(0, floor.Length);



                    chunk(DunGenPos.x, DunGenPos.y, DunGenPos.z, "air", 1, 1, 1);
                    valueRoom(DunGenPos.x, DunGenPos.y, DunGenPos.z, "stone");
                    valueFloor(DunGenPos.x, DunGenPos.y, DunGenPos.z, "stone");

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

    void valueRoom(int x, int y, int z, string block)
    {

        for (int b = 0; b < 8; b++)
        {
            // "make four pillars at the corners"
            world[new Vector3Int(x, y + b, z)] = block;
            world[new Vector3Int(x + 7, y + b, z)] = block;
            world[new Vector3Int(x, y + b, z + 7)] = block;
            world[new Vector3Int(x + 7, y + b, z + 7)] = block;
        }
        for (int a = 0; a < 8; a++)
        {
            //"make an 8x8 ring"

            if (a == 0 || a == 8)
            {
                for (int c = 0; c < 8; c++)
                {
                    // "make a line"
                    world[new Vector3Int(x + a, y + 7, z + c)] = block;
                    world[new Vector3Int(x + 7, y + 7, z + 7 - c)] = block;

                }
            }
            else
            {
                for (int c = 0; c < 8; c += 7)
                {
                    world[new Vector3Int(x + a, y + 7, z + c)] = block;

                }
            }
        }
    }
    void valueFloor(int x, int y, int z, string block)
    {

        if (Random.Range(0, floor.Length) == floor.Length)
        {
            for (int b = 0; b < 8; b++)
            {
                for (int a = 0; a < 8; a++)
                {
                    for (int c = 0; c < 8; c++)
                    {
                        world[new Vector3Int(x + a, y + b, z + c)] = block;
                    }
                }
            }
        }
        else
        {
            chunk(DunGenPos.x, DunGenPos.y, DunGenPos.z, "stone", 1, 0, 1);
        }
    }
    void chunk(int x, int y, int z, string block, int useA, int useB, int useC)
    {
        //8x8 chunk.
        //useA = 0 will make a wall perpendicular to the player
        //useB = 0 will make a flat platform
        //useC = 0 will make a wall facing the player
        for (int c = 0; c < 8 * useA; c++)
        {
            for (int b = 0; b < 8 * useB; c++)

                for (int a = 0; a < 8 * useC; a++)
                {
                    world[new Vector3Int(x + a, y + b, z + c)] = block;
                }
        }
    }
}

