using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace NullRefereceExceptionAtGetSymbolInfoAnalyzer;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class Analyzer : DiagnosticAnalyzer
{
    internal static DiagnosticDescriptor s_diagnosticDescriptor_XX0001 = new DiagnosticDescriptor(
        "XX0001",
        "Xx",
        "Xx。",
        "Usage",
        DiagnosticSeverity.Warning,
        isEnabledByDefault: true);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(
        s_diagnosticDescriptor_XX0001
        );

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
        context.EnableConcurrentExecution();
        context.RegisterSyntaxNodeAction(DetectDiscardOfCollectionOperationResult, SyntaxKind.SimpleMemberAccessExpression);
    }

    private static void DetectDiscardOfCollectionOperationResult(SyntaxNodeAnalysisContext context)
    {
        if (context.Node is not MemberAccessExpressionSyntax memberAccessExpressionSyntax)
        {
            return;
        }

        // NullReferenceException!!
        context.SemanticModel.GetSymbolInfo(memberAccessExpressionSyntax, context.CancellationToken);
    }
}
