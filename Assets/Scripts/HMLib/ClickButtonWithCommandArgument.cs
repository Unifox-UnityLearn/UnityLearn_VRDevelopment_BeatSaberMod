﻿// Decompiled with JetBrains decompiler
// Type: ClickButtonWithCommandArgument
// Assembly: HMLib, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8CC76D59-1DD6-42EE-8DB5-092A3F1E1FFA
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\HMLib.dll

using System;
using System.Collections;
using UnityEngine;

public class ClickButtonWithCommandArgument : MonoBehaviour
{
  [SerializeField]
  protected string _argument;
  [SerializeField]
  protected UnityEngine.UI.Button _button;

  public virtual IEnumerator Start()
  {
    yield return (object) null;
    foreach (string commandLineArg in Environment.GetCommandLineArgs())
    {
      if (commandLineArg == this._argument)
        this._button.onClick.Invoke();
    }
  }
}
