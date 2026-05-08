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
    [SerializeField] GameObject healthPowerUp;
    [SerializeField] GameObject shotgunPowerUp;
    [SerializeField] GameObject laserPowerUp;
    [SerializeField] int spawnRate = 10;

    private PowerUpType type;
    private void Start()
    {
        type = (PowerUpType)UnityEngine.Random.Range(0,4);
        Debug.Log(type);
    }
    private void OnDestroy()
    {
        if ((UnityEngine.Random.Range(1, 11) % spawnRate) == 0)
        {
            switch (type)
            {
                case PowerUpType.IncreaseFireRate:
                    // Instantiate fireRatePowerUp
                    break;
                case PowerUpType.Shotgun:
                    // Instantiate shotgunPowerUp
                    break;
                case PowerUpType.IncreaseHealth:
                    // Instantiate healthPowerUp
                    break;
                case PowerUpType.Laser:
                    // Instantiate laserPowerUp
                    break;
            }
        }
    }
}
