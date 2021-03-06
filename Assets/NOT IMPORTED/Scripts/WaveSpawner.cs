﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public SpawnPoint SpawnPoint;
    [SerializeField]
    public List<WaveSettings> Waves = new List<WaveSettings>();
    [System.Serializable]
    public struct WaveSettings
    {
        public GameObject Enemy;
        public float DamageMitigationModifier;
        public int NumberOfEnemies;
        public float WaveTimeDuration;
    }
    [ReadOnly]
    public int currentWave = 0;
    [ReadOnly]
    public float SpawnTimer;
    [ReadOnly]
    public int NumberOfEnemiesSpawned;
    public WaveSettings CurrentWaveSettings;
	// Use this for initialization
	void Start () {
        if (Waves.Count > 0)
        {
            CurrentWaveSettings = Waves[0];
            GetComponent<SpawnPoint>().MitigationModifier = CurrentWaveSettings.DamageMitigationModifier;
        }
        else
        {
            throw new System.ArgumentNullException("Waves can't be empty");
        }
	}
	void FixedUpdate()
    {
        //spawn logic
        if (NumberOfEnemiesSpawned < CurrentWaveSettings.NumberOfEnemies)
        {
            if (SpawnTimer <= CurrentWaveSettings.WaveTimeDuration / CurrentWaveSettings.NumberOfEnemies)
            {
                SpawnTimer += Time.deltaTime;
            }
            else
            {
                SpawnPoint.Spawn(CurrentWaveSettings.Enemy);
                NumberOfEnemiesSpawned++;
                SpawnTimer = 0;
            }
        }
        //wave check for spawned enemies
        if (NumberOfEnemiesSpawned >= CurrentWaveSettings.NumberOfEnemies)
        {
            //see if there are any alive
            if (SpawnPoint.SpawnLocation.childCount < 1)
            {
                //new wave start
                if (currentWave + 1 < Waves.Count)
                {
                    currentWave++;
                    CurrentWaveSettings = Waves[currentWave];
                    SpawnTimer = 0;
                    NumberOfEnemiesSpawned = 0;
                }
                else
                {
                    SpawnTimer = 0;
                    NumberOfEnemiesSpawned = 0;
                    if (CurrentWaveSettings.DamageMitigationModifier == 0)
                    {
                        CurrentWaveSettings.DamageMitigationModifier = 0.05f;
                    }
                    CurrentWaveSettings.DamageMitigationModifier *= 1.1f;
                    Debug.Log("no more waves, repeating wave " + currentWave + " with damage mitigation upped to" + CurrentWaveSettings.DamageMitigationModifier);
                }
                GetComponent<SpawnPoint>().MitigationModifier = CurrentWaveSettings.DamageMitigationModifier;
            }
        }
    }
	// Update is called once per frame
	void Update () {
	}
}
