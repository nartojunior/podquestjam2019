using UnityEngine;
using System.Collections;

public class SlideFloor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var playerMovementTemp = other.gameObject.GetComponent<PlayerMovement>();

        if (playerMovementTemp == null)
            return;

        playerMovementTemp.Slide();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        var playerMovementTemp = other.gameObject.GetComponent<PlayerMovement>();

        if (playerMovementTemp == null)
            return;

        playerMovementTemp.InSlide = false;
    }
}
