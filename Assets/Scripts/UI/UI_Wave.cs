using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Wave : MonoBehaviour
{
    [SerializeField] private EnemiesSpawner enemiesSpawner;
    [SerializeField] private GameObject uiDuringWave;
    [SerializeField] private GameObject uiBetweenWaves;
    [SerializeField] private TMP_Text speedText;
    [SerializeField] private TMP_Text waveText;
    private int waveNumber;

    public void ChangeSpeed(int speed)
    {
        Time.timeScale = speed;
    }

    private void Update()
    {
        speedText.text = "Speed: " + Time.timeScale;
        waveNumber = enemiesSpawner.waveNumber - 1;
        waveText.text = "Wave: " + waveNumber;

        if(enemiesSpawner.enemiesAlive.Count > 0)
        {
            uiDuringWave.SetActive(true);
            uiBetweenWaves.SetActive(false);
        }
        else
        {
            uiDuringWave.SetActive(false);
            uiBetweenWaves.SetActive(true);
        }
    }
}
