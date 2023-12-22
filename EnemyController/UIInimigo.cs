using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIInimigo : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    
    public int vidaMaxima{
        set{
            this.slider.maxValue = value; 
        }
    }
    public int vida{
        set{
            this.slider.value = value;
        }
    }
}
