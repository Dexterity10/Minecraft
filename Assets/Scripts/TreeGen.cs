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
        //GrowTree(TreePos);

        int x, y, z;

        for (int i = 0; i < 10; i++)
        {
            x = Random.Range(0, 32);
            y = 0;
            z = Random.Range(0, 32);
            GrowTree(new Vector3Int(x, y, z));
        }
    }

    void GrowTree(Vector3Int pos)
    {
        Vector3Int growPoint = pos;
        Instantiate(trunkBlock, growPoint, trunkBlock.transform.rotation);
        growPoint += new Vector3Int(0, 1, 0);
        int height = Random.Range(5, 13);

        for (int i = 0; i < height; i++)
        {
            Instantiate(trunkBlock, growPoint, trunkBlock.transform.rotation);
            Branch(Random.Range(0, 4), growPoint);
            Branch(Random.Range(0, 4), growPoint);
            growPoint += new Vector3Int(0, 1, 0);
        }

    }
    void Branch(int rand, Vector3Int growPoint)
    {
        Vector3Int[] branchDirections =
         {
            Vector3Int.forward,
            Vector3Int.right,
            Vector3Int.back,
            Vector3Int.left
        };
        for (int i = 0; i < growPoint.y - 2; i++)
        {
            growPoint += branchDirections[rand];
            GameObject branch = Instantiate(trunkBlock, growPoint, trunkBlock.transform.rotation);
            branch.transform.Rotate(branchDirections[(rand + 1) % 4], 90);
        }
    }

}
