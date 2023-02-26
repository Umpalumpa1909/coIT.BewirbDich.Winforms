﻿// Import Swashbuckle.AspNetCore.SwaggerGen

using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class EnumerationToEnumSchemaFilter : ISchemaFilter
{
    private const string NAME = "x-enumNames";

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var typeInfo = context.Type;
        // Chances are something in the pipeline might generate this automatically at some point in the future
        // therefore it's best to check if it exists.
        if (typeInfo.IsEnum && !schema.Extensions.ContainsKey(NAME))
        {
            var names = Enum.GetNames(context.Type);
            var arr = new OpenApiArray();
            arr.AddRange(names.Select(name => new OpenApiString(name)));
            schema.Extensions.Add(NAME, arr);
        }
    }
}