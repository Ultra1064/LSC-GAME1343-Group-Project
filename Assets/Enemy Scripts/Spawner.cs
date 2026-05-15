using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject bigEnemy;
    [SerializeField] private GameObject healEnemy;
    [SerializeField] private GameObject smolEnemy;
    [SerializeField] private GameObject bossEnemy;
    [SerializeField] private Transform center; //Meant to be the payload
    private float timer = 0;
    private int difficulty = 0; //This will increment when the timer reaches a threshold, starting a new update function
    private int spawnCount = 0; //Counts number of times a spawn happens.
    Vector2 spawnPoint;
    private int enemyType; //This is a dice roll
    [SerializeField] private int radius = 11;

    private void Start()
    {
        enemy.GetComponent<EnemyAI>().target = center; //Need to set the center for each enemy in their scripts
        bigEnemy.GetComponent<EnemyAI>().target = center;
        healEnemy.GetComponent<EnemyAI>().target = center;
        smolEnemy.GetComponent<EnemyAI>().target = center;
        bossEnemy.GetComponent<EnemyAI>().target = center;
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime; //Time increments
        switch (difficulty) //The difficulty value decides which spawner gets called.
        {
            case 0:
                SpawnDifficulty0();
                break;
            case 1:
                SpawnDifficulty1();
                break;
            case 2:
                SpawnDifficulty2();
                break;
            case 3:
                SpawnDifficulty3();
                break;
            case 4:
                SpawnDifficulty4();
                break;
            case 5:
                SpawnBoss();
                break;
        }
    }

    void SpawnDifficulty0()
    {
        if (timer >= 5) //Every 5 seconds, the timer resets and spawns an enemy.
        {
            timer = 0;
            spawnCount++;
            spawnPoint = GetRandomPointInCircle();
            Instantiate(enemy, spawnPoint, transform.rotation);
        }
        if (spawnCount >= 2) //Once the game has initiated a spawn twice (meaning in 10 seconds), the spawn count is reset, and the difficulty goes up
        {
            spawnCount = 0;
            difficulty++;
        }
    }

    void SpawnDifficulty1()
    {
        if (timer >= 3)
        {
            timer = 0;
            spawnCount++;
            spawnPoint = GetRandomPointInCircle();
            enemyType = Random.Range(1, 3); //Dice roll to decide spawn options
            switch (enemyType)
            {
                case 1:
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    break;
                case 2:
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    break;
                case 3:
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    break;
            }
        }
        if (spawnCount >= 7) //Or after 21 seconds (3 from the if statement * spawnCount)
        {
            spawnCount = 0;
            difficulty++;
        }
    }

    void SpawnDifficulty2()
    {
        if (timer >= 2)
        {
            timer = 0;
            spawnCount++;
            spawnPoint = GetRandomPointInCircle();
            enemyType = Random.Range(1, 10);
            switch (enemyType)
            {
                case 1:
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    break;
                case 2:
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    break;
                case 3:
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    break;
                case 4:
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    break;
                case 5:
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    break;
                case 6:
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    break;
                case 7:
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    break;
                case 8:
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    break;
                case 9:
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    break;
                case 10:
                    Instantiate(healEnemy, spawnPoint, transform.rotation);
                    break;

            }
        }
        if (spawnCount >= 15) //Or after 30 seconds (2 from the if statement * spawnCount)
        {
            spawnCount = 0;
            difficulty++;
        }
    }

    void SpawnDifficulty3()
    {
        if (timer >= 2)
        {
            timer = 0;
            spawnPoint = GetRandomPointInCircle();
            spawnCount++;
            enemyType = Random.Range(1, 12);
            switch (enemyType)
            {
                case 1:
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    break;
                case 2:
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    break;
                case 3:
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    break;
                case 4:
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    break;
                case 5:
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    break;
                case 6:
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    break;
                case 7:
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    break;
                case 8:
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    break;
                case 9:
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    break;
                case 10:
                    Instantiate(healEnemy, spawnPoint, transform.rotation);
                    break;
                default:
                    Instantiate(healEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(healEnemy, spawnPoint, transform.rotation);
                    break;
            }
        }
        if (spawnCount >= 60) //Or after 2 minutes (2 seconds from the if statement * spawnCount)
        {
            spawnCount = 0;
            difficulty++;
        }
    }

    void SpawnDifficulty4()
    {
        if (timer >= 1)
        {
            timer = 0;
            spawnPoint = GetRandomPointInCircle();
            spawnCount++;
            enemyType = Random.Range(1, 12);
            switch (enemyType)
            {
                case 1:
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    break;
                case 2:
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    break;
                case 3:
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    break;
                case 4:
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    break;
                case 5:
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    break;
                case 6:
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    break;
                case 7:
                    Instantiate(bigEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    break;
                case 8:
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    break;
                case 9:
                    Instantiate(smolEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(enemy, spawnPoint, transform.rotation);
                    break;
                case 10:
                    Instantiate(healEnemy, spawnPoint, transform.rotation);
                    break;
                default:
                    Instantiate(healEnemy, spawnPoint, transform.rotation);
                    spawnPoint = GetRandomPointInCircle();
                    Instantiate(healEnemy, spawnPoint, transform.rotation);
                    break;
            }
        }
        if (spawnCount >= 10) //Or after 10 seconds (1 from the if statement * spawnCount)
        {
            difficulty++;
        }
    }
    void SpawnBoss() //This stops ALL spawning after spawning the boss
    {
        spawnPoint = GetRandomPointInCircle();
        Instantiate(bossEnemy, spawnPoint, transform.rotation);
        Destroy(gameObject);
    }

    Vector2 GetRandomPointInCircle()
    {
        Vector2 random = Random.insideUnitCircle * radius; //Random.insideUnitCircle gets a random coordinate from the unit circle, a unit circle always has the value of 1, so using the radius value gives us coordinates of a circle with the radius of the variable.
        if (Mathf.Abs(random.x) < Mathf.Abs(random.y)) //This if statement checks if the absolute value of the x coord is smaller than the y coord. I'm really just checking if the coord is closer to the top/bottom of the screen or the side of the screen.
        {
            if (random.y + center.position.y > center.position.y) //If the coordinates are closer to the top or bottom of the screen, this checks if it's the top OR bottom. This statement specifically checks if it's closer to the top.
                random = new Vector2(random.x, random.y - 3);
            else
                random = new Vector2(random.x, random.y + 3); //If the last one is false, then this one MUST be true, so the coord went below the center.
        }
        random.Normalize(); //Sets vector to 1
        random *= radius; //This makes sure the vector is on the PERIMETER, and not INSIDE, the unit circle.
        return center.position + new Vector3(random.x, random.y, 0f);
    }

    /*void FixedUpdate() //NO LONGER USING THIS
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            Vector2 spawnPoint = GetRandomPointInCircle();
            enemyType = Random.Range(0, 100); //This determines the chance for other enemy types to spawn
            if (enemyType < 25) //IF THE GAME IS LAGGY, CHECK THIS FIRST
            {
                Instantiate(enemy, spawnPoint, transform.rotation);
            }
            else if (enemyType < 50)
            {
                Instantiate(enemy, spawnPoint, transform.rotation);
                spawnPoint = GetRandomPointInCircle();
                Instantiate(enemy, spawnPoint, transform.rotation);
            }
            else if (enemyType < 55)
            {
                Instantiate(smolEnemy, spawnPoint, transform.rotation);
            }
            else if (enemyType < 60)
            {
                Instantiate(healEnemy, spawnPoint, transform.rotation);
            }
            else if (enemyType < 70)
            {
                Instantiate(enemy, spawnPoint, transform.rotation);
                spawnPoint = GetRandomPointInCircle();
                Instantiate(enemy, spawnPoint, transform.rotation);
                spawnPoint = GetRandomPointInCircle();
                Instantiate(enemy, spawnPoint, transform.rotation);
            }
            else if (enemyType < 90)
            {
                Instantiate(bigEnemy, spawnPoint, transform.rotation);
            }
            else if (enemyType < 95)
            {
                Instantiate(healEnemy, spawnPoint, transform.rotation);
                spawnPoint = GetRandomPointInCircle();
                Instantiate(smolEnemy, spawnPoint, transform.rotation);
            }
            else if (enemyType < 100)
            {
                Instantiate(bigEnemy, spawnPoint, transform.rotation);
                spawnPoint = GetRandomPointInCircle();
                Instantiate(bigEnemy, spawnPoint, transform.rotation);
            }
            else // enemyType == 100
            {
                Instantiate(bigEnemy, spawnPoint, transform.rotation);
                spawnPoint = GetRandomPointInCircle();
                Instantiate(healEnemy, spawnPoint, transform.rotation);
                spawnPoint = GetRandomPointInCircle();
                Instantiate(smolEnemy, spawnPoint, transform.rotation);
            }
        }
    }*/
}
