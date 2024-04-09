using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGen : MonoBehaviour
{
    public GameObject topBlock;
    public GameObject underBlock;
    public GameObject pointBlock;
    public int chunks = 1; //a chunk is 16x16 blocks
    GameObject spawnBlock;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 boop = new Vector3Int(8 * chunks, 1, 8 * chunks);
        Instantiate(pointBlock, boop, pointBlock.transform.rotation);
        Vector3Int growPoint = new Vector3Int(0, 0, 0);
        spawnBlock = topBlock;

        for (int y = 0; y < 64; y++)
        {
            for (int z = 0; z < 16 * chunks; z++)
            {
                for (int x = 0; x < 16 * chunks; x++)
                {
                    GameObject block = Instantiate(spawnBlock, growPoint, topBlock.transform.rotation);
                    growPoint += new Vector3Int(1, 0, 0);
                    Debug.Log(block);
                    Debug.Log(block.transform.position);

                }
                growPoint += new Vector3Int(-16 * chunks, 0, 1);
            }
            growPoint += new Vector3Int(0, -1, -16 * chunks);
            spawnBlock = underBlock;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
