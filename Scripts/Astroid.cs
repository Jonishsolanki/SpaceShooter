using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.0f;
    private Player _player;
    private Animator _Explosion;
    private AudioSource _ExplosionAudio;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _Explosion = GetComponent<Animator>();
        _ExplosionAudio = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -6.2f)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (_player != null)
            {
                _ExplosionAudio.Play();
                _speed = 0;
                _Explosion.SetTrigger("AstroidAnim");
                _player.Damage();
                Destroy(this.gameObject,0.7f);
            }
        }
        if (other.tag == "Laser")
        {
            _ExplosionAudio.Play();
            _speed = 0;
            _player._score += 50;
            _Explosion.SetTrigger("AstroidAnim");
            Destroy(this.gameObject,0.7f);
            Destroy(other.gameObject);
        }
    }
}
