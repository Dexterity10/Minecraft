using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGen : MonoBehaviour
{
    public GameObject topBlock;
    public GameObject underBlock;
    public GameObject pointBlock;
    public struct Chunk
    {
        public int length,
        depth,
        width;

        public Chunk(int length, int width, int depth)
        {
            this.length = length;
            this.depth = depth;
            this.width = width;
            // units in blocks (16x depth x16)
        }
    }
    
    public Chunk chunk = new Chunk(16, 16, 2);

    GameObject spawnBlock;


    // Start is called before the first frame update
    void Start()
    {
        makeChunk(new Vector3Int(8, 0, 8), new Chunk(16, 16, 2));

    }

    // Update is called once per frame
    void Update()
    {

    }
    void makeChunk(Vector3Int startPos, Chunk dims)
    {
        //body
    }

        }

