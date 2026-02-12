using UnityEngine;

public class CameraOptions : MonoBehaviour
{
    [Header("Camera")]
    public float horizontalRotateSpeed;
    public float verticalRotateSpeed;
    public bool invertHorizontalRotate = false, invertVerticalRotate = false;

    [Header("Aim Camera")]
    public float aimHorizontalRotateSpeed;
    public float aimVerticalRotateSpeed;
    public bool aimAssist;

    [Header("Combat Camera")]
    public bool recenterCamOnAttack;
    public bool strafeAssist;

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - Sensitivity
    public void SetXSensvalue(float Xsens)
    {
        horizontalRotateSpeed = Xsens;
        PlayerPrefs.SetFloat("XSens", Xsens);
    }
    public void SetYSensvalue(float Ysens)
    {
        verticalRotateSpeed = Ysens;
        PlayerPrefs.SetFloat("YSens", Ysens);
    }
    public void SetAimXSensvalue(float Xsens)
    {
        aimHorizontalRotateSpeed = Xsens;
        PlayerPrefs.SetFloat("AimXSens", Xsens);
    }
    public void SetAimYSensvalue(float Ysens)
    {
        aimVerticalRotateSpeed = Ysens;
        PlayerPrefs.SetFloat("AimYSens", Ysens);
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - Inverting

    public void InvertHorizontal()
    {
        if (invertHorizontalRotate)
        {
            invertHorizontalRotate = false;
        }
        else
        {
            invertHorizontalRotate = true;
        }
    }
    public void InvertVertical()
    {
        if (invertVerticalRotate)
        {
            invertVerticalRotate = false;
        }
        else
        {
            invertVerticalRotate = true;
        }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - Bool's

    public void AimAssist()
    {
        if (aimAssist)
        {
            aimAssist = false;
        }
        else
        {
            aimAssist = true;
        }
    }
    public void RecenterCameraOnAttack()
    {
        if (recenterCamOnAttack)
        {
            recenterCamOnAttack = false;
        }
        else
        {
            recenterCamOnAttack = true;
        }
    }
    public void StrafeAssist()
    {

        if (strafeAssist)
        {
            strafeAssist = false;
        }
        else
        {
            strafeAssist = true;
        }
    }
}
