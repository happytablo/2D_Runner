using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    [SerializeField] private float _swithDuration = 10f;
    [SerializeField] private float _slowDuration = 5f;
    [SerializeField] private TMP_Text _textWarning;

    private bool _isFastSpeed = false;

    private void Start()
    {
        _textWarning.alpha = 0;
        StartCoroutine(ChangeSpeed());
    }

    private IEnumerator ChangeSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(_slowDuration);
            _isFastSpeed = !_isFastSpeed;

            _textWarning.alpha = 1;
            yield return new WaitForSeconds(5f);
            _textWarning.alpha = 0;

            float currentDuration = _isFastSpeed? (_swithDuration - _slowDuration) : _slowDuration;
            yield return new WaitForSeconds(currentDuration);

            _isFastSpeed = !_isFastSpeed;
        }
    }

    public float GetCurrentSpeed(float slowSpeed, float fastSpeed)
    {
        return _isFastSpeed ? fastSpeed : slowSpeed;
    }
}
