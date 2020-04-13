using System;
using System.CodeDom;
using System.Web.UI;
using System.ComponentModel;
using System.Web.Compilation;

// Apply ExpressionEditorAttributes to allow the 
// expression to appear in the designer.
[ExpressionPrefix("MyCustomExpression")]
public class MyExpressionBuilder : ExpressionBuilder
{
    public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
    {
        return new CodeSnippetExpression(entry.Expression);
    }
}