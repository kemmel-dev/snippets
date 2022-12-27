using UnityEngine;
using UnityEngine.Events;

/*
 * By Kamiel de Visser, from https://github.com/kemmel-dev/snippets
 * Read the license before using or modifying.
 */

/// <summary>
/// Attach to an object to make it destroy objects attached to triggers.
/// Assumes the physics matrix is set up so that the objects that are to be destroyed 
/// can only interact with the physics layer of the rigidbody that this script is attached to.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class DestroyTriggerableOnTouch : MonoBehaviour
{ 
    [SerializeField]
    private UnityEvent _onDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.transform.parent.gameObject);
        _onDestroy?.Invoke();
    }
}
