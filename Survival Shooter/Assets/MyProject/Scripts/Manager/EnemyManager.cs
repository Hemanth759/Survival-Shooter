using UnityEngine;

public class EnemyManager : MonoBehaviour
{
  public PlayerHealth playerHealth;
  public GameObject ZombunnyPrefab;
  public GameObject ZomBearPrefab;
  public GameObject HelephantPrefab;
  public float spawnTimeOfBear = 3f;
  public float spawnTimeOfBunny = 4f;
  public float spawnTimeOfHelephant = 10f;
  public Transform[] spawnPoints;


  void Start () {
    InvokeRepeating("SpawnBear", spawnTimeOfBear, spawnTimeOfBear);
    InvokeRepeating("SpawnBunny", spawnTimeOfBunny, spawnTimeOfBunny);
    InvokeRepeating("SpawnHelephant", spawnTimeOfHelephant, spawnTimeOfHelephant);
  }


  void SpawnBear () {
    if(playerHealth.currentHealth <= 0f) {
      return;
    }

    int spawnPointIndex = Random.Range (0, spawnPoints.Length);

    Instantiate (ZomBearPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
  }

  void SpawnBunny () {
    if(playerHealth.currentHealth <= 0f) {
      return;
    }

    int spawnPointIndex = Random.Range (0, spawnPoints.Length);

    Instantiate (ZombunnyPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
  }

  void SpawnHelephant () {
    if(playerHealth.currentHealth <= 0f) {
      return;
    }

    int spawnPointIndex = Random.Range (0, spawnPoints.Length);

    Instantiate (HelephantPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
  }
}
