﻿using ErrorOr;

namespace RecursosHumanos.Api.DTO.Errors;

public static class GeneralErrors
{
    public static readonly string CodePrefix = "General.";
    public static readonly Error NotFound = Error.NotFound(
        code: CodePrefix + "NotFound",
        description: "Not found");
}
