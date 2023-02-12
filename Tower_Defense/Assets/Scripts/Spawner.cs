using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    [SerializeField] Entities entities;
    [SerializeField] GroundSpawn spawns;

    Vector3 spawnPoint = new Vector3();
    Vector3 destination = new Vector3();

    int waveCounter = 1;
    int waveSize;

    [SerializeField] TMP_Text waveText;
    [SerializeField] TMP_Text timeRemaining;
    [SerializeField] TMP_Text winText;

    int countdown;

    private void Start()
    {
        waveSize = spawns.intitialWaveSize;
        spawnPoint = new Vector3(spawns.startPosition.x * spawns.gridSize + spawns.gridSize / 2, 0.5f, spawns.startPosition.y * spawns.gridSize + spawns.gridSize / 2);
        destination = new Vector3(spawns.endPosition.x * spawns.gridSize + spawns.gridSize / 2, 0.5f, spawns.endPosition.y * spawns.gridSize + spawns.gridSize / 2);
        UpdateWaveText();
        StartCoroutine(SpawnEntities());
    }

    IEnumerator SpawnEntities()
    {
        if(waveCounter == 1)
        {
            countdown = 15;
            StartCoroutine(CountDown());
            yield return new WaitForSecondsRealtime(15f);
        }
        if (waveCounter <= spawns.numberOfWaves)
        {
            for (int i = 0; i < waveSize; i++)
            {
                yield return new WaitForSecondsRealtime(1f);
                SpawnEntity();
            }

            waveCounter++;
            waveSize += Random.Range(0, 3);
            countdown = 30;
            StartCoroutine(CountDown());
            yield return new WaitForSecondsRealtime(30f);
            UpdateWaveText();
            StartCoroutine(SpawnEntities());
        }
        else
        {
            if (Player.Instance.HP.hp > 0)
            {
                winText.text = "You Won!";
                winText.gameObject.SetActive(true);
            }
            Debug.Log("WAVES ENDED");
            yield break;
        }
    }

    IEnumerator CountDown()
    {
        if(countdown == 0)
            yield break;

        countdown--;
        timeRemaining.text = countdown.ToString();
        yield return new WaitForSeconds(1f);
        StartCoroutine(CountDown());
    }
    void UpdateWaveText()
    {
        waveText.text = "Wave Number: " + waveCounter.ToString();
    }
    void SpawnEntity()
    {
        GameObject entity = Instantiate(entities.entities[GetRandomChances()], spawnPoint, Quaternion.identity);
        entity.GetComponent<Enemy>().agent.SetDestination(destination);
        //entity.GetComponent<Enemy>().agent.isStopped = false;
    }

    private int GetRandomChances()
    {
        float randomChance = Random.Range(0f, 1f);
        float numberToAdd = 0;
        float total = 0;

        for (int i = 0; i < entities.chancesToSpawn.Length; i++)
        {
            total += entities.chancesToSpawn[i];
        }

        for (int i = 0; i < entities.entities.Length; i++)
        {
            if(entities.chancesToSpawn[i] / total + numberToAdd >= randomChance)
            {
                return i;
            }
            else
            {
                numberToAdd += entities.chancesToSpawn[i] / total;
            }
        }

        return 0;
    }
}
