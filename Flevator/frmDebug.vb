Public Class frmDebug


    Private Sub frmDebug_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtLog_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLog.TextChanged
        txtLog.SelectionStart = txtLog.Text.Length
    End Sub
End Class