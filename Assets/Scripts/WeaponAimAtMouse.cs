using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public class WeaponAimAtMouse : CharacterLookAtMouse
{
    [SerializeField] UnityEvent<bool> OnFlip;
    public override void LookAtMouse(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        if (angle < 0f)
            angle *= -1;
        if (angle > 90 && !spriteRenderer.flipY)
        {
            OnFlip.Invoke(true);
            spriteRenderer.flipY = true;
        }
        else if (angle < 90 && spriteRenderer.flipY)
        {
            OnFlip.Invoke(false);
            spriteRenderer.flipY = false;
        }
    }
}