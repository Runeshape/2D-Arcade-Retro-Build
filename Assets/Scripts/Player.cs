using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    [SerializeField]
    private GameObject _laserprefab;
    [SerializeField]
    private float _speedMultiplier = 3.5f;
    [SerializeField]
    private float _speedthrusters = 1.5f;
    [SerializeField]
    private float _speed = 3f;
    public float pLayerHorizontalMovement;
    public float playerVerticalMovement;
    [SerializeField]
    private float _firerate = 8.0f;
    private float _laserEnable;
    [SerializeField]
    private bool TripleShotActive;
    [SerializeField]
    private GameObject TrippleShotWeapons;
    [SerializeField]
    private GameObject TripleShotPwR;
    [SerializeField]
    private GameObject ShieldVisualizer;
    [SerializeField]
    private int _score;
    [SerializeField]
    private Spawn_Manager _spawnManager;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private bool OnPLayerDeath = false;
    [SerializeField]
    private bool ShieldsActive;
    [SerializeField]
    private bool SpeedActive;
    [SerializeField]
    private AudioClip _laserShooter;
    [SerializeField]
    private AudioSource _audioSource;
    private UImanager _UiManager;
    [SerializeField]
    private GameObject _RightEngine, _LeftEngine ;
    [SerializeField]
    private GameObject[] ShieldsCondition;


    // Start is called before the first frame update
    void Start()
    {
    
        _audioSource = GetComponent<AudioSource>();
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        _UiManager = GameObject.Find("Canvas").GetComponent<UImanager>();
        _LeftEngine.SetActive(false);
        _RightEngine.SetActive(false);
        ShieldVisualizer.SetActive(false);
        if (_spawnManager == null)
        {
            Debug.Log("SpawnManager not there.");
        }
        if (_UiManager == null)
        {
            Debug.Log("The UImanager is not there.");
        }
        if (_audioSource == null)
        {
            Debug.Log("the audioSource on the Player is null.");
        }
        else
        {
            _audioSource.clip = _laserShooter;
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        FireLaser();

    }

    // do I want this here shift 

    void CalculateMovement()
    {
        pLayerHorizontalMovement = Input.GetAxis("Horizontal");
        playerVerticalMovement = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(pLayerHorizontalMovement, playerVerticalMovement, 0);
       

        if (Input.GetKey(KeyCode.LeftShift))

        {
            transform.Translate(direction * (_speedthrusters * _speed) * Time.deltaTime);
           
        }
        else 
        {
            transform.Translate(direction * _speed * Time.deltaTime);
        }



        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        else if (transform.position.y <= -4.71f)
        {
            transform.position = new Vector3(transform.position.x, -4.71f, transform.position.z);
        }

        if (transform.position.x > 13.2f)
        {
            transform.position = new Vector3(-13.2f, transform.position.y, 0); ;
        }
        else if (transform.position.x < -13.2f)
        {
            transform.position = new Vector3(13.2f, transform.position.y, 0);
        }
    }

    public void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _laserEnable < Time.time)
        {
            _laserEnable = _firerate + Time.time;

            if (TripleShotActive == true)
            {
                Instantiate(TrippleShotWeapons, transform.position, Quaternion.identity);
                // AudioSource.Play(_laserShooter);
            }
            else
            {
                Instantiate(_laserprefab, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
                //AudioSource.Play(_laserShooter);
            }
            _audioSource.Play();
        }
    }

    public void Damage()
    {

        //if (ShieldsCondition == 1)
            if (ShieldsActive == true)
        {
            ShieldsActive = false;
            ShieldVisualizer.SetActive(false);
            return;
        }
        else if (ShieldsActive == false)
        { 
        
        
        _lives--;
     
        _UiManager.UpdateLives(_lives);
        Debug.Log("lives are at ^^^^^^^^^^^^^^^^^^^^^^^" + _lives);

        if (_lives == 2)
        {
            _LeftEngine.SetActive(true);
        }
        else if (_lives == 1)
        {
            _RightEngine.SetActive(true);
        }
        ///////////////// Problem I had another thing named like this is this a gameObject?
       _UiManager.UpdateLives(_lives);

            if (_lives < 1)
            {
            _spawnManager.OnPlayerdeath();
            Destroy(this.gameObject);
            }
        }
    }


    public void TripleShotCollected()
    {
        TripleShotActive = true;
        StartCoroutine(TriplePowerDown());
    }

    IEnumerator TriplePowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        TripleShotActive = false;
    }

    public void SpeedCollected()
    {
        SpeedActive = true;
        _speed *= _speedMultiplier;
        StartCoroutine(SpeedPowerDown());
    }

    IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        _speed /= _speedMultiplier;
        SpeedActive = false;
    }

    public void ShieldsCollected()
        {
            ShieldsActive = true;
            ShieldVisualizer.SetActive(true);
            StartCoroutine(ShieldsPowerDown());
    }

        IEnumerator ShieldsPowerDown()
        {
            yield return new WaitForSeconds(5.0f);
            ShieldsActive = false;
            
        }
    public void AddScore(int points)
    {
        _score += points;
        _UiManager.UpdateScore(_score);
    }

}

