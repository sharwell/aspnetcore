﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Core;
using static Microsoft.AspNetCore.Mvc.Infrastructure.ProblemDetailsJsonConverter;

namespace Microsoft.AspNetCore.Mvc.Infrastructure
{
    internal class ValidationProblemDetailsJsonConverter : JsonConverter<ValidationProblemDetails>
    {
        private static readonly JsonEncodedText Errors = JsonEncodedText.Encode("errors");

        public override ValidationProblemDetails Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var problemDetails = new ValidationProblemDetails();

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException(Resources.UnexpectedJsonEnd);
            }

            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                if (reader.ValueTextEquals(Errors.EncodedUtf8Bytes))
                {
                    var errors = JsonSerializer.Deserialize<Dictionary<string, string[]>>(ref reader, options);
                    foreach (var item in errors)
                    {
                        problemDetails.Errors[item.Key] = item.Value;
                    }
                }
                else
                {
                    ReadValue(ref reader, problemDetails, options);
                }
            }

            if (reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException(Resources.UnexpectedJsonEnd);
            }

            return problemDetails;
        }

        public override void Write(Utf8JsonWriter writer, ValidationProblemDetails value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            WriteProblemDetails(writer, value, options);

            writer.WriteStartObject(Errors);
            foreach (var kvp in value.Errors)
            {
                writer.WritePropertyName(kvp.Key);
                JsonSerializer.Serialize(writer, kvp.Value, kvp.Value?.GetType() ?? typeof(object), options);
            }
            writer.WriteEndObject();

            writer.WriteEndObject();
        }
    }
}
