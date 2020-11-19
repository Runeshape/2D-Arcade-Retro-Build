using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public int points = 10;
    [SerializeField]
    private float _speed = 4.0f;
    private Player _player;
    private Animator _anim;
    private AudioSource _audioSource;


    
    // Start is called before the first frame update
    void Start()
    {
        ////Do I do anything? _player = GameObject.Find("Player").GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
        ///////// REferance is not set as an instance of an Object 
       // _player = GameObject.Find("Player").GetComponent<Player>();
        transform.position = new Vector3(Random.Range(-8f, 8f), 7.5f, 0); 
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y <= -7f)
        {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 7f, transform.position.z);
        }
        else
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }
    
    
}
    private void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("collided with" + other);

        if (other.tag == "Player")
        {
            Debug.Log("THe player was hit by enemy");
            Player player = other.transform.GetComponent<Player>();
            
            if (player != null)
            {
                player.Damage();
            }


            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            _audioSource.Play();
            Destroy(this.gameObject, 2.7f);
        }
        if(other.tag == "Laser")
        {
            Debug.Log("________Enemy was hit by laser");
            if (_player != null)
            {
                points *= 10;
                //points = (10 * Mathf.Exp(_speed, (whatevwr I have to do to get it)_lives));
                _player.AddScore(points);
            }

            _anim.SetTrigger("OnEnemyDeath");
            _audioSource.Play();
            Destroy(other.gameObject, 2.7f);
            Destroy(this.gameObject, 2.7f);

        }


        Debug.Log("hit " + other.transform.name);
    }

   
         
}
