using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D PlayerRigidBody;
    private float playerWalk;
    public float playerSpeed, playerSpeedBase, playerSpeedAdd, jumpForce;
    public Transform groundCheck;
    private bool grounded, walk, lookRight;
    public LayerMask whatIsGround;
    private Animator playerAnimator;

	void Start () {
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSpeed = playerSpeedBase;
	}

	void Update () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f, whatIsGround);

        playerWalk = Input.GetAxis("Walk");

        if (playerWalk != 0) { walk = true; } else { walk = false; }

        if (playerWalk > 0 && lookRight == true) { Flip(); }
        else if (playerWalk < 0 && lookRight == false) { Flip(); }

        if (Input.GetButtonDown("Run")) {
            playerSpeed = playerSpeedBase + playerSpeedAdd;
        }
        if (Input.GetButtonUp("Run")) {
            playerSpeed = playerSpeedBase;
        }

        if (Input.GetButtonDown("Jump") && grounded == true) {
            PlayerRigidBody.AddForce(new Vector2(0, jumpForce));
        }
        playerAnimator.SetBool("playerWalkAnim", walk);
    }

    void FixedUpdate() {
        PlayerRigidBody.velocity = new Vector2(playerWalk * playerSpeed, PlayerRigidBody.velocity.y);
    }
    void Flip() {
        lookRight = !lookRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}