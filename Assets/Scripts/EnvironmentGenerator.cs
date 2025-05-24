using UnityEngine;
using UnityEngine.U2D;

[ExecuteAlways]
public class EnvironmentGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController _spriteShapeController;
    [SerializeField, Range(3, 100)] private int _levelLength = 50;
    [SerializeField, Range(1f, 50f)] private float _xMultiplier = 2f;
    [SerializeField, Range(1f, 50f)] private float _yMultiplier = 2f;
    [SerializeField, Range(0f, 1f)] private float _curveSmoothness = 0.5f;
    [SerializeField] private float _noiseStep = 0.5f;
    [SerializeField] private float _bottom = 10f;

    private void OnValidate() => GenerateTerrain();
    private void Awake() => GenerateTerrain();
    private void Start() => GenerateTerrain();

    private void GenerateTerrain()
    {
        if (_spriteShapeController == null) return;

        // Clear existing points
        _spriteShapeController.spline.Clear();

        // Generate terrain points
        for (int i = 0; i < _levelLength; i++)
        {
            // Calculate position in local space
            Vector3 localPos = new Vector3(
                i * _xMultiplier,
                Mathf.PerlinNoise(0, i * _noiseStep) * _yMultiplier,
                0
            );

            _spriteShapeController.spline.InsertPointAt(i, localPos);

            if (i > 0 && i < _levelLength - 1)
            {
                _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                _spriteShapeController.spline.SetLeftTangent(i, Vector3.left * _xMultiplier * _curveSmoothness);
                _spriteShapeController.spline.SetRightTangent(i, Vector3.right * _xMultiplier * _curveSmoothness);
            }
        }

        // Add bottom points (in local space)
        if (_levelLength > 0)
        {
            Vector3 lastPoint = _spriteShapeController.spline.GetPosition(_levelLength - 1);
            _spriteShapeController.spline.InsertPointAt(_levelLength, new Vector3(lastPoint.x, -_bottom));
            _spriteShapeController.spline.InsertPointAt(_levelLength + 1, new Vector3(0, -_bottom));
        }

        // Update collider and renderer
        _spriteShapeController.RefreshSpriteShape();
    }
}