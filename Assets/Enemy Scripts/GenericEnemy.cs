using UnityEngine;

public class GenericEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private Vector2 target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime); //Vector2.down needs to be switched with the location of the payload
    }

    /*void Knockback()
    {
        Need a way to apply knockback when taking collision from a weapon. Also need 2Dcollision as player has a rigidbody.
    }

    void calculateSpeed()
    {
        Need a way to calculate speed based on speed of payload/camera. Enemies from the front might reach the payload too quickly, while as enemies from the back
        may not catch up.

        To calculate this, I will need the speed of the payload, and add it's speed to the speed of enemies behind it to simulate as if they're moving normally.
        For example, if the payload has a speed of 5, an enemy chasing it needs a speed of 6 to look as if it has a speed of 1. An enemy in FRONT of the payload,
        needs a speed of 4 in the OPPOSITE direction to look as if it has a speed of 1 moving towards the payload. If it's adjacent to the payload, it needs to match
        the horizontal speed of the payload, while the regular speed of moving towards it is fine. I might need an xSpeed and ySpeed to accomplish this illusion.

        I do need an xSpeed and ySpeed. I need an angle between two vectors formula for the vector the payload is travelling on, and the vector of the distance
        from the payload to the enemy. Once the angle is calculated, I made a graphic for how the speed will be calculated based on the angle and the speed of the
        payload. Use Vector2.Angle(payloadVector, enemyVector);
    }

    enum states()
    {
        Need a state for being alive and for being dead. Starts as alive, dies when health is zero or other circumstance.
    }

    */
}
