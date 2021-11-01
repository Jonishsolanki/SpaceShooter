using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private Player _player;
    [SerializeField]
    private Text _GameOverText;

    [SerializeField]
    private bool _isGameOver = false;
    [SerializeField]
    private GameObject _pauseButton, _resumeButton;
    [SerializeField]
    private Text _ScoreText,_HighScoreText;
    //private Text
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _ScoreText.text = "Score: " + 0;
        _HighScoreText.text = "HighScore: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.lives < 1)
        {
            _isGameOver = true;
            _GameOverText.gameObject.SetActive(true);
            StartCoroutine(GameOverFlicker());
        }
        _ScoreText.text = "Score:" + _player._score;
        _HighScoreText.text = "HighScore: " + _player._bestScore;
    }
    IEnumerator GameOverFlicker()
    {
        while (_isGameOver == true)
                {
                    _GameOverText.text= "Game Over!";
                    yield return new WaitForSeconds(0.5f);
                    _GameOverText.text = "";
                    yield return new WaitForSeconds(0.5f);
                }
    }
    public void pauseGame()
    {
        Time.timeScale = 0;
        _pauseButton.SetActive(false);
        _resumeButton.SetActive(true);
    }
    public void resumeGame()
    {
        Time.timeScale = 1;
        _resumeButton.SetActive(false);
        _pauseButton.SetActive(true);
    }
    public void HomePage()
    {
        SceneManager.LoadScene(0);
    }
}
