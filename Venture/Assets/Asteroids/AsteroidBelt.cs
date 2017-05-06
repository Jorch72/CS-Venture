﻿using UnityEngine;

public class AsteroidBelt : MonoBehaviour
{
    private void Start()
    {
        for(int i = 0; i < 100; i++)
        {
            GameObject obj = new GameObject();
            obj.transform.position = Random.insideUnitSphere * 20.0f;
            obj.AddComponent<Asteroid>();
        }
    }
}