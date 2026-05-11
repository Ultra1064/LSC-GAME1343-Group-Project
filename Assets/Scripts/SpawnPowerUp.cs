using System;
using UnityEngine;

public enum PowerUpType
{
    IncreaseFireRate,
    Shotgun,
    IncreaseHealth,
    Laser
}
public class SpawnPowerUp : MonoBehaviour
{
    [SerializeField] GameObject fireRatePowerUp;
    //[SerializeField] GameObject healthPowerUp;
    [SerializeField] GameObject shotgunPowerUp;
    [SerializeField] GameObject laserPowerUp;
    [SerializeField] int spawnRate = 10;

    private PowerUpType type;
    private void Start()
    {
        type = (PowerUpType)UnityEngine.Random.Range(0,4);
    }
    public void OnDestroy()
    {
        int rand = UnityEngine.Random.Range(1, spawnRate + 1);
        if (rand == spawnRate && this.gameObject.scene.isLoaded)
        {
            switch (type)
            {
                case PowerUpType.IncreaseFireRate:
                    Instantiate(fireRatePowerUp, transform.position, transform.rotation);
                    break;
                case PowerUpType.Shotgun:
                    Instantiate(shotgunPowerUp, transform.position, transform.rotation);
                    break;
                case PowerUpType.IncreaseHealth:
                    //Instantiate(healthPowerUp, transform.position, Quaternion.identity);
                    break;
                case PowerUpType.Laser:
                    Instantiate(laserPowerUp, transform.position, transform.rotation);
                    break;
            }
        }
    }
}
