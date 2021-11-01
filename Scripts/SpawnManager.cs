using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy,_Astroid;
    [SerializeField]
    private GameObject[] _powerups;
    [SerializeField]
    private bool _isplayerDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnAstroid());
        StartCoroutine(SpawnPowerUps());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnEnemy()
    {
        while (_isplayerDeath == false)
        {
            Instantiate(_enemy, transform.position + new Vector3(Random.Range(-9, 9), 7.775f, 0), Quaternion.identity);
            yield return new WaitForSeconds(2.0f);
        }
    } 
    IEnumerator SpawnAstroid()
    {
        while (_isplayerDeath == false)
        {
            yield return new WaitForSeconds(10.0f);
            Instantiate(_Astroid, transform.position + new Vector3(Random.Range(-9, 9), 7.93f, 0), Quaternion.identity);
            yield return new WaitForSeconds(12.0f);
        }
    }
    IEnumerator SpawnPowerUps()
    {
        while (_isplayerDeath == false)
        {
            yield return new WaitForSeconds(10.0f);
            Instantiate(_powerups[Random.Range(0,3)], transform.position + new Vector3(Random.Range(-9.2f, 9.2f), 7.6f, 0), Quaternion.identity);
            yield return new WaitForSeconds(10.0f);
        }
    }
    public void OnPlayerDeath()
    {
        _isplayerDeath = true;
    }
}
