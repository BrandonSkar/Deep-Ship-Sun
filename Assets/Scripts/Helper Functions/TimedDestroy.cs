using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null && animator.runtimeAnimatorController != null)
        {
            AnimationClip clip = animator.runtimeAnimatorController.animationClips[0]; // assumes only 1 clip
            Destroy(gameObject, clip.length);
        }
        else
        {
            Debug.LogWarning("No Animator or AnimationClip found — using fallback delay.");
            Destroy(gameObject, 0.5f);
        }
    }
}
