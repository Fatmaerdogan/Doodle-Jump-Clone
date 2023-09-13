using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    [SerializeField] private Platform platformPrefab;

	int numberOfPlatforms = 500;
	float levelWidth = 3f;

	void Start () {

        Spawn();
	}
	void Spawn()
	{
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
           
            spawnPosition.y += Random.Range(0.2f, 1.5f);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Platform platform= Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            if (i % 10 == 0 && i != 0)
                platform.SpriteSet((PlatformType)Random.Range(0, 4));
            else
                platform.SpriteSet(PlatformType.standard);
        }
    }
}
