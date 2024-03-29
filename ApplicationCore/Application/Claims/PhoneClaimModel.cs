﻿using System.IO;

namespace ApplicationCore.Application.Claims
{
  public class PhoneClaimModel
  {
    public Stream ClaimStream { get; }
    public string FileName { get; }

    public PhoneClaimModel(string fileName, Stream claimStream)
    {
      ClaimStream = claimStream;
      FileName = fileName;
    }
  }
}
