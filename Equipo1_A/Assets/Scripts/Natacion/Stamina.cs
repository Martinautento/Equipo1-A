using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaDrainRate = 10f;
    public float staminaRechargeRate = 5f;
    public Slider staminaBar;

    private void Start()
    {
        // Inicializa la stamina al máximo
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = currentStamina;
    }

    private void Update()
    {
        // Actualizar la barra de stamina
        staminaBar.value = currentStamina;
    }

    // Método para reducir la stamina
    public void DrainStamina(float amount)
    {
        currentStamina -= amount;
        if (currentStamina < 0) currentStamina = 0;
    }

    // Método para recargar la stamina
    public void RechargeStamina()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRechargeRate * Time.deltaTime;
            if (currentStamina > maxStamina) currentStamina = maxStamina;
        }
    }
}
