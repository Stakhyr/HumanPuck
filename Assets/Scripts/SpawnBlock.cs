using UnityEngine;

public class SpawnBlock : MonoBehaviour
{

    public static void spawnBlocks(int blocksCount,Transform blockPrefab) 
    {
        for(int i = 0; i < blocksCount; i++) 
        {
            float xPos = Random.Range(-3.5f,3.5f);
            float zPos = Random.Range(-1, 2);
                Transform d= Instantiate(blockPrefab, new Vector3(xPos, 4.5f, zPos), Quaternion.identity);
        }
    }
}
