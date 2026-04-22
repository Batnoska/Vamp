using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadState : IPlayerState
{
    private PlayerStateMachine player;
    private float timer;

    public bool CanBeInterrupted => false;
    public void Enter(PlayerStateMachine player)
    {
        this.player = player;

        timer = 1.5f;

        player.movement.StopMovement();

        player.weaponController.enabled = false;


        player.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Update()
    {
        Debug.Log("DeadState Running");
        
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    
    public void Exit() {}
}
