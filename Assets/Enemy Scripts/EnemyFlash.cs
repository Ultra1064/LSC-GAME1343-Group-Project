using UnityEngine;

public class EnemyFlash : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color originalColor;
    [SerializeField] private float flashDuration = 0.15f;
    [SerializeField] public float deathDuration = 0.25f; //This decides how long the death animation lasts for an enemy.
    //Make coroutines into one singular function that takes other colors.
    void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>(); //This grabs the Sprite Renderer on the 2D object.
        originalColor = sr.material.color; //This saves the original color of the sprite
    }

    public void FlashRed()
    {
        StopAllCoroutines();
        StartCoroutine(Flash(Color.red, flashDuration));
    }

    public void FadeBlack()
    {
        StopAllCoroutines();
        StartCoroutine(Death());
    }

    public void FlashGreen()
    {
        StopAllCoroutines();
        StartCoroutine(Flash(Color.green, flashDuration));
    }

    private System.Collections.IEnumerator Flash(Color color, float duration) //All IEnum is for, is for coroutines
    {
        float timer = 0f;

        // Fade TO the second color from the first.
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float lerp = timer / duration;
            sr.color = Color.Lerp(originalColor, color, lerp);
            yield return null;
        }

        timer = 0f;

        // Fade BACK to original color.
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float lerp = timer / duration;
            sr.color = Color.Lerp(color, originalColor, lerp);
            yield return null;
        }

        sr.color = originalColor;
    }

    private System.Collections.IEnumerator Death() //All IEnum is for, is for coroutines
    {
        float timer = 0f;

        // Fade TO black
        while (timer < (deathDuration / 2)) //In the first half of the death duration, the enemy fades to black.
        {
            timer += Time.deltaTime;
            float lerp = timer / (deathDuration / 2);
            sr.color = Color.Lerp(originalColor, Color.black, lerp);
            yield return null;
        }
        //Fade to clear
        while (timer < deathDuration) //In the second half of the death duration, the enemy disappears.
        {
            timer += Time.deltaTime;
            float lerp = timer / (deathDuration / 2);
            sr.color = Color.Lerp(Color.black, Color.clear, lerp);
            yield return null;
        }
        sr.color = Color.clear; //Completely invisible
    }
}
