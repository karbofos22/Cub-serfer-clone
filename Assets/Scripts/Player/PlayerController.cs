using UnityEngine;
using static GameStateController;

public class PlayerController : MonoBehaviour
{
    #region Fields
    private MovementController playerMovement;
    private BodyController playerBody;

    [SerializeField] private Animator animator;
    #endregion

    void Start()
    {
        playerBody = GetComponent<BodyController>();
        playerMovement = GetComponent<MovementController>();

        EventManager.OnGameStateChanged.AddListener(OnGameStateChanged);
    }
    void Update()
    {
        if (playerBody.isDead)
        {
            animator.SetBool("isDead", true);
            EventManager.SendPlayerDead();
        }
    }
    private void OnGameStateChanged(GameState state)
    {
        playerMovement.enabled = (state == GameState.GameActive);
        playerBody.enabled = (state == GameState.GameActive);
    }
}
