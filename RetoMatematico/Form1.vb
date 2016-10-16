Public Class Form1
    Dim vNum(7) As TextBox
    Dim vSol(7) As TextBox
    Dim vBtnNum(4) As Button
    Dim vBtnOpe(4) As Button

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
        Dim i As Integer
        Dim rndOpe(3) As Integer
        Dim Operador(2) As String
        Dim rnd As Random = New Random

        For i = 0 To 3
            vBtnNum(i).Text = rnd.Next(1, 15)
            vBtnNum(i).Tag = "0"
        Next
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

        vSol(0).Text = vBtnNum(0).Text
        vSol(1).Text = Operador(0)
        vSol(2).Text = vBtnNum(1).Text
        vSol(3).Text = Operador(1)
        vSol(4).Text = vBtnNum(2).Text
        vSol(5).Text = Operador(2)
        vSol(6).Text = vBtnNum(3).Text






    End Sub

    Private Sub CargarNumero(ByVal n As Integer)
        vNum(txt_Indice.Text).Text = vBtnNum(n).Text
        txt_Indice.Text = txt_Indice.Text + 1
    End Sub

    Private Sub CargarOper(ByVal n As Integer)
        vNum(txt_Indice.Text).Text = vBtnOpe(n).Text
        txt_Indice.Text = txt_Indice.Text + 1
        Habilitar()
        DeshabilitarOper()
    End Sub

    Sub Habilitar()
        Dim i As Integer
        For i = 0 To 3
            If vBtnNum(i).Tag = "0" Then
                vBtnNum(i).Enabled = True

            End If
        Next
    End Sub

    Sub Deshabilitar()
        Dim i As Integer
        For i = 0 To 3
            vBtnNum(i).Enabled = False
        Next
    End Sub

    Sub DeshabilitarOper()
        Dim i As Integer
        For i = 0 To 3
            vBtnOpe(i).Enabled = False
        Next
    End Sub

    Sub HabilitarOper()
        Dim i As Integer
        For i = 0 To 3
            vBtnOpe(i).Enabled = True
        Next
    End Sub

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

    Private Sub btn_ope1_Click(sender As Object, e As EventArgs) Handles btn_ope1.Click
        CargarOper(0)
    End Sub

    Private Sub btn_ope2_Click(sender As Object, e As EventArgs) Handles btn_ope2.Click
        CargarOper(1)
    End Sub

    Private Sub btn_ope3_Click(sender As Object, e As EventArgs) Handles btn_ope3.Click
        CargarOper(2)
    End Sub

    Private Sub btn_ope4_Click(sender As Object, e As EventArgs) Handles btn_ope4.Click
        CargarOper(3)
    End Sub
End Class
