﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class ValidationProblemsDetails : ProblemDetails
    {
        public object Errors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
