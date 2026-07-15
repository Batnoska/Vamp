using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayRoll()
    {
        animator.SetTrigger("Roll");
    }

    public void PlayHurt()
    {
        animator.SetTrigger("Hurt");
    }

    public void PlayDeath()
    {
        animator.SetTrigger("Death");
    }

    public void PlayAttack()
    {
        animator.SetTrigger("Attack3");
    }

    public void SetMoving(bool moving)
    {
        animator.SetInteger(
            "AnimState",
            moving ? 1 : 0
        );
    }
}
