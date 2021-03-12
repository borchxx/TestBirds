using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private bool direction = true;
    [SerializeField] private int score = 0;
    [SerializeField] public ScoreData scoreData;
    [SerializeField] private int jump = 0;
    [SerializeField] private int platformNumber = 0;
    [SerializeField] private int prevPlatformNumber = 0;
    [SerializeField] private TextMeshProUGUI _coins;
    [SerializeField] private TextMeshProUGUI _currentScore;

    private Rigidbody2D rb;


    private void Awake()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Jump();
            }
        }
        ChangeDirectionPlayer();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "LeftWall":
                direction = true;
                player.GetComponent<SpriteRenderer>().flipX = false;
                break;
            case "RightWall":
                direction = false;
                player.GetComponent<SpriteRenderer>().flipX = true;
                break;
            case "Platform":
                if (jump > 0)
                {
                    var posPunch = new Vector3(0, -0.3f, 0.2f);
                    other.gameObject.transform.DOPunchPosition(posPunch, 0.3f, 0, 1);
                }
                jump = 0;
                ScoreCounter(other);
                break;
            case "Bonus":
                Destroy(other.gameObject);
                scoreData.coins++;
                _coins.text = scoreData.coins.ToString();
                break;
            case "ScoreCollision":
                
                break;
        }
    }

    private void ScoreCounter(Collider2D other)
    {
        if (other.gameObject.name == platformNumber.ToString() || other.gameObject.name == prevPlatformNumber.ToString())
        {
            Debug.Log(other.gameObject.name);
        }
        else
        {
            other.gameObject.name = platformNumber.ToString();
            prevPlatformNumber = platformNumber;
            scoreData.previousScore = prevPlatformNumber;
            _currentScore.text = scoreData.previousScore.ToString();
            if (scoreData.bestScore < scoreData.previousScore)
            {
                scoreData.bestScore = scoreData.previousScore;
            }
            platformNumber++;
        }
    }

    [Button]
    private void Jump()
    {
        if (jump < 2)
        {
            rb.AddForce(player.transform.up * 5, ForceMode2D.Impulse);
            jump++;
        }
    }

    private void ChangeDirectionPlayer()
    {
        if (direction)
        {
            player.transform.position += transform.right * Time.deltaTime * 3;
        }
        else
        {
            player.transform.position += -transform.right * Time.deltaTime * 3;
        }
    }
}
