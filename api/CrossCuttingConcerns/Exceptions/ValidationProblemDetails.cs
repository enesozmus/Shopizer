﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CrossCuttingConcerns.Exceptions;

public class ValidationProblemDetails : ProblemDetails
{
    public object Errors { get; set; }

    public override string ToString() => JsonConvert.SerializeObject(this);
}