Imports System.Text

Public Class frmSplash
#Region " ClientAreaMove Handling "
    Const WM_NCHITTEST As Integer = &H84
    Const HTCLIENT As Integer = &H1
    Const HTCAPTION As Integer = &H2
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Select Case m.Msg
            Case WM_NCHITTEST
                MyBase.WndProc(m)
                If m.Result = HTCLIENT Then m.Result = HTCAPTION
                'If m.Result.ToInt32 = HTCLIENT Then m.Result = IntPtr.op_Explicit(HTCAPTION) 'Try this in VS.NET 2002/2003 if the latter line of code doesn't do it... thx to Suhas for the tip.
            Case Else
                'Make sure you pass unhandled messages back to the default message handler.
                MyBase.WndProc(m)
        End Select
    End Sub
#End Region
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub frmSplash_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub frmSplash_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If frmMain.Logined = False Then End
    End Sub

    Private Sub frmSplash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        AddLog("start flevator v" & Application.ProductVersion)
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click() Handles Button1.Click
        AddLog("btnlogin click")
        Button1.Enabled = False
        Dim rText As String = frmMain.WRequest("https://www.tistory.com/login/", "POST", "loginid=" & txtID.Text & "&password=" & txtPass.Text)
        Dim sBuff As String

        If InStr(rText, "LoginForm") <> 0 Then
            AddLog("loginfailed:wrong password")
            MsgBox("이메일 또는 비밀번호가 잘못되었습니다.", MsgBoxStyle.Exclamation, "오류")
            frmMain.Logined = False
            Button1.Enabled = True
            Exit Sub
        ElseIf InStr(rText, "An error occu") <> 0 Or InStr(rText, "my tistory") = 0 Then
            AddLog("loginfailed login html")
            AddLog("---------------------------------------------------")
            AddLog(rText)
            AddLog("---------------------------------------------------")
            MsgBox("인터넷 접속에 문제가있습니다." & rText, MsgBoxStyle.Exclamation, "오류")
            frmMain.Logined = False
            Button1.Enabled = True
            Exit Sub
        End If



        rText = Mid(rText, InStr(rText, "<h3>my tistory</h3>"))
        rText = Mid(rText, 1, InStr(rText, "</ul>"))
        AddLog("initlize")

        Do

            If InStr(rText, "<a href=" & Chr(34) & "http://") = 0 Then Exit Do

            rText = Mid(rText, InStr(rText, "<a href=" & Chr(34) & "http://") + 9)
            sBuff = Mid(rText, 1, InStr(rText, ">") - 2)
            frmMain.cmbList.Items.Add(sBuff)
            AddLog("found blog : " & sBuff)

        Loop

        If chkAuto.Checked Then
            INIWrite("login", "auto", "true")
            Dim nByte As Byte()

            nByte = Encoding.UTF8.GetBytes(txtPass.Text)

            INIWrite("login", "pw", Convert.ToBase64String(nByte))
        Else
            INIWrite("login", "auto", "false")
            INIWrite("login", "pw", "")
        End If



        frmMain.cmbList.SelectedIndex = 0
        frmMain.Logined = True

        AddLog("logon")
        INIWrite("login", "email", txtID.Text)

        frmMain.Show()
        Me.Close()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtPass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click()
        End If
    End Sub

    Private Sub txtPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPass.TextChanged

    End Sub

    Private Sub txtID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.TextChanged

    End Sub

    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        txtID.Text = INIRead("login", "email")
        AddLog("load ini file section [email]")

        If txtID.Text <> "" Then
            txtPass.Focus()

        End If
        If INIRead("login", "auto") = "true" Then
            Dim nByte As Byte()

            chkAuto.Checked = True
            nByte = Convert.FromBase64String(INIRead("login", "pw"))

            txtPass.Text = Encoding.UTF8.GetString(nByte)

            Button1_Click()
        End If
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        Dim nURL As String = "http://devflow.kr/"
        Process.Start(nURL)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
End Class