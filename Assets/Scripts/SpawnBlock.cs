using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    
    private float fieldLength = 40f;
    List<Transform> blocks;

    // Start is called before the first frame update


    public static void spawnBlocks(int blocksCount,Transform blockPrefab) 
    {
        for(int i = 0; i < blocksCount; i++) 
        {
            float xPos = Random.Range(-6,1);
            float zPos = Random.Range(-1, 2);

            //Transform newEnemy = 
                Transform d= Instantiate(blockPrefab, new Vector3(xPos, 4.5f, zPos), Quaternion.identity);
            //blocks.Add(newEnemy);
            //Debug.Log(blocks.Count);
        }
    }
    private void Update()
    {
       
        //if (d.Length == 0) 
        //{
            
        //}
        //Debug.Log()
    }


}
