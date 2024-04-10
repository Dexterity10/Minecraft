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
        Vector3Int TreePos = new Vector3Int(8, 0, 8);
        GrowTree(TreePos);

        int x, y, z;

        for (int i = 0; i < 5; i++)
        {
            x = Random.Range(-32, 33);
            y = 0;
            z = Random.Range(-32, 33);
            GrowTree(new Vector3Int(x, y, z));

        }
    }

    void GrowTree(Vector3 pos)
    {
        Vector3 growPoint = pos;
        Instantiate(trunkBlock, growPoint, trunkBlock.transform.rotation);
        growPoint += new Vector3Int(0, 1, 0);

        int height = Random.Range(5, 13);
        Vector3Int[] branchDirections = {
            Vector3Int.forward,
            Vector3Int.right,
            Vector3Int.back,
            Vector3Int.left
        };
        for (int i = 0; i < height; i++)
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
            growPoint -= new Vector3Int(2, 0, 0);
            Instantiate(trunkBlock, growPoint, trunkBlock.transform.rotation);
            growPoint += new Vector3Int(1, 0, 0);
        }
        else if (rand == 2)
        {
            growPoint += new Vector3Int(0, 0, 1);
            GameObject block = Instantiate(trunkBlock, growPoint, trunkBlock.transform.rotation);
            growPoint -= new Vector3Int(0, 0, 2);
            Instantiate(trunkBlock, growPoint, trunkBlock.transform.rotation);
            growPoint += new Vector3Int(0, 0, 1);
        }

    }

}
