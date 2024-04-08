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
        Vector3 growPoint = new Vector3Int(0, 1, 0);
        for (int i=0; i<5; i++) { 
        GameObject block = Instantiate(trunkBlock, growPoint, trunkBlock.transform.rotation);
        growPoint += new Vector3Int(0, 1, 0);
            Debug.Log(block);
            Debug.Log(block.transform.position);
        }
        
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
