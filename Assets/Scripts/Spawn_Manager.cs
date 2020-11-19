using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyprefab;
    [SerializeField]
    private GameObject[] PowerUps;
    [SerializeField]
    private GameObject _tripleshotPowerUp;
    [SerializeField]
    private GameObject _SheildsPowerUp;
    [SerializeField]
    private GameObject _SpeedPowerUp;
    [SerializeField]
    private GameObject _EnemiesGoHere;
    [SerializeField]
    private bool _stopSpawning = false;


    // Start is called before the first frame update
    void Start()
    {

       //change me out for waves
       
       // Debug.Log(transform.name + "IS A SPAWN MANAGER");


    }

    public void StartSpawning()
    {
    StartCoroutine(SpawnEnemyRoutine());
    StartCoroutine(SpawnPowerupRoutine());

    }


    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.5f);

        while (_stopSpawning == false)
        {
            Vector3 postToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7f, 0);
            //yield return new WaitForSeconds(3.0f);
            GameObject newEnemy = Instantiate(_enemyprefab, postToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _EnemiesGoHere.transform;
            yield return new WaitForSeconds(8.0f);
        }
   
    }
    IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(3.0f);

        while (_stopSpawning == false)
        {
       
            Vector3 postoSpawnPwR = new Vector3(Random.Range(-8.0f, 8.0f), 7.5f, 0);
            GameObject spawnPowerUp = Instantiate(PowerUps[Random.Range(0 , 3)], postoSpawnPwR, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3.0f, 8.0f));
        }


    }
    public void OnPlayerdeath()
    {
        Debug.Log("On PLayer Death ");
        _stopSpawning = true;
    }

    
}


