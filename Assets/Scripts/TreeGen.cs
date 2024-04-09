using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGen : MonoBehaviour
{
    public GameObject trunkBlock;
    public GameObject leavesBlock;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 growPoint = new Vector3Int(8, 1, 8);
        Instantiate(trunkBlock, growPoint, trunkBlock.transform.rotation);
        growPoint += new Vector3Int(0, 1, 0);
        for (int i = 0; i < 5; i++)
        {
            GameObject block = Instantiate(trunkBlock, growPoint, trunkBlock.transform.rotation);

            Branch(Random.Range(1, 5), growPoint);

            growPoint += new Vector3Int(0, 1, 0);

        }

    }
    void Branch(int rand, Vector3 growPoint)
    {
        if (rand == 1)
        {
            growPoint += new Vector3Int(1, 0, 0);
            GameObject block = Instantiate(trunkBlock, growPoint, trunkBlock.transform.rotation);
            growPoint += new Vector3Int(-2, 0, 0);
            Instantiate(trunkBlock, growPoint, trunkBlock.transform.rotation);
            growPoint += new Vector3Int(1, 0, 0);
        }
        else if (rand == 2)
        {
            growPoint += new Vector3Int(0, 0, 1);
            GameObject block = Instantiate(trunkBlock, growPoint, trunkBlock.transform.rotation);
            growPoint += new Vector3Int(0, 0, -2);
            Instantiate(trunkBlock, growPoint, trunkBlock.transform.rotation);
            growPoint += new Vector3Int(0, 0, 1);
        }

    }
}
