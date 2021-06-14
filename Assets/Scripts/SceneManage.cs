using TMPro;
using UnityEngine;

public class SceneManage : MonoBehaviour
{
    private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    public int blocksCount;
    [SerializeField] private Transform blockPrefab;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    private GameObject[] gos;
    private int levelnumber = 1;
    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ShowScore();

        SpawnBlock.spawnBlocks(blocksCount, blockPrefab);
        textMeshProUGUI.SetText("Level: "+ levelnumber.ToString());

        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();

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

            enemy.Speed += 0.5f;

        }
    }

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

    // Update is called once per frame
    public void IncreaseScore(int points)
    {
        score += points;
        ShowScore();
    }

    public void ReduceScore(int points)
    {
        score -= points;
        if (score < 0) score = 0;
        ShowScore();
    }

    private void ShowScore()
    {
        scoreText.SetText("Score: " + score.ToString());

    }
}
