using UnityEngine;

/*
 * By Kamiel de Visser, from https://github.com/kemmel-dev/snippets
 * Read the license before using or modifying.
 */

public class FlipSpriteWhenPointingDown : MonoBehaviour
{
    private void Update()
    {
        float signedAngle = Vector2.SignedAngle(Vector2.up, transform.up);
        bool transformUpIsPointingUp = signedAngle > -90 && signedAngle < 90;
        transform.localScale = new Vector3(
            transform.localScale.x,
            transformUpIsPointingUp ? 1 : -1,
            transform.localScale.z);
    }
}
