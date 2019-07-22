using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  // public variables
  public float speed = 6f;

  public Joystick movementJoystick;

  public Joystick aimJoystick;

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
    float h = movementJoystick.Horizontal != 0f ? movementJoystick.Horizontal > 0 ? 1 : -1 : 0;
    float v = movementJoystick.Vertical  != 0f ? movementJoystick.Vertical > 0 ? 1 : -1 : 0;

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
    Vector3 newdirection = new Vector3(aimJoystick.Direction.x, 0f, aimJoystick.Direction.y);
    newdirection = newdirection.normalized;
    if(newdirection.magnitude == 0)
      return;
    Quaternion newRotation = Quaternion.LookRotation(newdirection);
    playerRigidbody.MoveRotation(newRotation);
  }

  void animating(float horizontal, float vertical) {
    bool walking = horizontal != 0f || vertical != 0f;
    animator.SetBool("IsWalking", walking);
  }
}
