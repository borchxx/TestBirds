using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeEnemy
{
    IdleEnemy,
    WalkingEnemy
}

public class Enemy : MonoBehaviour
{
    [SerializeField] private TypeEnemy _typeEnemy;
    [SerializeField] private int _speedEnemy = 2;
    private bool direction = true;

    

    void Update()
    {
        WalkEnemy();
    }

    private void WalkEnemy()
    {
        if (_typeEnemy == TypeEnemy.WalkingEnemy)
        {
            if (direction)
            {
                transform.position += transform.right * Time.deltaTime * _speedEnemy;
            }
            else
            {
                transform.position += -transform.right * Time.deltaTime * _speedEnemy;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_typeEnemy == TypeEnemy.WalkingEnemy)
        {
            switch (other.tag)
            {
                case "LeftWall":
                    direction = true;
                    GetComponent<SpriteRenderer>().flipX = false;
                    break;
                case "RightWall":
                    direction = false;
                    GetComponent<SpriteRenderer>().flipX = true;
                    break;
            }
        }

        switch (other.tag)
        {
            case "DeadZone":
                Destroy(gameObject);
                break;
            case "Player":
                Debug.Log("GAME OVER");
                break;
        }
    }
}
