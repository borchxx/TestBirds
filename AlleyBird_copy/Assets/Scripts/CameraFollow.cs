using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _smoothTimeY;
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI _bestScoreLogo;
    public bool startFlag = true;

    private Vector2 _velocityCamera;

    private void Start()
    {
        _bestScoreLogo.text = "BEST " + player.GetComponent<Player>().scoreData.bestScore;
    }

    private void FixedUpdate()
    {
        if(!startFlag)
        SmoothCamera();
    }

    private void SmoothCamera()
    {
        float posY = Mathf.SmoothDamp(transform.position.y, _player.position.y, ref _velocityCamera.y, _smoothTimeY);
        transform.position = new Vector3(transform.position.x, posY + 0.5f, transform.position.z);
    }

    [Button]
    public void StartCameraPosition()
    {
        var endPos = new Vector3(0,0,-10);
        transform.DOMove(endPos,0.4f);
        startFlag = false;
        player.GetComponent<Player>().enabled = true;
    }
}
