using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Warning : MonoBehaviour
{
    private TMP_Text _text;

    private IEnumerator AnimateText()
    {
        for (int i = 0; i < 20; i++)
        {
            _text.alpha = 1f - (1f / 255 * i);
            yield return null;
        }
    }
}
