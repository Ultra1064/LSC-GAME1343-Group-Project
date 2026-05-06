using UnityEngine;
using UnityEngine.TextCore.Text;

public class WeaponAimAtMouse : CharacterLookAtMouse
{
    public override void LookAtMouse(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        if (angle > 90 || angle < -90)
            spriteRenderer.flipY = true;
        else
            spriteRenderer.flipY = false;
    }
}
