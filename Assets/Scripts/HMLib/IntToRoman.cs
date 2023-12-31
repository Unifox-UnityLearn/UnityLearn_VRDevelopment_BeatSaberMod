﻿// Decompiled with JetBrains decompiler
// Type: IntToRoman
// Assembly: HMLib, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8CC76D59-1DD6-42EE-8DB5-092A3F1E1FFA
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\HMLib.dll

using System;

public static class IntToRoman
{
  public static string Roman(this int number)
  {
    if (number < 0 || number > 3999)
      throw new ArgumentOutOfRangeException("Number cannot be converted to Roman representation. Use number between 1 and 3999.");
    if (number < 1)
      return string.Empty;
    if (number >= 1000)
      return "M" + (number - 1000).Roman();
    if (number >= 900)
      return "CM" + (number - 900).Roman();
    if (number >= 500)
      return "D" + (number - 500).Roman();
    if (number >= 400)
      return "CD" + (number - 400).Roman();
    if (number >= 100)
      return "C" + (number - 100).Roman();
    if (number >= 90)
      return "XC" + (number - 90).Roman();
    if (number >= 50)
      return "L" + (number - 50).Roman();
    if (number >= 40)
      return "XL" + (number - 40).Roman();
    if (number >= 10)
      return "X" + (number - 10).Roman();
    if (number >= 9)
      return "IX" + (number - 9).Roman();
    if (number >= 5)
      return "V" + (number - 5).Roman();
    if (number >= 4)
      return "IV" + (number - 4).Roman();
    return number >= 1 ? "I" + (number - 1).Roman() : "";
  }
}
