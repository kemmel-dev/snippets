using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * By Kamiel de Visser, from https://github.com/kemmel-dev/snippets
 * Read the license before using or modifying.
 */

public class DevFreezeTime : MonoBehaviour
{

    [SerializeField]
    private KeyCode _keyCode;
    private bool _freeze = false;
    private float _initTimeScale;

    private void Start()
    {
       _initTimeScale = Time.timeScale;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_keyCode))
        {
            _freeze = !_freeze;
            Time.timeScale = _freeze ? 0f : _initTimeScale;
        }
    }
}
