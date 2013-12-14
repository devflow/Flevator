Imports System.Text.RegularExpressions

'Imports System.Net

Public Class frmMain

    '' 필요한게
    '  
    '  티스토리 로그인x
    '
    '   업로드할꺼x
    '
    '   플레이어 주소
    '   크기   
    '   
    '   
    '
    '

    Public Class attachFile
        Public Name As String
        Public URL As String
        Public size As String
        Public Kind As String
    End Class
    Public Class flash
        Public Name As String
        Public URL As String
        Public Description As String
    End Class

    Private scrollDirection As Integer
    Private hoverItem As ListViewItem
    Private savedHoverIndex As Integer
    Private vdFiles As String, allSize As Long, curSize As Long

    Public hMain As Net.HttpWebRequest, Logined As Boolean, skinLOC As String, FileData() As attachFile, upCount As Long, nti_url As String, flashData() As flash, tipofsec() As String
    Dim cookieJar As New System.Net.CookieContainer()
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
    (ByVal hwnd As Integer, _
     ByVal wMsg As Integer, _
     ByVal wParam As Integer, _
     ByRef lParam As Object) As Integer
    Dim filname As String
    Dim a As Integer = 0
    Public advanceOption As Boolean = False

    Public Function WRequest(ByVal URL As String, ByVal method As String, ByVal POSTdata As String) As String
        AddLog("request url(" & URL & ")")
        Dim responseData As String = "", iPage As Integer = 0, iContent As Long = 0
        Try
            hMain = Net.WebRequest.Create(URL)
            hMain.Accept = "*/*"
            hMain.AllowAutoRedirect = True
            hMain.Referer = "http://www.tistory.com/"
            hMain.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.56 Safari/535.11"
            hMain.CookieContainer = cookieJar
            hMain.Timeout = 60000
            hMain.Method = method
            If hMain.Method = "POST" Then
                hMain.ContentType = "application/x-www-form-urlencoded"
                Dim encoding As New System.Text.ASCIIEncoding() 'Use UTF8Encoding for XML requests
                Dim postByteArray() As Byte = encoding.GetBytes(POSTdata)
                hMain.ContentLength = postByteArray.Length
                Dim postStream As IO.Stream = hMain.GetRequestStream()
                postStream.Write(postByteArray, 0, postByteArray.Length)
                postStream.Close()
                AddLog("posted")

            End If
            AddLog("request done.")
            Dim hwresponse As Net.HttpWebResponse = hMain.GetResponse()
            If hwresponse.StatusCode = Net.HttpStatusCode.OK Then
                Dim responseStream As IO.StreamReader = _
                  New IO.StreamReader(hwresponse.GetResponseStream())
                responseData = responseStream.ReadToEnd()
            End If

            hwresponse.Close()


        Catch e As Exception
            responseData = "An error occurred: " & e.Message
        End Try

        Return responseData

    End Function

    Dim WorkingTimer As New Stopwatch

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("정말로 Flevator를 종료하시겠습니까?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "알림") = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next


        topAD.Navigate("http://flevator.tistory.com/", "", New Byte() {0}, "User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.56 Safari/535.11 CoolNovo/2.0.2.26" & vbCrLf & "Referer: http://devflow.kr/flevator?ver=" & Application.ProductVersion & "&time=" & Format(Now, "hhmm") & vbCrLf)

        AddLog("reading ini settings")

        Version0x0ToolStripMenuItem.Text = "프로그램 버전 : v." & Application.ProductVersion
        Dim w As Integer, h As Integer

        w = INIRead("flash", "width", True)
        h = INIRead("flash", "height", True)

        AddLog("loaded width : " & w & ", height : " & h)

        If InStr(INIRead("flash", "custom"), "1") <> 0 Then
            rUser.Checked = True
            txtWidth.Text = w
            txtHeight.Text = h
            AddLog("but it's custom size")
        ElseIf h = "1080" Then
            r1080.Checked = True
        ElseIf h = "360" Then
            r360.Checked = True
        ElseIf h = "720" Then
            r720.Checked = True
        ElseIf h = "504" Then
            r504.Checked = True
        End If


        txtSWF.Text = INIRead("flash", "url")
        txtSkin.Text = INIRead("flash", "skin")

        txtOther.Text = INIRead("flash", "other")


        If INIRead("flash", "allowfull") = "true" Then
            cFull.Checked = True
        Else
            cFull.Checked = False
        End If

        If INIRead("flash", "autoplay") = "true" Then
            cAuto.Checked = True
        Else
            cAuto.Checked = False
        End If

        If INIRead("flash", "showcontrol") = "true" Then
            cControl.Checked = True
        Else
            cControl.Checked = False
        End If

        If INIRead("flash", "loop") = "true" Then
            chkLoop.Checked = True
        Else
            chkLoop.Checked = False
        End If

        If INIRead("flash", "split") = "true" Then
            chkHJSP.Checked = True
        Else
            chkHJSP.Checked = False
        End If

        If INIRead("flash", "number") = "true" Then
            chkNumber.Checked = True
        Else
            chkNumber.Checked = False
        End If

        If INIRead("flash", "ratio") = "true" Then
            chkRatio.Checked = True
        Else
            chkRatio.Checked = False
        End If

        If INIRead("flash", "advance") = "true" Then
            chkAdvan.Checked = True
        Else
            chkAdvan.Checked = False
        End If
        AddLog("loaded")



    End Sub
    Public Function uploadFile(ByVal strPath As String, ByRef lvItem As ListViewItem) As Boolean
        Dim cc As System.Net.CookieCollection = cookieJar.GetCookies(New Uri("http://www.tistory.com"))



        lvItem.SubItems.Item(2).Text = "업로드 준비중..."
        AddLog("ready for upload : ")
        AddLog(strPath)
        AddLog("---------------------------------------------------")

        Dim boundary As String = "----------" & DateTime.Now.Ticks.ToString("x")
        Dim newLine As String = System.Environment.NewLine
        Dim boundaryBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(newLine & "--" & boundary & newLine)

        hMain = Net.WebRequest.Create("http://uset1-file1.uf.daum.net/upload_cc")

        hMain.ContentType = "multipart/form-data; boundary=" & boundary
        hMain.Method = "POST"
        hMain.Accept = "text/*"
        hMain.CookieContainer = cookieJar
        hMain.AllowAutoRedirect = True
        hMain.Timeout = -1
        hMain.UserAgent = "Shockwave Flash"
        hMain.KeepAlive = True
        hMain.AllowWriteStreamBuffering = False

        Dim ms As New System.IO.MemoryStream()
        Dim formDataTemplate As String = "Content-Disposition: form-data; name=""{0}""{1}{1}{2}"

        'For Each key As String In otherParameters.Keys
        ms.Write(boundaryBytes, 0, boundaryBytes.Length)

        Dim formItem As String, formItemBytes As Byte()

        formItem = String.Format(formDataTemplate, "Filename", newLine, New System.IO.FileInfo(strPath).Name)
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)
        formItem = String.Format(formDataTemplate, "service_farm", newLine, "not_use")
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)
        formItem = String.Format(formDataTemplate, "coca_over_skin", newLine, "http://i1.daumcdn.net/icon/editor/file/bt_filesearch.png?rv=1.0.1")
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)
        formItem = String.Format(formDataTemplate, "daum_cookie", newLine, cc.Item("UF").Value)
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)
        formItem = String.Format(formDataTemplate, "service", newLine, "tistory")
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)
        formItem = String.Format(formDataTemplate, "coca_service", newLine, "TistoryNewCoca")
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)
        formItem = String.Format(formDataTemplate, "coca_skin", newLine, "http://i1.daumcdn.net/icon/editor/file/bt_filesearch.png?rv=1.0.1")
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)
        formItem = String.Format(formDataTemplate, "src", newLine, "file")
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)
        formItem = String.Format(formDataTemplate, "debug", newLine, "false")
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)
        formItem = String.Format(formDataTemplate, "use_cc", newLine, "true")
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)
        formItem = String.Format(formDataTemplate, "coca_auth_url", newLine, "/admin/entry/post/getDaumCookie.php")
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)
        formItem = String.Format(formDataTemplate, "type", newLine, "attach")
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)
        formItem = String.Format(formDataTemplate, "filesrc", newLine, New System.IO.FileInfo(strPath).Length)
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)
        formItem = String.Format(formDataTemplate, "coca_auth_type", newLine, "tistory")
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)
        formItem = String.Format(formDataTemplate, "cc", newLine, "1")
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)

        'Next key

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)

        AddLog("memory written t - ")

        Dim headerTemplate As String = "Content-Disposition: form-data; name=""{0}""; filename=""{1}""{2}Content-Type: {3}{2}{2}"
        Dim header As String = String.Format(headerTemplate, "Filedata", New System.IO.FileInfo(strPath).Name, newLine, "application/octet-stream")
        Dim headerBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(header)
        ms.Write(headerBytes, 0, headerBytes.Length)
        Application.DoEvents()
        Dim M1S As New System.IO.MemoryStream()

        M1S.Write(boundaryBytes, 0, boundaryBytes.Length)
        formItem = String.Format(formDataTemplate, "Upload", newLine, "Submit Query")
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        M1S.Write(formItemBytes, 0, formItemBytes.Length)
        M1S.Write(boundaryBytes, 0, boundaryBytes.Length)

        Dim length As Long = ms.Length + M1S.Length
        length += New System.IO.FileInfo(strPath).Length
        hMain.ContentLength = length

        Dim lengthA As Long
        lengthA = New System.IO.FileInfo(strPath).Length

        AddLog("starting upload  size:" & lengthA)

        Dim speedtimer As New Stopwatch, readings As Integer = 0
        Dim currentspeed As Double = -1

        Using requestStream As IO.Stream = hMain.GetRequestStream()
            Dim bheader() As Byte = ms.ToArray()
            requestStream.Write(bheader, 0, bheader.Length)
            Using fileStream As New IO.FileStream(strPath, IO.FileMode.Open, IO.FileAccess.Read)

                Dim buffer(4096) As Byte, loadedBytes As Long = 0
                Dim bytesRead As Int32 = fileStream.Read(buffer, 0, buffer.Length)

                Do While (bytesRead > 0)

                    speedtimer.Start()

                    requestStream.Write(buffer, 0, bytesRead)
                    bytesRead = fileStream.Read(buffer, 0, buffer.Length)
                    loadedBytes += buffer.Length
                    readings += 1
                    curSize += buffer.Length
                    speedtimer.Stop()

                    If readings >= 10 Then 'For increase precision, the speed it's calculated only every five cicles
                        currentspeed = loadedBytes / (speedtimer.ElapsedMilliseconds / 1000)
                        Dim Tmr1 As TimeSpan = TimeSpan.FromMilliseconds(WorkingTimer.ElapsedMilliseconds)
                        Dim Tmr2 As TimeSpan = TimeSpan.FromMilliseconds(((allSize - curSize) / (loadedBytes / speedtimer.ElapsedMilliseconds)))
                        labCal.Text = " 업로드 속도 : " & Format((currentspeed / 1024), "#.0") & "KB/s      진행 시간 : " & Format(Tmr1.Hours, "0#시간") & " " & Format(Tmr1.Minutes, "0#분") & " " & Format(Tmr1.Seconds, "0#초") & "      남은 시간 : " & Format(Tmr2.Hours, "0#시간") & " " & Format(Tmr2.Minutes, "0#분") & " " & Format(Tmr2.Seconds, "0#초")

                        readings = 0
                    End If

                    lvItem.SubItems(2).Text = "업로드중... " & Int((loadedBytes / lengthA) * 100) & "%"

                    
                    Application.DoEvents()
                Loop
            End Using

            speedtimer.Reset()
            Dim lHeader() As Byte = M1S.ToArray()
            requestStream.Write(lHeader, 0, lHeader.Length)
            requestStream.Close()
        End Using

        AddLog("cmp.")

        Dim response As Net.WebResponse = Nothing
        Dim responseText = ""

        response = hMain.GetResponse()

        Using responseStream As IO.Stream = response.GetResponseStream()

            Using responseReader As New IO.StreamReader(responseStream)

                responseText = responseReader.ReadToEnd()

            End Using

        End Using
        AddLog("response text from upload")
        AddLog("---------------------------------------------------")
        AddLog(responseText)
        AddLog("---------------------------------------------------")
        If InStr(responseText, "<response_code>200</response_code>") = 0 Then
            'MsgBox("업로드중 에러가 발생하였습니다. 용량이 초과되었는지 확인하세요", MsgBoxStyle.Critical, "오류")
            lvItem.SubItems(2).Text = "오류 발생"
            lvItem.ImageKey = 2
            Return False
        End If

        Application.DoEvents()
        Dim fReal As String = Mid(responseText, InStr(responseText, "name=" & Chr(34) & "realname" & Chr(34) & "><![CDATA[") + 25)
        fReal = Mid(fReal, 1, InStr(fReal, "]]></property>") - 1)

        AddLog("fr : " & fReal)
        Dim fSize As String = Mid(responseText, InStr(responseText, "name=" & Chr(34) & "filesize" & Chr(34) & "><![CDATA[") + 25)
        fSize = Mid(fSize, 1, InStr(fSize, "]]></property>") - 1)
        AddLog("fs : " & fSize)

        Dim fKind As String = Mid(responseText, InStr(responseText, "name=" & Chr(34) & "mimetype" & Chr(34) & "><![CDATA[") + 25)
        fKind = Mid(fKind, 1, InStr(fKind, "]]></property>") - 1)
        AddLog("fk : " & fKind)

        Dim fURL As String = Mid(responseText, InStr(responseText, "name=" & Chr(34) & "attach" & Chr(34) & "><![CDATA[") + 23)
        fURL = Mid(fURL, 1, InStr(fURL, "]]></property>") - 1)
        AddLog("A- fu : " & fURL)

        fURL = Replace(Replace(fURL, "http://", ""), ".tistory.com/attach/", "@") & "." & New System.IO.FileInfo(strPath).Extension

        lvItem.SubItems(3).Text = cmbList.Text & "attachment/" & fURL

        AddLog("B- fu : " & fURL)
        AddLog("C- fu : " & cmbList.Text & "attachment/" & fURL)

        upCount = upCount + 1

        AddLog("*----------------- upcnt to " & upCount)

        ReDim Preserve FileData(upCount)

        FileData(upCount) = New attachFile
        FileData(upCount).Name = fReal
        FileData(upCount).size = fSize
        FileData(upCount).Kind = fKind
        FileData(upCount).URL = fURL


        lvItem.SubItems(2).Text = "업로드 완료"
        lvItem.ImageKey = 1


        Return True

    End Function

    Public Function initBlog(ByVal strSite As String) As Boolean
        Dim responseData As String = ""

        AddLog("#init blog from " & strSite)

        hMain = Net.WebRequest.Create(strSite & "admin/skin/upload/")
        hMain.AllowAutoRedirect = True
        hMain.Referer = "http://www.tistory.com/"
        hMain.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.56 Safari/535.11"
        hMain.CookieContainer = cookieJar
        hMain.Timeout = 60000
        hMain.Method = "GET"
        Dim hwresponse As Net.HttpWebResponse = hMain.GetResponse()
        If hwresponse.StatusCode = Net.HttpStatusCode.OK Then
            Dim responseStream As IO.StreamReader = _
              New IO.StreamReader(hwresponse.GetResponseStream())
            responseData = responseStream.ReadToEnd()
        End If
        hwresponse.Close()
        Application.DoEvents()
        If InStr(responseData, "http://cfs.tistory.com/custom/blog/") = 0 Then Return False : Exit Function

        AddLog("response from initblog")
        AddLog("---------------------------------------------------")
        AddLog(responseData)
        AddLog("---------------------------------------------------")
        responseData = Mid(responseData, InStr(responseData, "http://cfs.tistory.com/custom/blog/"))
        responseData = Mid(responseData, 1, InStr(responseData, "/skin/") + 5)
        skinLOC = responseData
        AddLog("result of skinLoc : " & skinLOC)

        Return True

    End Function

