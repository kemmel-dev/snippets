using UnityEngine;

/*
 * By Kamiel de Visser, from https://github.com/kemmel-dev/snippets
 * Read the license before using or modifying.
 */

public class FreezeRotation : MonoBehaviour
{

    private Quaternion _initRotation;

    private void Start()
    {
        _initRotation = transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = _initRotation;
    }
}
