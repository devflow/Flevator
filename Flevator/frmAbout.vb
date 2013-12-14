Public Class frmAbout

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim webAddress As String = "http://www.ilbe.com/celeb"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim webAddress As String = "http://devflow.kr/"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim webAddress As String = "http://gall.dcinside.com/list.php?id=flash"
        Process.Start(webAddress)
    End Sub

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class