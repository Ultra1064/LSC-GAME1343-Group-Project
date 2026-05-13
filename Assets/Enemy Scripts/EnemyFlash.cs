using UnityEngine;

public class EnemyFlash : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color originalColor;
    [SerializeField] private float flashDuration = 0.15f;
    [SerializeField] public float deathDuration = 0.25f; //This decides how long the death animation lasts for an enemy.

    void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>(); //This grabs the Sprite Renderer on the 2D object.
        originalColor = sr.material.color; //This saves the original color of the sprite
    }

    public void FlashRed()
    {
        StopAllCoroutines();
        StartCoroutine(Red());
    }

    public void FadeBlack()
    {
        StopAllCoroutines();
        StartCoroutine(Black());
    }

    public void FlashGreen()
    {
        StopAllCoroutines();
        StartCoroutine(Green());
    }


    private System.Collections.IEnumerator Red() //All IEnum is for, is for coroutines
    {
        float t = 0f;

        // Fade TO red
        while (t < flashDuration)
        {
            t += Time.deltaTime;
            float lerp = t / flashDuration;
            sr.color = Color.Lerp(originalColor, Color.red, lerp);
            yield return null;
        }

        t = 0f;

        // Fade BACK to original
        while (t < flashDuration)
        {
            t += Time.deltaTime;
            float lerp = t / flashDuration;
            sr.color = Color.Lerp(Color.red, originalColor, lerp);
            yield return null;
        }

        sr.color = originalColor;
    }

    private System.Collections.IEnumerator Black() //All IEnum is for, is for coroutines
    {
        float t = 0f;

        // Fade TO black
        while (t < (deathDuration / 2)) //In the first half of the death duration, the enemy fades to black.
        {
            t += Time.deltaTime;
            float lerp = t / (deathDuration / 2);
            sr.color = Color.Lerp(originalColor, Color.black, lerp);
            yield return null;
        }
        //Fade to clear
        while (t < deathDuration) //In the second half of the death duration, the enemy disappears.
        {
            t += Time.deltaTime;
            float lerp = t / (deathDuration / 2);
            sr.color = Color.Lerp(Color.black, Color.clear, lerp);
            yield return null;
        }
        sr.color = Color.clear; //Completely invisible
    }

    private System.Collections.IEnumerator Green() //All IEnum is for, is for coroutines
    {
        float t = 0f;

        // Fade TO green
        while (t < flashDuration)
        {
            t += Time.deltaTime;
            float lerp = t / flashDuration;
            sr.color = Color.Lerp(originalColor, Color.green, lerp);
            yield return null;
        }

        t = 0f;

        // Fade BACK to original
        while (t < flashDuration)
        {
            t += Time.deltaTime;
            float lerp = t / flashDuration;
            sr.color = Color.Lerp(Color.green, originalColor, lerp);
            yield return null;
        }

        sr.color = originalColor;
    }
}
