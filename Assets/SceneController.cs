using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Camera socialDeductionCam;
    public Camera gatePuzzleCam;
    public Slider timeSlider;

    private void Start()
    {
        socialDeductionCam.enabled = true;
        gatePuzzleCam.enabled = false;
    }

    public void SwitchProject()
    {
        if (socialDeductionCam.enabled)
        {
            socialDeductionCam.enabled = false;
            gatePuzzleCam.enabled = true;
        }
        else
        {
            socialDeductionCam.enabled = true;
            gatePuzzleCam.enabled = false;
        }
        Time.timeScale = 1;
        timeSlider.value = 1;
    }
}