#Region "Listview"

    Private Sub lstFiles_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstFiles.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim i As String() = e.Data.GetData(DataFormats.FileDrop)
            Dim j As String
            For Each j In i
                If System.IO.Directory.Exists(j) Then
                    ScanDirectory(j)
                Else
                    Dim xBuf As String = System.IO.Path.GetFileName(j)
                    Dim tmp As ListViewItem
                    Dim hd(3) As Byte
                    Try

                        FileOpen(1, j, OpenMode.Binary)
                        FileGet(1, hd)
                        FileClose(1)
                        If hd(0) = 70 And hd(1) = 76 And hd(2) = 86 Then
                            tmp = lstFiles.Items.Add(xBuf, 0) '.SubItems.Add(xBuf)
                            tmp.SubItems.Add(ConvertSize(New System.IO.FileInfo(j).Length))
                            tmp.SubItems.Add("준비")
                            tmp.SubItems.Add("")
                            tmp.Tag = j
                        Else
                            tmp = lstFiles.Items.Add(xBuf, 0)  '.SubItems.Add(xBuf)
                            tmp.ForeColor = Color.MediumVioletRed
                            tmp.SubItems.Add(ConvertSize(New System.IO.FileInfo(j).Length))
                            tmp.SubItems.Add("준비 (FLV파일이 아님)")
                            tmp.SubItems.Add("")
                            tmp.Tag = j
                        End If

                    Catch ex As Exception

                    End Try


                End If
            Next
        Else
            If lstFiles.SelectedItems.Count = 0 Then Exit Sub

            Dim p As Point = lstFiles.PointToClient(New Point(e.X, e.Y))

            Dim dragToItem As ListViewItem = lstFiles.GetItemAt(p.X, p.Y)

            If dragToItem Is Nothing Then Exit Sub

            Dim dragIndex As Integer = dragToItem.Index
            Dim i As Integer
            Dim sel(lstFiles.SelectedItems.Count) As ListViewItem

            For i = 0 To lstFiles.SelectedItems.Count - 1
                sel(i) = lstFiles.SelectedItems.Item(i)
            Next

            For i = 0 To lstFiles.SelectedItems.Count - 1

                Dim dragItem As ListViewItem = sel(i)
                Dim itemIndex As Integer = dragIndex

                If itemIndex = dragItem.Index Then Exit Sub

                If dragItem.Index < itemIndex Then
                    itemIndex = itemIndex + 1
                Else
                    itemIndex = dragIndex + i
                End If

                Dim insertitem As ListViewItem = dragItem.Clone
                lstFiles.Items.Insert(itemIndex, insertitem)

                lstFiles.Items.Remove(dragItem)
            Next
        End If
        tmrLVScroll.Enabled = False
    End Sub

    Private Sub ScanDirectory(ByVal strDir As String)
        If Not System.IO.Directory.Exists(strDir) Then Exit Sub
        Dim strArrFiles As String() = System.IO.Directory.GetFiles(strDir)
        Dim strArrDir As String() = System.IO.Directory.GetDirectories(strDir)
        Dim i As String
        For Each i In strArrDir
            ScanDirectory(i)
        Next
        For Each i In strArrFiles
            Dim xBuf As String = System.IO.Path.GetFileName(i)
            Dim tmp As ListViewItem
            Dim hd(3) As Byte
            Try

                FileOpen(1, i, OpenMode.Binary)
                FileGet(1, hd)
                FileClose(1)
                If hd(0) = 70 And hd(1) = 76 And hd(2) = 86 Then
                    tmp = lstFiles.Items.Add(xBuf, 0) '.SubItems.Add(xBuf)
                    tmp.SubItems.Add(ConvertSize(New System.IO.FileInfo(i).Length))
                    tmp.SubItems.Add("준비")
                    tmp.SubItems.Add("")
                    tmp.Tag = i
                Else
                    tmp = lstFiles.Items.Add(xBuf, 0)  '.SubItems.Add(xBuf)
                    tmp.ForeColor = Color.MediumVioletRed
                    tmp.SubItems.Add(ConvertSize(New System.IO.FileInfo(i).Length))
                    tmp.SubItems.Add("준비 (FLV파일이 아님)")
                    tmp.SubItems.Add("")
                    tmp.Tag = i
                End If

            Catch e As Exception

            End Try



            AddLog("insert file : " & i)
        Next

    End Sub

    Private Sub lstFiles_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstFiles.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.Move
        End If

    End Sub

    Private Sub lstFiles_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFiles.DragLeave
        tmrLVScroll.Enabled = False
    End Sub

    Private Sub lstFiles_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstFiles.DragOver
        Dim position As Point
        position = New Point(0, 0)

        position.X = e.X
        position.Y = e.Y
        position = lstFiles.PointToClient(position)
        hoverItem = lstFiles.GetItemAt(position.X, position.Y)

        If position.Y <= lstFiles.Font.Height \ 2 Then
            ' getting close to top, ensure previous item is visible
            scrollDirection = 0
            tmrLVScroll.Enabled = True
        ElseIf position.Y >= lstFiles.ClientSize.Height - lstFiles.Font.Height \ 2 Then
            ' getting close to bottom, ensure next item is visible
            scrollDirection = 1
            tmrLVScroll.Enabled = True
        Else
            tmrLVScroll.Enabled = False
        End If

        e.Effect = DragDropEffects.Move

        position.X = e.X
        position.Y = e.Y
        position = lstFiles.PointToClient(position)
        hoverItem = lstFiles.GetItemAt(position.X, position.Y)

        If IsNothing(hoverItem) Then Exit Sub

        If savedHoverIndex = hoverItem.Index Then Exit Sub

        lstFiles.BeginUpdate()
        lstFiles.EndUpdate()

        savedHoverIndex = hoverItem.Index
    End Sub

    Private Sub lstFiles_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lstFiles.ItemDrag
        lstFiles.DoDragDrop(lstFiles.SelectedItems, DragDropEffects.Move)
    End Sub
    Private Sub lstFiles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstFiles.KeyDown
        On Error Resume Next
        If e.KeyCode = Keys.Delete Then

            For Each slItem As ListViewItem In lstFiles.SelectedItems
                lstFiles.Items.Remove(slItem)
            Next
        ElseIf e.Control = True And e.KeyCode = Keys.A Then
            For Each j As ListViewItem In lstFiles.Items
                j.Selected = True
            Next
        End If
    End Sub

