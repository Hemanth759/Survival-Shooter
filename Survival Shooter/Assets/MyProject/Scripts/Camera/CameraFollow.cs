using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
  // public variables
  public Transform target;
  public float smoothing = 5f;

  Vector3 offset;

  /// <summary>
  /// Start is called on the frame when a script is enabled just before
  /// any of the Update methods is called the first time.
  /// </summary>
  private void Start()
  {
    offset = this.transform.position - target.position;
  }

  /// <summary>
  /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
  /// </summary>
  private void FixedUpdate()
  {
    Vector3 targetPos = target.position + offset;
    this.transform.position = Vector3.Lerp(this.transform.position, targetPos, smoothing * Time.deltaTime);
  }
}
