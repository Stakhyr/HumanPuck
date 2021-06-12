using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneManage : MonoBehaviour
{
    public int blocksCount;
    [SerializeField] private Transform blockPrefab;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    private GameObject[] gos;
    private int levelnumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        
        SpawnBlock.spawnBlocks(blocksCount, blockPrefab);
        textMeshProUGUI.SetText("Level: "+ levelnumber.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (BlockEmount()) 
        {
            levelnumber += 1;
            blocksCount += 1;
            SpawnBlock.spawnBlocks(blocksCount, blockPrefab);
            
            textMeshProUGUI.SetText("Level: " + levelnumber.ToString());

        }
    }
    //change name
    private void GameWin()
    {
        
    }

    //private void BoxCount() 
    //{

    //    gos = GameObject.FindGameObjectsWithTag("Box");
    //    Debug.Log(gos.Length);

    //}

    public bool BlockEmount()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Box");

        if (gos.Length == 0)
        {
            return true;
        }
        return false;
    }
}
