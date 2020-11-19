using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float asteroidRotateSpeed = 3.0f;
    [SerializeField]
    private GameObject _explosion;
    /// <summary>
    /// // so is the - makeing this weird 
    /// </summary>
    private Spawn_Manager _spawnManager;


    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent <Spawn_Manager>();  
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0 ,1) * asteroidRotateSpeed * Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject, 0.3f);
            _spawnManager.StartSpawning();
        }

       
    }

}



