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

    public void ChangeSpeed(int speed)
    {
        Time.timeScale = speed;
    }

    private void Update()
    {
        speedText.text = "Speed: " + Time.timeScale;

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
