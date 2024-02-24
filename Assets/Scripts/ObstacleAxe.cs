using UnityEngine;
using DG.Tweening;

public class ObstacleAxe : MonoBehaviour
{
    [SerializeField] float swingAngle = 45f; // Half of the desired total swing angle (since it's a yoyo loop)
    [SerializeField] float swingDuration = 1f;

    void Start()
    {
        // Swing the axe back and forth continuously
        transform.DOLocalRotate(new Vector3(0, 0, swingAngle), swingDuration / 2f)
            .SetRelative()
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo); //yoyo
    }
}