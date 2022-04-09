using UnityEngine;
using UnityEngine.Animations;

public class AnimationController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] PlayerController playerController;

    [Header("Specifications")]
    private string currentState;
    private string previousState;

    public void ChangeAnimationState(string newState)
    {
        //Stop the same animation from interrupting itself.
        if (currentState == newState) return;

        //Play the animation.
        playerController.anim.Play(newState);

        //reassign the current state.
        currentState = newState;
    }

    public string PlayPreviousState(string newState)
    {
        //Stop caching the same animation .
        if (currentState == previousState) return null;

        //set the previous state to the current state.
        previousState = currentState;
        currentState = newState;

        return previousState;
    }

    public void FallingAnimation()
    {
        if (playerController.playerSpaceDetection.isFallingDown())
        {
            ChangeAnimationState(currentState);
        }
    }

    public bool AnimatiorIsPlaying()
    {
        return playerController.anim.GetCurrentAnimatorStateInfo(0).length > playerController.anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    public bool AnimationIsPlaying(string stateName)
    {
        return AnimatiorIsPlaying() && playerController.anim.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
}