#End Region



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        AddLog("btnStart click")
        If lstFiles.Items.Count = 0 Then Exit Sub

        If r1080.Checked Then
            INIWrite("flash", "width", "1080")
            INIWrite("flash", "height", "1920")
            INIWrite("flash", "custom", "0")
        ElseIf (r360.Checked) Then
            INIWrite("flash", "width", "360")
            INIWrite("flash", "height", "640")
            INIWrite("flash", "custom", "0")
        ElseIf (r720.Checked) Then
            INIWrite("flash", "width", "720")
            INIWrite("flash", "height", "1280")
            INIWrite("flash", "custom", "0")
        ElseIf (r504.Checked) Then
            INIWrite("flash", "width", "896")
            INIWrite("flash", "height", "504")
            INIWrite("flash", "custom", "0")
        ElseIf (rUser.Checked) Then
            INIWrite("flash", "width", txtWidth.Text)
            INIWrite("flash", "height", txtHeight.Text)
            INIWrite("flash", "custom", "1")
        End If

        INIWrite("flash", "url", txtSWF.Text)
        INIWrite("flash", "skin", txtSkin.Text)
        INIWrite("flash", "other", txtOther.Text)
        INIWrite("flash", "allowfull", IIf(cFull.Checked, "true", "false"))
        INIWrite("flash", "autoplay", IIf(cAuto.Checked, "true", "false"))
        INIWrite("flash", "showcontrol", IIf(cControl.Checked, "true", "false"))
        INIWrite("flash", "loop", IIf(chkLoop.Checked, "true", "false"))
        INIWrite("flash", "ratio", IIf(chkRatio.Checked, "true", "false"))
        INIWrite("flash", "split", IIf(chkHJSP.Checked, "true", "false"))
        INIWrite("flash", "number", IIf(chkNumber.Checked, "true", "false"))
        INIWrite("flash", "advance", IIf(chkAdvan.Checked, "true", "false"))



        AddLog("All Setting is svaved")

        lstFiles.AllowDrop = False
        Button1.Enabled = False
        목록스마트정렬SToolStripMenuItem.Enabled = False
        cFiles.Enabled = False

        upCount = 0
        allSize = 0
        curSize = 0


        If initBlog(cmbList.Text) = False Then MsgBox("죄송합니다. 선택하신 블로그에는 XML을 업로드 할 수 없습니다.", MsgBoxStyle.Critical, "에러") : GoTo endOfWork

        vdFiles = ""
        AddLog("init vbFiles")
        Dim tmpFile As IO.FileInfo
        For Each i As ListViewItem In lstFiles.Items
            tmpFile = New System.IO.FileInfo(i.Tag)
            If tmpFile.Exists Then
                If tmpFile.Length <= 10485760 Then
                    allSize += tmpFile.Length
                End If
            End If
        Next

        WorkingTimer.Start()

        For Each i As ListViewItem In lstFiles.Items
            tmpFile = New System.IO.FileInfo(i.Tag)
            If tmpFile.Exists Then
                If tmpFile.Length <= 10485760 Then
                    AddLog("query up->")
                    uploadFile(i.Tag, i)
                    AddLog("<-query up")
                Else
                    AddLog("over size!! skip")
                    i.SubItems(2).Text = "업로드 용량 10MB가 초과하였습니다."
                End If
            Else
                AddLog("not exist!! skip")
                i.SubItems(2).Text = "파일이 존재하지 않습니다."
            End If
        Next

        WorkingTimer.Reset()

        '////////////////

        '' file_name[]=##_FILEURL_##&file_label[]=##_REALNAME_##&file_mime[]=##_FILEKIND_##&file_size[]=##_FILESIZE_##&file_width[]=0&file_height[]=0&file_ccResult[]=999&file_ccVersion[]=0&file_ccDate[]=Sat%20Jun%2002%202012%2022%3A04%3A08%20GMT%2B0900%20(%EB%8C%80%ED%95%9C%EB%AF%BC%EA%B5%AD%20%ED%91%9C%EC%A4%80%EC%8B%9C)&file_ccTrackId[]=0

        Dim fileFormat As String = "&file_name[]={0}&file_label[]={1}&file_mime[]={2}&file_size[]={3}&file_width[]=0&file_height[]=0&file_ccResult[]=999&file_ccVersion[]=0&file_ccDate[]=Sat%20Jun%2002%202012%2022%3A04%3A08%20GMT%2B0900%20(%EB%8C%80%ED%95%9C%EB%AF%BC%EA%B5%AD%20%ED%91%9C%EC%A4%80%EC%8B%9C)&file_ccTrackId[]=0"
        Dim buffFormat As String = ""
        For i = 1 To upCount
            buffFormat = buffFormat & String.Format(fileFormat, UrlEncode(FileData(i).URL), UrlEncode(FileData(i).Name), UrlEncode(FileData(i).Kind), FileData(i).size)
            vdFiles = vdFiles & Replace(txtAttach.Text, "##_FILENAME_##", FileData(i).Name).Replace("##_URL_##", FileData(i).URL).Replace("##_KIMD_##", FileData(i).Kind).Replace("##_SIZE_##", ConvertSize(FileData(i).size))
        Next

        Posting(buffFormat)

