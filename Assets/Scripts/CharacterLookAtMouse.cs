using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;

public class CharacterLookAtMouse : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    protected Camera cam;
    private Vector2 mousePos;
    protected void Start()
    {
        cam = Camera.main;
    }
    protected void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad; // Offset this by 90 degrees
        LookAtMouse(angleDeg);
    }
    virtual public void LookAtMouse(float angle)
    {
        if (angle > 90 || angle < -90)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }
    public Vector2 GetMousePosition()
    {
        return mousePos;
    }
}