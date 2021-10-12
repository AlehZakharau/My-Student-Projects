using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroid
{
    public class VideoController : MonoBehaviour
    {
        public TMP_Dropdown dropdown;

        // Start is called before the first frame update
        void Start()
        {
            dropdown.onValueChanged.AddListener(delegate { SetResolution(dropdown.captionText); });
        }

        private void SetResolution(TMP_Text arg0)
        {
            var resolution = new string[2];
            resolution = arg0.text.Split('x');
            var width = int.Parse(resolution[0]);
            var height = int.Parse(resolution[1]);
            Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
            Debug.Log(arg0.text);
            Debug.Log($"Test {width} {height}");
            Debug.Log($"Resolution: {Screen.width} x {Screen.height}");
        }
    }
}