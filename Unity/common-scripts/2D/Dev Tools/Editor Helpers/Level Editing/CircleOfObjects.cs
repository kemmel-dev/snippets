using UnityEditor;
using UnityEngine;

/*
 * By Kamiel de Visser, from https://github.com/kemmel-dev/snippets
 * Read the license before using or modifying.
 */

/// <summary>
/// Attach to an object to quickly make a circle of objects.
/// </summary>
public class CircleOfObjects : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The sprite renderer used to draw the radius.")]
    private SpriteRenderer _radiusRenderer;
    [SerializeField]
    [Tooltip("The object to spawn along the circle.")]
    private GameObject _objectPrefab;
    [SerializeField]
    [Tooltip("The number of objects to spawn along the circle.")]
    private int _nObjects;
    [SerializeField]
    [Tooltip("The radius of the circle.")]
    private float _radius;
    [SerializeField]
    [Tooltip("The root transform around which the objects will spawn.")]
    private Transform _objectRoot;
    [Tooltip("The amount of offset (in degrees) from the starting position")]
    [SerializeField]
    private float _offsetByDegrees;
    
    internal void Generate()
    {
        // Destroy old objects
        foreach (Transform child in _objectRoot)
        {
            UnityEditor.EditorApplication.delayCall += () =>
            {
                DestroyImmediate(child.gameObject);
            };
        }

        // Calculate step per object
        float angleStep = 360 / _nObjects;

        if (_objectPrefab != null)
        {
            // Instantiate objects
            for (int i = 0; i < _nObjects; i++)
            {
                float currentAngle = (_offsetByDegrees + angleStep * i) * Mathf.Deg2Rad;
                Vector2 heading = new Vector2(Mathf.Cos(currentAngle), Mathf.Sin(currentAngle));
                GameObject go = (GameObject)PrefabUtility.InstantiatePrefab(_objectPrefab);
                go.transform.parent = _objectRoot;
                go.transform.position = _objectRoot.transform.position + (Vector3)(heading.normalized * _radius);
            }
        }
        // Reflect circle radius
        _radiusRenderer.transform.localScale = _radius * 2 * Vector3.one;
    }
}

[CustomEditor(typeof(CircleOfObjects))]
class CircleOfObjectsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Call Generate when value changed
        EditorGUI.BeginChangeCheck();
        base.OnInspectorGUI();
        if (EditorGUI.EndChangeCheck())
        {
            var circleOfObjects = (CircleOfObjects) target;
            circleOfObjects.Generate();
        }
    }
}
