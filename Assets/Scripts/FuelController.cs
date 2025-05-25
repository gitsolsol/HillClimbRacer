using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelController : MonoBehaviour
{
    public static FuelController Instance;

    [SerializeField] private Image _fuelImage;
    [SerializeField, Range(0.1f, 5f)] private float _fuelDrainSpeed = 1f;
    [SerializeField] private float _maxFuelAmount = 100f;
    [SerializeField] private Gradient _fuelGradient;

    private float _currentFuelAmount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _currentFuelAmount = _maxFuelAmount;
        UpdateUI();
    }

    private void Update()
    {
        _currentFuelAmount -= _fuelDrainSpeed * Time.deltaTime;
        UpdateUI();

        if(_currentFuelAmount <= 0f)
        {
            GameManager.instance.GameOver();
        }
    }

    private void UpdateUI()
    {
        _fuelImage.fillAmount = _currentFuelAmount / _maxFuelAmount;
        _fuelImage .color = _fuelGradient.Evaluate(_fuelImage.fillAmount);
    }
}
