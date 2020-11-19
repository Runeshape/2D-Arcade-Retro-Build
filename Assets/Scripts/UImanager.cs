using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{

    [SerializeField]
    private Text _ScoreText;
    [SerializeField]
    private Image _Livesimg;
    [SerializeField]
    private Text _GameOverText; 
    [SerializeField]
    private Sprite[] _livesSprite;
    [SerializeField]
    private Text _RtoRestart;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //_livesSprite[CurrentPlayerLiveS = 3]
        _ScoreText.text = "Score :  " + 0;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.Log("The game manger is null");
        }

    }

    // Update is called once per frame
    public void UpdateScore(int PlayerScore)
    {
    _ScoreText.text = "_Score :  " + PlayerScore.ToString();
        
    }

    public void UpdateLives(int CurrentLives)
    {
        _Livesimg.sprite = _livesSprite[CurrentLives];
        if (CurrentLives == 0) 
        {
            gameOverSeq();
        }
    }

    public void gameOverSeq()
    {
        _gameManager.GameOver();
        _GameOverText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlicker());
        _RtoRestart.gameObject.SetActive(true);
    }

    IEnumerator GameOverFlicker()
    {

        while (true)
        {
            _GameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(.5f);
            _GameOverText.text = "";
            yield return new WaitForSeconds(.5f);
        }

    }

}
