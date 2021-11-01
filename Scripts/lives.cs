using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lives : MonoBehaviour
{
    private Player _player;
    [SerializeField]
    private GameObject[] life;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.lives == 3)
        {
            life[0].SetActive(true);
        }
        else
        {
            life[0].SetActive(false);
        }
        if (_player.lives == 2)
        {
            life[1].SetActive(true);
        }
        else
        {
            life[1].SetActive(false);
        }
        if (_player.lives == 1)
        {
            life[2].SetActive(true);
        }
        else
        {
            life[2].SetActive(false);
        }
        if (_player.lives == 4)
        {
            life[3].SetActive(true);
        }
        else
        {
            life[3].SetActive(false);
        }

    }
}
