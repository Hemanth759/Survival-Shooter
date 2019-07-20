using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  // public variables
  public float speed = 6f;

  // private varialbles
  private Vector3 movement;
  private Animator animator;
  private Rigidbody playerRigidbody;
  private int floorMask;
  private float camRayLength = 100f;
  private Camera cam;

  /// <summary>
  /// Awake is called when the script instance is being loaded.
  /// </summary>
  void Awake() {
    floorMask = LayerMask.GetMask ("Floor");
    animator = this.GetComponent<Animator> ();
    playerRigidbody = this.GetComponent<Rigidbody> ();
    cam = Camera.main;
  }

  /// <summary>
  /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
  /// </summary>
  void FixedUpdate()
  {
    float h = Input.GetAxisRaw("Horizontal");
    float v = Input.GetAxisRaw("Vertical");

    // funtion to turn the player
    turning();
    // function to animate the player from idle to moving
    animating(h, v);

    if(h != 0f || v != 0f) {
      // function to move the player object
      move(h, v);
    }
  }

  void move(float horizontal, float vertical) {
    movement.Set(horizontal, 0f, vertical);

    movement = movement.normalized * speed * Time.deltaTime;

    playerRigidbody.MovePosition(transform.position + movement);
  }

  void turning() {
    Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
    RaycastHit floorHit;

    if(Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
      Vector3 mouseToPlayer = floorHit.point - transform.position;
      mouseToPlayer.y = 0f;

      Quaternion newRotation = Quaternion.LookRotation(mouseToPlayer);
      playerRigidbody.MoveRotation(newRotation);
    }
  }

  void animating(float horizontal, float vertical) {
    bool walking = horizontal != 0f || vertical != 0f;
    animator.SetBool("IsWalking", walking);
  }
}
