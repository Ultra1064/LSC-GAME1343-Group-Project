using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public class WeaponAimAtMouse : CharacterLookAtMouse
{
    [SerializeField] UnityEvent<bool> OnFlip;
    public override void LookAtMouse(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        if (angle < 0)
            angle *= -1;
        if (angle > 90 && spriteRenderer.flipY == false)
        {
            spriteRenderer.flipY = true;
            OnFlip.Invoke(true);
        }
        if (angle < 90 && spriteRenderer.flipX == false)
        {
            spriteRenderer.flipY = false;
            OnFlip.Invoke(false);
        }
    }
}