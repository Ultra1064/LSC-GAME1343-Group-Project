using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject bigEnemy;
    [SerializeField] private GameObject healEnemy;
    [SerializeField] private GameObject slowingEnemy;
    [SerializeField] private Transform center;
    private float timer = 0;
    private int enemyType; //This is a dice roll
    private int radius = 11; //Radius that's out of bounds on the X side of the screen, but WAY too far on the Y
    // Update is called once per frame
    void FixedUpdate()
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
                Instantiate(slowingEnemy, spawnPoint, transform.rotation);
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
                Instantiate(slowingEnemy, spawnPoint, transform.rotation);
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
                Instantiate(slowingEnemy, spawnPoint, transform.rotation);
            }
        }
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
        return center.position + new Vector3(random.x, 0f, random.y);
    }
}
