using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlatformConfigurator : MonoBehaviour
{
    [SerializeField] private GameObject _platform;
    [SerializeField] private int _quantityPlatform;


    void Start()
    {
        SpanwPlatform();
    }

    [Button]
    private void SpanwPlatform()
    {
        Vector2 spawnerPosition = new Vector2(0,-4);
        for (int i = 0; i < _quantityPlatform; i++)
        {
            var platform = Instantiate(_platform, spawnerPosition, Quaternion.identity);
            spawnerPosition.y += 3;
            if (i == 0 || i == 1)
            {
                platform.GetComponent<Platform>().firstPlatform = true;
            }
        }
    }
}
