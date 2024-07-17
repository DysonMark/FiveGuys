
using UnityEngine;

public class GraphicsManager : MonoBehaviour
{
    public void VeryLowGraphicsSettings()
    {
        QualitySettings.SetQualityLevel(0);
    }
    public void LowGraphicsSettings()
    {
        QualitySettings.SetQualityLevel(1);
    }
    public void MediumGraphicsSettings()
    {
        QualitySettings.SetQualityLevel(2);
    }
    public void HighGraphicsSettings()
    {
        QualitySettings.SetQualityLevel(3);
    }
    public void VeryHighGraphicsSettings()
    {
        QualitySettings.SetQualityLevel(4);
    }
    public void UltraGraphicsSettings()
    {
        QualitySettings.SetQualityLevel(5);
    }
}
