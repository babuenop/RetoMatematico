Public Class Form1
    Dim vNum(7) As TextBox
    Dim vSol(7) As TextBox
    Dim vBtnNum(4) As Button
    Dim vBtnOpe(4) As Button
    Dim Calcular As Calcular = New Calcular()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vSol(0) = T_Sol1
        vSol(1) = T_Sol2
        vSol(2) = T_Sol3
        vSol(3) = T_Sol4
        vSol(4) = T_Sol5
        vSol(5) = T_Sol6
        vSol(6) = T_Sol7

        vNum(0) = txt_num1
        vNum(1) = txt_num2
        vNum(2) = txt_num3
        vNum(3) = txt_num4
        vNum(4) = txt_num5
        vNum(5) = txt_num6
        vNum(6) = txt_num7

        vBtnNum = New Button() {btn_num1, btn_num2, btn_num3, btn_num4}
        vBtnOpe = New Button() {btn_ope1, btn_ope2, btn_ope3, btn_ope4}

    End Sub

    Private Sub btn_Iniciar_Click(sender As Object, e As EventArgs) Handles btn_Iniciar.Click
        GenerarNumeros()
        Operacion()
    End Sub
    'Genera Numeros para Botones y Operadores
    Private Sub GenerarNumeros()
        Dim i As Integer
        Dim rndOpe(3) As Integer
        Dim Operador(2) As String
        Dim rnd As Random = New Random


        vSol(0).Text = rnd.Next(1, 15).ToString
        vSol(2).Text = rnd.Next(1, 15).ToString
        vSol(4).Text = rnd.Next(1, 15).ToString
        vSol(6).Text = rnd.Next(1, 15).ToString

        txt_Indice.Text = "0"

        For i = 0 To 3
            vBtnNum(i).Enabled = True
            vBtnOpe(i).Enabled = False
        Next

        For i = 0 To 3
            rndOpe(i) = rnd.Next(1, 5)
        Next

        For i = 0 To 2
            If rndOpe(i) = 1 Then
                Operador(i) = "+"
            End If
            If rndOpe(i) = 2 Then
                Operador(i) = "-"
            End If
            If rndOpe(i) = 3 Then
                Operador(i) = "*"
            End If
            If rndOpe(i) = 4 Then
                Operador(i) = "/"
            End If
        Next

        vSol(1).Text = Operador(0)
        vSol(3).Text = Operador(1)
        vSol(5).Text = Operador(2)

    End Sub
    'Calcula operacion y en caso de division valida que sea exacta
    Public Sub Operacion()
        Dim resp As Integer
        Dim Resultado As Integer
        Dim Residuo As Long
        Dim temp As Long
        Dim i As Integer
        Dim rndbtn As Integer
        Dim rnd As Random = New Random


        'Inicia el calculo de la operacion usando en metodo Calculo de la Clase Calcular
        resp = Calcular.Calculo(vSol(0).Text, vSol(1).Text, vSol(2).Text, Resultado, Residuo)
        temp = temp + Residuo '
        resp = Calcular.Calculo(resp, vSol(3).Text, vSol(4).Text, Resultado, Residuo)
        temp = temp + Residuo
        resp = Calcular.Calculo(resp, vSol(5).Text, vSol(6).Text, Resultado, Residuo)
        temp = temp + Residuo

        'la suma de los resultados de los residuos debera ser = 0 para ser division exacta
        If temp = 0 Then
            Resultado1.Text = Resultado.ToString
        Else
            GenerarNumeros()
            Operacion()
        End If

        'Asigna los valores a los botones de numeros 
        rndbtn = rnd.Next(1, 3)
        If rndbtn = 1 Then
            vBtnNum(0).Text = vSol(4).Text
            vBtnNum(1).Text = vSol(2).Text
            vBtnNum(2).Text = vSol(0).Text
            vBtnNum(3).Text = vSol(6).Text
        End If
        If rndbtn = 2 Then
            vBtnNum(0).Text = vSol(2).Text
            vBtnNum(1).Text = vSol(4).Text
            vBtnNum(2).Text = vSol(6).Text
            vBtnNum(3).Text = vSol(0).Text
        End If
        If rndbtn = 3 Then
            vBtnNum(0).Text = vSol(2).Text
            vBtnNum(1).Text = vSol(0).Text
            vBtnNum(2).Text = vSol(6).Text
            vBtnNum(3).Text = vSol(4).Text
        End If
        For i = 0 To 3
            vBtnNum(i).Tag = "0"
        Next
    End Sub

    'Carga el valor del numero seleccionado 
    Private Sub CargarNumero(ByVal n As Integer)
        vNum(txt_Indice.Text).Text = vBtnNum(n).Text
        txt_Indice.Text = txt_Indice.Text + 1
    End Sub

    'Carga el valor del operador seleccionado 
    Private Sub CargarOper(ByVal n As Integer)
        vNum(txt_Indice.Text).Text = vBtnOpe(n).Text
        txt_Indice.Text = txt_Indice.Text + 1
        Habilitar()
        DeshabilitarOper()
    End Sub

    'Habilita los botones de numeros
    Sub Habilitar()
        Dim i As Integer
        For i = 0 To 3
            If vBtnNum(i).Tag = "0" Then
                vBtnNum(i).Enabled = True
            End If
        Next
    End Sub
    'Deshabilita los botones de numeros
    Sub Deshabilitar()
        Dim i As Integer
        For i = 0 To 3
            vBtnNum(i).Enabled = False
        Next
    End Sub
    'Habilita los botones de los operadores
    Sub HabilitarOper()
        Dim i As Integer
        For i = 0 To 3
            vBtnOpe(i).Enabled = True
        Next
    End Sub
    'Deshabilita los botones de los operadores
    Sub DeshabilitarOper()
        Dim i As Integer
        For i = 0 To 3
            vBtnOpe(i).Enabled = False
        Next
    End Sub

    'Eventos de seleccion de numeros
    Private Sub btn_num1_Click(sender As Object, e As EventArgs) Handles btn_num1.Click
        CargarNumero(0)
        Deshabilitar()
        HabilitarOper()
        btn_num1.Tag = ("1")
    End Sub

    Private Sub btn_num2_Click(sender As Object, e As EventArgs) Handles btn_num2.Click
        CargarNumero(1)
        Deshabilitar()
        HabilitarOper()
        btn_num2.Tag = ("1")
    End Sub

    Private Sub btn_num3_Click(sender As Object, e As EventArgs) Handles btn_num3.Click
        CargarNumero(2)
        Deshabilitar()
        HabilitarOper()
        btn_num3.Tag = ("1")
    End Sub

    Private Sub btn_num4_Click(sender As Object, e As EventArgs) Handles btn_num4.Click
        CargarNumero(3)
        Deshabilitar()
        HabilitarOper()
        btn_num4.Tag = ("1")
    End Sub

    'Eventos de seleccion de operadores
    Private Sub btn_ope1_Click(sender As Object, e As EventArgs) Handles btn_ope1.Click
        CargarOper(0)
        Habilitar()
    End Sub

    Private Sub btn_ope2_Click(sender As Object, e As EventArgs) Handles btn_ope2.Click
        CargarOper(1)
        Habilitar()
    End Sub

    Private Sub btn_ope3_Click(sender As Object, e As EventArgs) Handles btn_ope3.Click
        CargarOper(2)
        Habilitar()
    End Sub

    Private Sub btn_ope4_Click(sender As Object, e As EventArgs) Handles btn_ope4.Click
        CargarOper(3)
        Habilitar()
    End Sub

    Private Sub txt_num3_TextChanged(sender As Object, e As EventArgs) Handles txt_num3.TextChanged
        Dim resp As Integer
        resp = Calcular.Verifica(txt_num1.Text, txt_num2.Text, txt_num3.Text)
        R_Parcial.Text = resp
    End Sub

    Private Sub txt_num5_TextChanged(sender As Object, e As EventArgs) Handles txt_num5.TextChanged
        Dim resp As Integer
        resp = Calcular.Verifica(R_Parcial.Text, txt_num4.Text, txt_num5.Text)
        R_Parcial.Text = resp
    End Sub

    Private Sub txt_num7_TextChanged(sender As Object, e As EventArgs) Handles txt_num7.TextChanged
        Dim resp As Integer
        resp = Calcular.Verifica(R_Parcial.Text, txt_num6.Text, txt_num7.Text)
        R_Parcial.Text = resp
    End Sub

    Private Sub txt_num1_TextChanged(sender As Object, e As EventArgs) Handles txt_num1.TextChanged
        R_Parcial.Text = txt_num1.Text
    End Sub
End Class
