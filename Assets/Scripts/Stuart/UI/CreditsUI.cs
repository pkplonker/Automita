using System.Collections;
using System.Collections.Generic;
using StuartH;
using UnityEngine;


public class CreditsUI : CanvasGroupBase
{
    private void Awake() => Hide();
    public void Show() => ShowUI();
    public void Hide() => HideUI();

}
