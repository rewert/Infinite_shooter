using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public int score;
    GameObject UI;
    Text start;

    void Start ()
    {	
        start = GameObject.FindGameObjectWithTag("Start").GetComponent<Text>();
        Scene scene = SceneManager.GetActiveScene();
        UI = GameObject.FindGameObjectWithTag("UI");
        Time.timeScale = 0;
        score = 0;
        UpdateScore ();
        StartCoroutine (SpawnWaves ());
    }

    void Update(){
        if (Input.GetKeyDown("return") && UI.activeInHierarchy == true){
            Time.timeScale = 1;
            UI.SetActive(false);
            start.text = "> Restart <";
        }

        if (GameObject.FindGameObjectWithTag("Player")==null){
            Time.timeScale = 0;
            start.text = "> Restart <";
            UI.SetActive(true);
            if (Input.GetKeyDown("return"))
                restart();            
        }
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0, hazards.Length)];
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), -100f, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);
        }
    }
    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore ();
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score;
    }

    void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        start.text = "> Restart <";
    }
}