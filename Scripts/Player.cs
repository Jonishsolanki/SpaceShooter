using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private GameObject _laser,_trippleShot,_Shield;
    [SerializeField]
    public int lives = 4, _score = 0,_bestScore=0;
    [SerializeField]
    public int count=0;
    private SpawnManager _sm;
    [SerializeField]
    private bool _istrippleShotActive = false, _isSpeedActive = false, _isShieldActive = false;
    [SerializeField]
    private GameObject[] Fire;
    private AudioSource _laserAudio;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _laserAudio = GetComponent<AudioSource>();
        _bestScore = PlayerPrefs.GetInt("highscore", _bestScore);
    }

    // Update is called once per frame
    void Update()
    {
        float HI = CrossPlatformInputManager.GetAxis("Horizontal"); //Input.GetAxis("Horizontal");
        float VI = CrossPlatformInputManager.GetAxis("Vertical");  //Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(HI, VI, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
        if (_isSpeedActive == true)
        {
            transform.Translate(direction * 2 * _speed * Time.deltaTime);
        }

        movement();
        fire();
        PlayerHurt();
    }
    void movement()
    {
        if (transform.position.x >= 9)
        {
            transform.position = new Vector3(9, transform.position.y, 0);
        }
        if (transform.position.x <= -9)
        {
            transform.position = new Vector3(-9, transform.position.y, 0);
        }
        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x,0, 0);
        }
        if (transform.position.y <= -3.35f)
        {
            transform.position = new Vector3(transform.position.x,-3.35f, 0);
        }
    }
    void fire()
    {
#if UNITY_ANDROID
     if(_istrippleShotActive==true){
     if(CrossPlatformInputManager.GetButtonDown("Fire")){
                     Instantiate(_trippleShot, transform.position + new Vector3(0,0,0), Quaternion.identity);
                _laserAudio.Play(); 
                }
                }
      else
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire"))
            {
                Instantiate(_laser, transform.position + new Vector3(0, 1.95f, 0), Quaternion.identity);
                _laserAudio.Play();
            }
        }
#else
        if (_istrippleShotActive == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Instantiate(_trippleShot, transform.position + new Vector3(0,0,0), Quaternion.identity);
                _laserAudio.Play();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Instantiate(_laser, transform.position + new Vector3(0, 1.95f, 0), Quaternion.identity);
                _laserAudio.Play();
            }
        }
#endif
    }
    public void Damage()
    {
        if (_isShieldActive == true)
        {
            count++;
            if (count == 10)
            {
                _isShieldActive = false;
                _Shield.SetActive(false);
                count = 0;
            }
        }
        else
        {
            lives--;
            _istrippleShotActive = false;
            _isSpeedActive = false;
            if (lives == 0)
            {
                Destroy(this.gameObject);
                _sm.OnPlayerDeath();
            }
        }
       
    }
    public void UpdateScore(int x)
    {
        _score = _score + x;
        if (_score > _bestScore)
        {
            _bestScore = _score;
             PlayerPrefs.SetInt ("highscore", _bestScore);
        }
    }
    public void TrippleShot()
    {
        _istrippleShotActive = true;
    }
    public void Shield()
    {
        _isShieldActive = true;
        _Shield.SetActive(true);
    }
    public void Speed()
    {
        _isSpeedActive = true;
    }
    public void PlayerHurt()
    {
        if (lives == 3)
        {
            Fire[0].SetActive(true);
        }
        if (lives == 2)
        {
            Fire[1].SetActive(true);
        }
        if (lives == 1)
        {
            Fire[2].SetActive(true);
        }
    }
}
