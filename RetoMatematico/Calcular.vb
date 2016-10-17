Public Class Calcular

    Dim Random As New Random()
    Dim Num1, Num2 As Integer
    Dim Signo As Char
    Dim signos = New Char() {"+", "-", "*", "/"}

    Public Function Calculo(ByVal Num1 As Integer, Signo As Char, ByVal Num2 As Integer, ByRef Resultado As Integer, ByRef Residuo As Long) As Integer
        If Signo = "+" Then
            Resultado = Num1 + Num2
        ElseIf Signo = "-" Then
            Resultado = Num1 - Num2
        ElseIf Signo = "*" Then
            Resultado = Num1 * Num2
        ElseIf Signo = "/" Then
            If Num2 <> 0 Then
                Resultado = Num1 / Num2
                Residuo = Num1 Mod Num2
            End If
        End If
        Return Resultado
    End Function

    Public Function Verifica(ByVal Num1 As Integer, Signo As Char, ByVal Num2 As Integer) As Integer
        Dim resp As Integer

        If Signo = "+" Then
            resp = Num1 + Num2
        ElseIf Signo = "-" Then
            resp = Num1 - Num2
        ElseIf Signo = "*" Then
            resp = Num1 * Num2
        ElseIf Signo = "/" Then
            If Num2 <> 0 Then
                resp = Num1 / Num2
            End If
        End If
        Return resp

    End Function
End Class
