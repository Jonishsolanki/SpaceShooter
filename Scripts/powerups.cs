using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerups : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.0f;
    [SerializeField]
    private int _powerUpID;
    private Player _player;
    [SerializeField]
    private AudioClip _clip;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -5.775f)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (_player != null)
        {
            if (other.tag == "Player")
            {
                AudioSource.PlayClipAtPoint(_clip, transform.position);
                switch (_powerUpID)
                {
                    case 0:
                        Destroy(this.gameObject);
                        _player.TrippleShot();
                        break;
                    case 1:
                        Destroy(this.gameObject);
                        _player.Speed();
                        break;
                    case 2:
                        Destroy(this.gameObject);
                        _player.Shield();
                        _player.count = 0;
                        break;
                }
            }
        }
    }
}
