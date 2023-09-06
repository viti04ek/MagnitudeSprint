using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> Enemies;
    public GameObject BarbellObstacle;
    public GameObject Coin;
    public GameObject SteakLoot;

    public GameObject FinishBarbells;

    private int _maxPossibleStrenght = 1;
    private int _prevObstacle = 0;


    private void OnEnable()
    {
        StartCoroutine("Spawn");
    }


    private IEnumerator Spawn()
    {
        for (int i = 0; i < 41; i++)
        {
            if (i < 40)
            {
                int rand = Random.Range(1, 6);
                switch (rand)
                {
                    case 1: SpawnOneEnemy(); break;
                    case 2: SpawnRowEnemies(); break;
                    case 3: SpawnBarbell(); break;
                    case 4: SpawnLoot(); break;
                    case 5: SpawnCoin(); break;
                }
                _prevObstacle = rand;
            }
            else
            {
                Instantiate(FinishBarbells, new Vector3(transform.position.x, 0.36f, transform.position.z), Quaternion.identity);
            }

            float randTime = Random.Range(0.8f, 1.1f);
            yield return new WaitForSeconds(randTime);
        }
    }


    private void SpawnOneEnemy()
    {
        int randNum = Random.Range(0, 4);
        float ranCoord = Random.Range(-2.5f, 2.5f);
        Instantiate(Enemies[randNum], new Vector3(ranCoord, transform.position.y, transform.position.z), Quaternion.Euler(0f, 180f, 0f));
    }


    private void SpawnRowEnemies()
    {
        if (_maxPossibleStrenght < 2)
        {
            SpawnLoot();
            return;
        }

        if (_prevObstacle == 2)
        {
            SpawnBarbell();
            _prevObstacle = 3;
            return;
        }

        int randNum1 = Random.Range(0, 4);
        int randNum2 = Random.Range(0, 4);
        int randNum3 = Random.Range(0, 4);
        int randNum4 = Random.Range(0, 4);
        int randNum5 = Random.Range(0, 4);
        if (randNum1 > 0 && randNum2 > 0 && randNum3 > 0 && randNum4 > 0 && randNum5 > 0)
            randNum3 = 0;

        Instantiate(Enemies[randNum1], new Vector3(-2f, transform.position.y, transform.position.z), Quaternion.Euler(0f, 180f, 0f));
        Instantiate(Enemies[randNum2], new Vector3(-0.97f, transform.position.y, transform.position.z), Quaternion.Euler(0f, 180f, 0f));
        Instantiate(Enemies[randNum3], new Vector3(0.153f, transform.position.y, transform.position.z), Quaternion.Euler(0f, 180f, 0f));
        Instantiate(Enemies[randNum4], new Vector3(1.238f, transform.position.y, transform.position.z), Quaternion.Euler(0f, 180f, 0f));
        Instantiate(Enemies[randNum5], new Vector3(2.376f, transform.position.y, transform.position.z), Quaternion.Euler(0f, 180f, 0f));

        _maxPossibleStrenght--;
    }


    private void SpawnBarbell()
    {
        float ranCoord = Random.Range(-2.5f, 2.5f);
        Instantiate(BarbellObstacle, new Vector3(ranCoord, 0.36f, transform.position.z), Quaternion.identity);
    }


    private void SpawnLoot()
    {
        if (_maxPossibleStrenght == 10)
        {
            SpawnRowEnemies();
            return;
        }

        float randCoord = Random.Range(-2.5f, 2.5f);
        Instantiate(SteakLoot, new Vector3(randCoord, 0.5f, transform.position.z), Quaternion.identity);

        _maxPossibleStrenght++;
    }


    private void SpawnCoin()
    {
        float ranCoord = Random.Range(-2.5f, 2.5f);
        Instantiate(Coin, new Vector3(ranCoord, 0.5f, transform.position.z), Quaternion.identity);
    }
}
