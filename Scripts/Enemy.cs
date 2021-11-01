using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.0f;
    private Player _player;
    [SerializeField]
    private Animator _EnemyExplosionAnim;
    private AudioSource _Explosion;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _Explosion = GetComponent<AudioSource>();
        if (_Explosion == null)
        {
            Debug.LogError("_explosion is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if (transform.position.y <= -5.78f)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _Explosion.Play();
            _speed = 0;
            _EnemyExplosionAnim.SetTrigger("EnemyExplosion");
            Destroy(this.gameObject,1.0f);
            //Destroy(other.gameObject);
            if (_player != null)
            {
                _player.Damage();
            }
        }
        if (other.tag == "Laser")
        {
            _Explosion.Play();
            _speed = 0;
            _EnemyExplosionAnim.SetTrigger("EnemyExplosion");
            _player.UpdateScore(10);
            Destroy(other.gameObject);
            Destroy(this.gameObject,1.0f);
        }
    }
}
