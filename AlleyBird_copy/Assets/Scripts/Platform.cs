using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class Platform : MonoBehaviour
{
    public bool firstPlatform = false;
    [SerializeField] private float _offsetPlatform;
    [SerializeField] private int _chanceSpawnEnemy;
    [SerializeField] private int _chanceSpawnBonus;
    [SerializeField] private GameObject _walkingEnemy;
    [SerializeField] private GameObject _idleEnemy;
    [SerializeField] private GameObject _bonus;

    void Start()
    {
        if (!firstPlatform)
        {
            _chanceSpawnEnemy = Random.Range(1, 10);
            if (_chanceSpawnEnemy > 5)
            {
                SpawnEnemy();
            }
            _chanceSpawnBonus = Random.Range(1, 100);
            if (_chanceSpawnBonus < 30)
            {
                SpawnBonus();
            }
        } 
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "DeadZone")
            ChangePositionPlatform();
    }

    private void ChangePositionPlatform()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + _offsetPlatform, transform.position.z);
        _chanceSpawnEnemy = Random.Range(1, 10);
        if (_chanceSpawnEnemy > 5)
        {
            SpawnEnemy();
        }
    }

    [Button]
    private void SpawnEnemy()
    {
        int typeEnemy = Random.Range(1,100);
        float posX = Random.Range(-1.7f, 1.7f);
        Vector3 positionEnemy = new Vector3(transform.position.x + posX, transform.position.y + 0.79f, transform.position.z);

        if (typeEnemy < 30)
        {
            Instantiate(_walkingEnemy, positionEnemy, Quaternion.identity);
        }
        else
        {
            Instantiate(_idleEnemy, positionEnemy, Quaternion.identity);
        }
        
    }

    private void SpawnBonus()
    {
        float posX = Random.Range(-1.7f, 1.7f);
        Vector3 positionBonus = new Vector3(transform.position.x + posX, transform.position.y + 0.79f, transform.position.z);
        Instantiate(_bonus, positionBonus, Quaternion.identity);
    }
}
