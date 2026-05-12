using UnityEngine;

public class EnemyFlash : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color originalColor;
    [SerializeField] private float flashDuration = 0.15f;

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
        while (t < flashDuration)
        {
            t += Time.deltaTime;
            float lerp = t / 0.5f;
            sr.color = Color.Lerp(originalColor, Color.black, lerp);
            yield return null;
        }
    }
}
