using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {
    
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves; // make this longer later... 5f for demo purposes
    private float countdown = 2f;       // 2 seconds till first wave...
    public Text waveCount;

    private int wave = 1;
    private int maxWave = 5;            // change this every level depending on difficulty goals... figure out how to set this at runtime...
    

    void Start () {
        waveCount.text = "Get ready...";
    }

    void Update() {
        if (countdown <= 0f) {
            if (wave < maxWave + 1){
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
            }
        }
        countdown -= Time.deltaTime;    // last time since last frame
        
        
    }

    // eventually adjust this to determine how we want waves to work...
    IEnumerator SpawnWave () {
        // Debug.Log("Wave Incoming!");
        waveCount.text = "Wave " + wave.ToString();
        for (int i = 0; i < wave; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f); // wait like half a second for each enemy per wave
        }
        wave++;
        
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }


}
