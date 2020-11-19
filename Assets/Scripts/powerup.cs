using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    private float _speed = 3.0f;
    [SerializeField]
    private int powerUpID;
    [SerializeField]
    private AudioClip _audioClip;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down *_speed* Time.deltaTime);
        if (transform.position.y < -2.0f)
            {
            Destroy(this.gameObject);
            }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                AudioSource.PlayClipAtPoint(_audioClip ,transform.position);
                switch (powerUpID)// 0 tripple 1 shields 2 speed
                {
                    case 0:
                        Debug.Log("0");
                        player.TripleShotCollected();
                        break;
                    case 1:
                        Debug.Log("1");
                        player.ShieldsCollected();
                        break;
                    case 2:
                        player.SpeedCollected();
                        break;
                    default:
                        Debug.Log("Not Implimented");
                        break;




                }
                //{
                //    switch (powerUpID)
                //    {
                //        case 0:
                //              player.TripleShotCollected();
                //              break;
                //        case 1:
                //            player.SpeedActive();
                //            break;
                //        case 2:
                //            player.ShieldsActive();
                //            break;
                //        Default:
                //            Debug.Log("not implimented");
                //            break;

                //    }


                Destroy(this.gameObject);
            }
        }
    
    }

    //public void TripleShotCollected()
    //{
    //    TripleShotActive = true;
    //    StartCoroutine(TriplePowerDown());
    //}

    //IEnumerator TriplePowerDown()
    //{
    //    yield return new WaitForSeconds(5.0f);
    //    TripleShotActive = false;
    //}

    //public void SpeedCollected()
    //{
    //    SpeedActive = true;
    //    StartCoroutine(SpeedPowerDown());
    //}

    //IEnumerator SpeedPowerDown()
    //{
    //    yield return new WaitForSeconds(5.0f);
    //    SpeedActive = false;
    //}

    //public void ShieldsCollected()
    //{
    //    ShieldsActive = true;
    //    StartCoroutine(ShieldsPowerDown());
    //}

    //IEnumerator ShieldsPowerDown()
    //{
    //    yield return new WaitForSeconds(5.0f);
    //    ShieldsActive = false;
    //}
}

//public void TripleShotCollected()
//{
//    TripleShotActive = true;
//    StartCoroutine(TriplePowerDown());
//}

//IEnumerator TriplePowerDown()
//{
//    yield return new WaitForSeconds(5.0f);
//    TripleShotActive = false;
//}

//public void SpeedCollected()
//{
//    SpeedActive = true;
//    StartCoroutine(SpeedPowerDown());
//}

//IEnumerator SpeedPowerDown()
//{
//    yield return new WaitForSeconds(5.0f);
//    SpeedActive = false;
//}

//public void ShieldsCollected()
//{
//    ShieldsActive = true;
//    StartCoroutine(ShieldsPowerDown());
//}

//IEnumerator ShieldsPowerDown()
//{
//    yield return new WaitForSeconds(5.0f);
//    ShieldsActive = false;
//}