endOfwork:
        lstFiles.AllowDrop = True
        Button1.Enabled = True
        목록스마트정렬SToolStripMenuItem.Enabled = True
        cFiles.Enabled = True

    End Sub

    Sub Posting(ByVal fileD As String)
        Dim cc As System.Net.CookieCollection = cookieJar.GetCookies(New Uri("http://www.tistory.com"))

        Dim formatPost As String = "category=0&title=##_TITLE_##&uselessMarginForEntry=1&acceptComment=1&acceptTrackback=1&password=##_PASS_##&published=1&visibility=0&slogan=&thumbnail=&isKorea=true&trackback=http%3A%2F%2F&cclCommercial=1&cclDerive=3&id=0&content=##_CONTENT_##&isNewEditor=true&tag=&location=" & fileD
        Dim newLine As String = System.Environment.NewLine
        AddLog("starting posting..")
        hMain = Net.WebRequest.Create(cmbList.Text & "admin/entry/post/saveEntry.php")
        Application.DoEvents()
        hMain.ContentType = "application/x-www-form-urlencoded"
        hMain.Method = "POST"
        hMain.Accept = "*/*"
        hMain.Headers.Add("Origin", cmbList.Text)
        hMain.CookieContainer = cookieJar
        hMain.AllowAutoRedirect = True
        hMain.Referer = cmbList.Text & "admin/entry/post/"
        hMain.Timeout = -1
        hMain.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.56 Safari/535.11 CoolNovo/2.0.2.26"
        hMain.KeepAlive = True
        hMain.Headers.Add("charset", "utf8")
        hMain.AllowWriteStreamBuffering = False

        AddLog("init all parameters")
        formatPost = Replace(Replace(Replace(formatPost, "##_TITLE_##", UrlEncode(txtTitle.Text)), "##_PASS_##", DateTime.Now.Ticks.ToString("x")), "##_CONTENT_##", UrlEncode(txtContent.Text & vdFiles & "<br>upload by fleavator v." & Application.ProductVersion & "<br>"))
        'formatPost = Replace(Replace(formatPost, "##_FILEURL_##", UrlEncode(fileURL)), "##_REALNAME_##", UrlEncode(fileReal))
        'formatPost = Replace(Replace(formatPost, "##_FILEKIND_##", UrlEncode(fileKIND)), "##_FILESIZE_##", fileSize)
        AddLog("joining PostData")
        AddLog("---------------------------------------------------")
        AddLog(formatPost)
        AddLog("---------------------------------------------------")
        Dim ms As New System.IO.MemoryStream()
        Dim tmpData As Byte()

        tmpData = System.Text.Encoding.UTF8.GetBytes(formatPost)
        ms.Write(tmpData, 0, tmpData.Length)

        hMain.ContentLength = ms.Length
        AddLog("all data puted size :" & ms.Length)
        Using requestStream As IO.Stream = hMain.GetRequestStream()
            Dim bheader() As Byte = ms.ToArray()
            requestStream.Write(bheader, 0, bheader.Length)
            requestStream.Close()
        End Using

        AddLog("cmp send")
        Dim response As Net.WebResponse = Nothing
        Dim responseText = ""

        response = hMain.GetResponse()

        Using responseStream As IO.Stream = response.GetResponseStream()

            Using responseReader As New IO.StreamReader(responseStream)
                Application.DoEvents()
                responseText = responseReader.ReadToEnd()

            End Using

        End Using

        If InStr(responseText, "error" & Chr(34) & ":false") = 0 Then
            AddLog("error form excep")
            MsgBox("포스팅중 오류가 발생하였습니다.블로그의 글쓰기 가능여부를 확인하세요.", MsgBoxStyle.Exclamation, "에러")
            Exit Sub
        Else
            AddLog("success")
            AddLog("response data")
            AddLog("---------------------------------------------------")
            AddLog(responseText)
            AddLog("---------------------------------------------------")
            If CheckBox1.Checked Then
                Dim src_vary As String = "var _Array:Array = [ //GENERATED BY FLEVATOR url: devflow.kr" & vbCrLf
                Dim tmp_item As String = "   //{0}" & vbCrLf & "   " & Chr(34) & "{1}" & Chr(34) & "," & vbCrLf
                For i = 1 To upCount
                    src_vary = src_vary & String.Format(tmp_item, FileData(i).Name, cmbList.Text & "attachment/" & FileData(i).URL)
                Next
                txtResult.Text = src_vary & "];"
                Sound.PlayWaveResource("note.wav")
            Else
                uploadXML()
            End If

        End If



    End Sub
    Public Sub uploadXML()
        AddLog("begin XML uploading")
        Dim cc As System.Net.CookieCollection = cookieJar.GetCookies(New Uri("http://www.tistory.com"))

        txtXML.Text = Trim(txtXML.Text)

        filname = IIf(txtXML.Text = "", DateTime.Now.Ticks.ToString("x") & ".xml", txtXML.Text & ".xml")
        AddLog("xml file name : " & filname)

        Dim Result As String = "<!-- GENERATED BY FLEVATOR url:http://devflow.kr/ -->" & vbCrLf & "<playlist version=" & Chr(34) & "1" & Chr(34) & ">" & vbCrLf & "<trackList>"



        For i = 1 To upCount
            Result = Result & Replace(Replace(track_set.Text, "##_NUM_##", i), "##_LOC_##", cmbList.Text & "attachment/" & FileData(i).URL)
        Next

        Result = Result & "</trackList>" & vbCrLf & "</playlist>"

        AddLog("xml data")
        AddLog("---------------------------------------------------")
        AddLog(Result)
        AddLog("---------------------------------------------------")

        Dim boundary As String = "----------" & DateTime.Now.Ticks.ToString("x")
        Dim newLine As String = System.Environment.NewLine
        Dim boundaryBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(newLine & "--" & boundary & newLine)
        hMain = Net.WebRequest.Create(cmbList.Text & "admin/skin/uploadFiles.php?TSSESSION=" & cc.Item("TSSESSION").Value)

        AddLog("session " & cc.Item("TSSESSION").Value)
        AddLog("but is it true?")
        Application.DoEvents()
        hMain.ContentType = "multipart/form-data; boundary=" & boundary
        hMain.Method = "POST"
        hMain.Accept = "text/*"
        hMain.CookieContainer = cookieJar
        hMain.AllowAutoRedirect = True
        hMain.Timeout = -1
        hMain.UserAgent = "Shockwave Flash"
        hMain.KeepAlive = True
        hMain.AllowWriteStreamBuffering = False

        Dim ms As New System.IO.MemoryStream()
        Dim formDataTemplate As String = "Content-Disposition: form-data; name=""{0}""{1}{1}{2}"

        'For Each key As String In otherParameters.Keys
        ms.Write(boundaryBytes, 0, boundaryBytes.Length)

        AddLog("written bondary")

        Dim formItem As String, formItemBytes As Byte()

        formItem = String.Format(formDataTemplate, "Filename", newLine, filname)
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)

        AddLog("written formdata")

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)

        Dim headerTemplate As String = "Content-Disposition: form-data; name=""{0}""; filename=""{1}""{2}Content-Type: {3}{2}{2}"
        Dim header As String = String.Format(headerTemplate, "Filedata", filname, newLine, "application/octet-stream")
        Dim headerBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(header)
        ms.Write(headerBytes, 0, headerBytes.Length)

        AddLog("writte header")

        Dim bin_data As Byte() = System.Text.Encoding.UTF8.GetBytes(Result)
        Application.DoEvents()
        AddLog("writte xml")

        ms.Write(bin_data, 0, bin_data.Length)

        ms.Write(boundaryBytes, 0, boundaryBytes.Length)
        formItem = String.Format(formDataTemplate, "Upload", newLine, "Submit Query")
        formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
        ms.Write(formItemBytes, 0, formItemBytes.Length)
        ms.Write(boundaryBytes, 0, boundaryBytes.Length)
        Dim length As Long = ms.Length
        'length += bin_data.Length
        hMain.ContentLength = length

        AddLog("writte subquery")

        Using requestStream As IO.Stream = hMain.GetRequestStream()
            Dim bheader() As Byte = ms.ToArray()
            Application.DoEvents()
            requestStream.Write(bheader, 0, bheader.Length)
            'requestStream.Write(bin_data, 0, bin_data.Length)
            requestStream.Close()
        End Using

        AddLog("request done")
        Dim response As Net.WebResponse = Nothing
        Dim responseText = ""

        response = hMain.GetResponse()

        Using responseStream As IO.Stream = response.GetResponseStream()

            Using responseReader As New IO.StreamReader(responseStream)

                responseText = responseReader.ReadToEnd()

            End Using

        End Using

        AddLog("request text")
        AddLog("---------------------------------------------------")
        AddLog(responseText)
        AddLog("---------------------------------------------------")
        If InStr(responseText, """error"":true") = 0 Then
            Dim hi As String, wd As String
            If r1080.Checked Then
                hi = 1920 : wd = 1080
            ElseIf r720.Checked Then
                hi = 1280 : wd = 720
            ElseIf r360.Checked Then
                hi = 640 : wd = 360
            ElseIf r504.Checked Then
                hi = 896 : wd = 504
            Else
                wd = txtHeight.Text : hi = txtWidth.Text
            End If

            Dim strTemple As String = "&loop={0}&number={1}&split={2}&ratio={3}&bar={4}"

            Dim strAvrg As String = String.Format(strTemple, IIf(chkLoop.Checked, "true", "false"), IIf(chkNumber.Checked, "true", "false"), IIf(chkHJSP.Checked, "false", "true"), IIf(chkRatio.Checked, "false", "true"), IIf(cControl.Checked, "true", "false"))

            txtResult.Text = Replace(Replace(Replace(Replace(Replace(Replace(txtEMBED.Text, "##_SWF_##", txtSWF.Text), "##_XML_##", skinLOC & "images/" & UrlEncode(filname)), "##_WIDTH_##", hi).Replace("##_HEIGHT_##", wd), "##_FULL_##", IIf(cFull.Checked, "true", "false")), "##_AUTO_##", IIf(cAuto.Checked, "true", "false")), "##_ETC_##", IIf(txtOther.Text = "", IIf(chkAdvan.Checked, strAvrg, ""), IIf(chkAdvan.Checked, strAvrg, "") & "&" & txtOther.Text)).Replace("##_XMLNAME_##", IIf(rJWP.checked, "file", "xml"))
            Sound.PlayWaveResource("note.wav")

            AddLog("result")
            AddLog("---------------------------------------------------")
            AddLog(txtResult.Text)
            AddLog("---------------------------------------------------")

        Else
            MsgBox("XML 업로드에 오류가 발생하였습니다.", MsgBoxStyle.Information, "ERROR")

        End If
    End Sub

    Private Sub 정보AToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 정보AToolStripMenuItem.Click
        frmAbout.Show()

    End Sub

    Private Sub lstFiles_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFiles.LostFocus
        tmrLVScroll.Enabled = False
    End Sub

    Private Sub lstFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstFiles.SelectedIndexChanged

    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cAuto.CheckedChanged

    End Sub

    Private Sub 설정업로드UToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 설정업로드UToolStripMenuItem.Click
        If MsgBox("프로그램 파일목록을 제외한 모든 설정을 티스토리에 업로드합니다." & vbCrLf & "선택하신 블로그에 업로드 하시겠습니까?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "알림") = MsgBoxResult.Yes Then
            Dim cc As System.Net.CookieCollection = cookieJar.GetCookies(New Uri("http://www.tistory.com"))

            Dim boundary As String = "----------" & DateTime.Now.Ticks.ToString("x")
            Dim newLine As String = System.Environment.NewLine
            Dim boundaryBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(newLine & "--" & boundary & newLine)
            hMain = Net.WebRequest.Create(cmbList.Text & "admin/skin/uploadFiles.php?TSSESSION=" & cc.Item("TSSESSION").Value)

            hMain.ContentType = "multipart/form-data; boundary=" & boundary
            hMain.Method = "POST"
            hMain.Accept = "text/*"
            hMain.CookieContainer = cookieJar
            hMain.AllowAutoRedirect = True
            hMain.Timeout = -1
            hMain.UserAgent = "Shockwave Flash"
            hMain.KeepAlive = True
            hMain.AllowWriteStreamBuffering = False

            Dim ms As New System.IO.MemoryStream()
            Dim formDataTemplate As String = "Content-Disposition: form-data; name=""{0}""{1}{1}{2}"

            'For Each key As String In otherParameters.Keys
            ms.Write(boundaryBytes, 0, boundaryBytes.Length)

            Dim formItem As String, formItemBytes As Byte()

            formItem = String.Format(formDataTemplate, "Filename", newLine, "setting.ini")
            formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
            ms.Write(formItemBytes, 0, formItemBytes.Length)

            'Next key

            ms.Write(boundaryBytes, 0, boundaryBytes.Length)

            Dim headerTemplate As String = "Content-Disposition: form-data; name=""{0}""; filename=""{1}""{2}Content-Type: {3}{2}{2}"
            Dim header As String = String.Format(headerTemplate, "Filedata", "setting.ini", newLine, "application/octet-stream")
            Dim headerBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(header)
            ms.Write(headerBytes, 0, headerBytes.Length)


            Dim bin_data As Byte() = System.Text.Encoding.UTF8.GetBytes(GetFileContents(iniFile.INIFILE))


            ms.Write(bin_data, 0, bin_data.Length)

            ms.Write(boundaryBytes, 0, boundaryBytes.Length)
            formItem = String.Format(formDataTemplate, "Upload", newLine, "Submit Query")
            formItemBytes = System.Text.Encoding.UTF8.GetBytes(formItem)
            ms.Write(formItemBytes, 0, formItemBytes.Length)
            ms.Write(boundaryBytes, 0, boundaryBytes.Length)
            Dim length As Long = ms.Length
            'length += bin_data.Length
            hMain.ContentLength = length
            Application.DoEvents()
            Using requestStream As IO.Stream = hMain.GetRequestStream()
                Dim bheader() As Byte = ms.ToArray()
                requestStream.Write(bheader, 0, bheader.Length)
                'requestStream.Write(bin_data, 0, bin_data.Length)
                requestStream.Close()
            End Using


            Dim response As Net.WebResponse = Nothing
            Dim responseText = ""

            response = hMain.GetResponse()

            Using responseStream As IO.Stream = response.GetResponseStream()

                Using responseReader As New IO.StreamReader(responseStream)
                    Application.DoEvents()
                    responseText = responseReader.ReadToEnd()

                End Using

            End Using

            If InStr(responseText, """error"":true") = 0 Then
                MsgBox("XML 업로드가 완료되었습니다.", MsgBoxStyle.Information, "ERROR")
            Else
                MsgBox("XML 업로드에 오류가 발생하였습니다.", MsgBoxStyle.Information, "ERROR")
            End If
        End If
    End Sub

    Private Sub Version0x0ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Version0x0ToolStripMenuItem.Click
        a += 1
        If a > 10 Then
            frmDebug.Show()
            a = 0
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            Dim hi As String, wd As String
        If r1080.Checked Then
            hi = 1920 : wd = 1080
        ElseIf r720.Checked Then
            hi = 1280 : wd = 720
        ElseIf r360.Checked Then
            hi = 640 : wd = 360
        ElseIf r504.Checked Then
            hi = 896 : wd = 504
        Else
            wd = txtHeight.Text : hi = txtWidth.Text
        End If

        Dim strTemple As String = "&loop={0}&number={1}&split={2}&ratio={3}&bar={4}"

        Dim strAvrg As String = String.Format(strTemple, IIf(chkLoop.Checked, "true", "false"), IIf(chkNumber.Checked, "true", "false"), IIf(chkHJSP.Checked, "false", "true"), IIf(chkRatio.Checked, "false", "true"), IIf(cControl.Checked, "true", "false"))

        txtResult.Text = Replace(Replace(Replace(Replace(Replace(Replace(txtEMBED.Text, "##_SWF_##", txtSWF.Text), "##_XML_##", skinLOC & "images/" & UrlEncode(filname)), "##_WIDTH_##", hi).Replace("##_HEIGHT_##", wd), "##_FULL_##", IIf(cFull.Checked, "true", "false")), "##_AUTO_##", IIf(cAuto.Checked, "true", "false")), "##_ETC_##", IIf(txtOther.Text = "", IIf(chkAdvan.Checked, strAvrg, ""), IIf(chkAdvan.Checked, strAvrg, "") & "&" & txtOther.Text)).Replace("##_XMLNAME_##", IIf(rJWP.Checked, "file", "xml"))
    End Sub

    Private Sub topAD_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles topAD.DocumentCompleted

    End Sub

    Private Sub loadData_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loadData.Tick
        On Error GoTo endSub
        AddLog("atemp Load online data")
        If (topAD.Document.GetElementById("loaded").OuterText = "true") Then

            loadData.Enabled = False
            Dim sptData() As String = Split(topAD.Document.GetElementById("ver").OuterText, ".")
            AddLog("online ver")

            Dim myVer() As String = Split(Application.ProductVersion, "."), i As Integer
            Dim buffTemp() As String, j As Integer, buffItem As ListViewItem
            For i = 0 To 3
                If (Int(sptData(i)) > Int(myVer(i))) Then
                    If MsgBox("업데이트가 있습니다. 이동하시겠습니까?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Update") = vbYes Then
                        Dim webAddress As String = topAD.Document.GetElementById("link").OuterText
                        Process.Start(webAddress)
                        End
                    Else
                        lbNotice1.Text = topAD.Document.GetElementById("notice").OuterText.Replace("#nr#", vbCrLf)
                        nti_url = topAD.Document.GetElementById("not_link").OuterText
                        tipofsec = Split(topAD.Document.GetElementById("tip").OuterText, "|")
                        buffTemp = Split(topAD.Document.GetElementById("flashdata").OuterText, "||")
                        For j = 0 To UBound(buffTemp)
                            buffItem = lstFlash.Items.Add(Split(buffTemp(j), "|")(0))
                            buffItem.SubItems.Add(Split(buffTemp(j), "|")(1))
                            buffItem.SubItems.Add(Split(buffTemp(j), "|")(2))
                        Next

                        Exit Sub
                    End If
                End If
            Next
            tipofsec = Split(topAD.Document.GetElementById("tip").OuterText, "|")
            buffTemp = Split(topAD.Document.GetElementById("flashdata").OuterText, "||")
            For j = 0 To UBound(buffTemp)
                buffItem = lstFlash.Items.Add(Split(buffTemp(j), "|")(0))
                buffItem.SubItems.Add(Split(buffTemp(j), "|")(1))
                buffItem.SubItems.Add(Split(buffTemp(j), "|")(2))
            Next

            lbNotice1.Text = topAD.Document.GetElementById("notice").OuterText.Replace("#nr#", vbCrLf)
            nti_url = topAD.Document.GetElementById("not_link").OuterText
            Exit Sub
        End If

endSub:
        AddLog("online data loading failed")
    End Sub

    Private Sub lbNotice1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNotice1.Click
        Process.Start(nti_url)
    End Sub

    Public Function GetFileContents(ByVal FullPath As String, _
           Optional ByRef ErrInfo As String = "") As String

        Dim strContents As String
        Dim objReader As System.IO.StreamReader
        Try

            objReader = New System.IO.StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
            Return strContents
        Catch Ex As Exception
            ErrInfo = Ex.Message
            Return ""
        End Try
    End Function
    Public Function SaveTextToFile(ByVal strData As String, _
   ByVal FullPath As String, _
     Optional ByVal ErrInfo As String = "") As Boolean
        Dim bAns As Boolean = False
        Dim objReader As System.IO.StreamWriter
        Try


            objReader = New System.IO.StreamWriter(FullPath)
            objReader.Write(strData)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message

        End Try
        Return bAns
    End Function
    Private Sub 설정다운로드DToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 설정다운로드DToolStripMenuItem.Click
        On Error GoTo errTRAP
        If MsgBox(cmbList.Text & "에서 Flevator설정 파일을 다운로드하시겠습니까?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "알림") = vbYes Then
            initBlog(cmbList.Text)

            Dim responseData As String = ""

            hMain = Net.WebRequest.Create(skinLOC & "images/setting.ini")
            hMain.AllowAutoRedirect = True
            hMain.Referer = "http://www.tistory.com/"
            hMain.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.56 Safari/535.11"
            hMain.CookieContainer = cookieJar
            hMain.Timeout = 60000
            hMain.Method = "GET"

            Dim hwresponse As Net.HttpWebResponse = hMain.GetResponse()
            If hwresponse.StatusCode = Net.HttpStatusCode.OK Then
                Dim responseStream As IO.StreamReader = _
                  New IO.StreamReader(hwresponse.GetResponseStream())
                responseData = responseStream.ReadToEnd()
            End If
            hwresponse.Close()

            If InStr(responseData, "img_error head_error") = 0 Then

                If SaveTextToFile(responseData, iniFile.INIFILE) Then
                    MsgBox("정상적으로 설정파일을 저장했습니다. " & vbCrLf & "단 이를 적용하기 위해서는 프로그램을 재시작 해야합니다. 지금 종료합니다.", MsgBoxStyle.Exclamation, "알림")
                    End
                Else
                    MsgBox("파일을 저장 할 수 없습니다.", MsgBoxStyle.Exclamation, "알림")
                End If
            Else
                MsgBox("업로드된 설정파일이 존재하지 않습니다.", MsgBoxStyle.Exclamation, "알림")
            End If
        End If
        Exit Sub
errTRAP:
        MsgBox("업로드된 설정파일이 존재하지 않습니다.", MsgBoxStyle.Exclamation, "알림")
    End Sub

    Private Sub 설정저장SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 설정저장SToolStripMenuItem.Click
        On Error Resume Next
        If r1080.Checked Then
            INIWrite("flash", "width", "1080")
            INIWrite("flash", "height", "1920")
            INIWrite("flash", "custom", "0")
        ElseIf (r360.Checked) Then
            INIWrite("flash", "width", "360")
            INIWrite("flash", "height", "640")
            INIWrite("flash", "custom", "0")
        ElseIf (r720.Checked) Then
            INIWrite("flash", "width", "720")
            INIWrite("flash", "height", "1280")
            INIWrite("flash", "custom", "0")
        ElseIf (r504.Checked) Then
            INIWrite("flash", "width", "896")
            INIWrite("flash", "height", "504")
            INIWrite("flash", "custom", "0")
        ElseIf (rUser.Checked) Then
            INIWrite("flash", "width", txtWidth.Text)
            INIWrite("flash", "height", txtHeight.Text)
            INIWrite("flash", "custom", "1")
        End If

        INIWrite("flash", "url", txtSWF.Text)
        INIWrite("flash", "skin", txtSkin.Text)
        INIWrite("flash", "other", txtOther.Text)
        INIWrite("flash", "allowfull", IIf(cFull.Checked, "true", "false"))
        INIWrite("flash", "autoplay", IIf(cAuto.Checked, "true", "false"))
        INIWrite("flash", "showcontrol", IIf(cControl.Checked, "true", "false"))
        INIWrite("flash", "loop", IIf(chkLoop.Checked, "true", "false"))
        INIWrite("flash", "ratio", IIf(chkRatio.Checked, "true", "false"))
        INIWrite("flash", "split", IIf(chkHJSP.Checked, "true", "false"))
        INIWrite("flash", "number", IIf(chkNumber.Checked, "true", "false"))
        INIWrite("flash", "advance", IIf(chkAdvan.Checked, "true", "false"))


    End Sub

    Private Sub tmrLVScroll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrLVScroll.Tick

        Const WM_SCROLL As Integer = &H115S

        SendMessage(lstFiles.Handle.ToInt32, WM_SCROLL, scrollDirection, VariantType.Null)
    End Sub

    Private Sub cFull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cFull.CheckedChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        pPopup.Top = (Panel1.Top + GroupBox3.Top + Button3.Top) - pPopup.Height
        pPopup.Left = (Panel1.Left + GroupBox3.Left + Button3.Left) - pPopup.Width + 100
        pPopup.Visible = Not pPopup.Visible
    End Sub

    Private Sub lstFlash_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFlash.DoubleClick

    End Sub

    Private Sub lstFlash_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstFlash.SelectedIndexChanged
        On Error GoTo endSUB

        txtSWF.Text = lstFlash.SelectedItems(0).SubItems(2).Text



endSUB:
    End Sub

    Private Sub txtOther_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOther.TextChanged

    End Sub

    Private Sub cControl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cControl.CheckedChanged

    End Sub

    Private Sub Mp4분활업로드PToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mp4분활업로드PToolStripMenuItem.Click
        MsgBox("Missing MP4Box.exe", MsgBoxStyle.Critical, "error")


    End Sub

    Private Sub MP4FLVFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MP4FLVFToolStripMenuItem.Click
        MsgBox("Missing ffmpeg.exe", MsgBoxStyle.Critical, "error")

    End Sub

    Private Sub 목록에서제거DToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 목록에서제거DToolStripMenuItem.Click
        On Error Resume Next
        For Each slItem As ListViewItem In lstFiles.SelectedItems
            lstFiles.Items.Remove(slItem)
        Next
    End Sub

    Private Sub 모두제거AToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 모두제거AToolStripMenuItem.Click
        lstFiles.Items.Clear()

    End Sub

    Private Sub 복사하기CToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 복사하기CToolStripMenuItem.Click
        On Error Resume Next
        Dim strCopy As String = ""
        For Each slItem As ListViewItem In lstFiles.SelectedItems
            strCopy = strCopy & slItem.SubItems(3).Text & vbCrLf
        Next
    End Sub

    Private Sub 파일추가FToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 파일추가FToolStripMenuItem.Click
        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each j In ofd.FileNames
                Dim xBuf As String = System.IO.Path.GetFileName(j)
                Dim tmp As ListViewItem
                tmp = lstFiles.Items.Add(xBuf, 0) '.SubItems.Add(xBuf)
                tmp.SubItems.Add(ConvertSize(New System.IO.FileInfo(j).Length))
                tmp.SubItems.Add("준비")
                tmp.SubItems.Add("")
                tmp.Tag = j
                AddLog("insert file : " & j)
            Next
        End If

    End Sub

    Private Sub 폴더추가RToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 폴더추가RToolStripMenuItem.Click
        If fbd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ScanDirectory(fbd.SelectedPath)
        End If
    End Sub

    Public Sub ListViewSort(ByRef lv As ListView, ByVal col As Integer, ByVal AceDec As Boolean)
        Dim lvTempItem As ListViewItem
        Dim i As Integer

        If AceDec Then
            For i = 0 To lv.Items.Count - 2
                If CStr(lv.Items(i).SubItems(col).Text) > CStr(lv.Items(i + 1).SubItems(col).Text) Then
                    lvTempItem = lv.Items(i)
                    lv.Items(i).Remove()
                    lv.Items.Insert((i + 1), lvTempItem)

                    i = -1
                End If
            Next i
        Else
            For i = 0 To lv.Items.Count - 2 
                If CStr(lv.Items(i).SubItems(col).Text) < CStr(lv.Items(i + 1).SubItems(col).Text) Then

                    lvTempItem = lv.Items(i)
                    lv.Items(i).Remove()
                    lv.Items.Insert((i + 1), lvTempItem)

                    i = -1
                End If
            Next i
        End If


    End Sub

    Private Sub 오름차순정렬AToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 오름차순정렬AToolStripMenuItem.Click
        ListViewSort(lstFiles, 0, True)
        lstFiles.Refresh()
    End Sub

    Private Sub 내림차순정렬DToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 내림차순정렬DToolStripMenuItem.Click
        ListViewSort(lstFiles, 0, False)
        lstFiles.Refresh()
    End Sub

    Private Sub 스마트정렬SToolStripMenuItem_Click() Handles 스마트정렬SToolStripMenuItem.Click

        On Error Resume Next
        Dim lvTempItem As ListViewItem

        For i = 0 To lstFiles.Items.Count - 2

            If Int(Regex.Replace(lstFiles.Items(i).SubItems(0).Text, "[^0-9]", "")) > Int(Regex.Replace(lstFiles.Items(i + 1).SubItems(0).Text, "[^0-9]", "")) Then

                lvTempItem = lstFiles.Items(i)

                lstFiles.Items(i).Remove()

                lstFiles.Items.Insert((i + 1), lvTempItem)
                i = -1
            End If
        Next i
    End Sub

    Private Sub 목록스마트정렬SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 목록스마트정렬SToolStripMenuItem.Click
        스마트정렬SToolStripMenuItem_Click()
    End Sub

    Private Sub Version0x0ToolStripMenuItem_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Version0x0ToolStripMenuItem.MouseDown

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        pAdavn.Visible = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        pAdavn.Top = (Panel1.Top + GroupBox3.Top + Button4.Top) - pAdavn.Height
        pAdavn.Left = (Panel1.Left + GroupBox3.Left + Button4.Left) - pAdavn.Width + 100
        pAdavn.Visible = Not pAdavn.Visible
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub tmScroll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmScroll.Tick
        Label6.Text = Microsoft.VisualBasic.Right(Label6.Text, Label6.Text.Length - 1) & Microsoft.VisualBasic.Left(Label6.Text, 1)
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRand.Tick
        On Error Resume Next
        Dim RandomClass As New Random()
        Label6.Text = "         " & tipofsec(RandomClass.Next(0, UBound(tipofsec))) & "         "
    End Sub

    Private Sub pAdavn_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pAdavn.Paint

    End Sub

    Private Sub Label10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        pPopup.Visible = False
    End Sub

    Private Sub cmbList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbList.SelectedIndexChanged

    End Sub

    Private Sub 정렬하기SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 정렬하기SToolStripMenuItem.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub rUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rUser.CheckedChanged
        txtHeight.Enabled = rUser.Checked
        txtWidth.Enabled = rUser.Checked
    End Sub

    Private Sub r504_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles r504.CheckedChanged
        txtHeight.Enabled = rUser.Checked
        txtWidth.Enabled = rUser.Checked
    End Sub

    Private Sub r360_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles r360.CheckedChanged
        txtHeight.Enabled = rUser.Checked
        txtWidth.Enabled = rUser.Checked
    End Sub

    Private Sub r720_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles r720.CheckedChanged
        txtHeight.Enabled = rUser.Checked
        txtWidth.Enabled = rUser.Checked
    End Sub

    Private Sub r1080_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles r1080.CheckedChanged
        txtHeight.Enabled = rUser.Checked
        txtWidth.Enabled = rUser.Checked
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Clipboard.Clear()
        Clipboard.SetText(txtResult.Text)
    End Sub

    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        topAD.Refresh(WebBrowserRefreshOption.Completely)
    End Sub

    Private Sub 소녀시대소환SToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim str As String = "http://www.smtown.com/"
        Process.Start(str)
        'http://www.kclatc.com/
    End Sub

    Private Sub 아이유랑결혼IToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim str As String = "http://www.kclatc.com/"
        Process.Start(str)
    End Sub

    Private Sub 로또번호예측RToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim random As New Random()
        MsgBox(Format(random.Next(1, 45), "0#") & ", " & Format(random.Next(1, 45), "0#") & ", " & Format(random.Next(1, 45), "0#") & ", " & Format(random.Next(1, 45), "0#") & ", " & Format(random.Next(1, 45), "0#") & ", " & Format(random.Next(1, 45), "0#"), MsgBoxStyle.Information, "로또번호생성")

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class
