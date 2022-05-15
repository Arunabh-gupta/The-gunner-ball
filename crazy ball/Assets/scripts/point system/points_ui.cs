using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class points_ui : MonoBehaviour
{
    [SerializeField] TMP_Text points;
    private void Update() {
        points.text = point_system.instance.point_count.ToString();
    }
}
