Imports System.Text

Module modURLF
    Public Function UrlEncode(ByVal str As String) As String
        If (str Is Nothing) Then
            Return Nothing
        End If
        Return UrlEncode(str, Encoding.UTF8)
    End Function

    Public Function UrlEncode(ByVal str As String, ByVal e As Encoding) As String
        If (str Is Nothing) Then
            Return Nothing
        End If
        Return Encoding.ASCII.GetString(UrlEncodeToBytes(str, e))
    End Function

    Private Function UrlEncodeToBytes(ByVal str As String, ByVal e As Encoding) As Byte()
        If (str Is Nothing) Then
            Return Nothing
        End If
        Dim bytes As Byte() = e.GetBytes(str)
        Return UrlEncodeBytesToBytesInternal(bytes, 0, bytes.Length, False)
    End Function

    Private Function IsSafe(ByVal ch As Char) As Boolean
        If ((((ch >= "a"c) AndAlso (ch <= "z"c)) OrElse ((ch >= "A"c) AndAlso (ch <= "Z"c))) OrElse ((ch >= "0"c) AndAlso (ch <= "9"c))) Then
            Return True
        End If
        Select Case ch
            Case "'"c, "("c, ")"c, "*"c, "-"c, "."c, "_"c, "!"c
                Return True
        End Select
        Return False
    End Function
    Private Function UrlEncodeBytesToBytesInternal(ByVal bytes As Byte(), ByVal offset As Integer, ByVal count As Integer, ByVal alwaysCreateReturnValue As Boolean) As Byte()
        Dim num As Integer = 0
        Dim num2 As Integer = 0
        Dim i As Integer
        For i = 0 To count - 1
            Dim ch As Char = ChrW(bytes(offset + i))
            If (ch = " "c) Then
                num += 1
            ElseIf Not IsSafe(ch) Then
                num2 += 1
            End If
        Next i
        If ((Not alwaysCreateReturnValue AndAlso (num = 0)) AndAlso (num2 = 0)) Then
            Return bytes
        End If
        Dim buffer As Byte() = New Byte((count + (num2 * 2)) - 1) {}
        Dim num4 As Integer = 0
        Dim j As Integer
        For j = 0 To count - 1
            Dim num6 As Byte = bytes(offset + j)
            Dim ch2 As Char = ChrW(num6)
            If IsSafe(ch2) Then
                buffer(num4) = num6
                num4 += 1
            ElseIf (ch2 = " "c) Then
                buffer(num4) = &H2B
                num4 += 1
            Else
                buffer(num4) = &H25
                num4 += 1
                buffer(num4) = CByte(AscW(IntToHex((num6 >> 4) And 15)))
                num4 += 1
                buffer(num4) = CByte(AscW(IntToHex(num6 And 15)))
                num4 += 1
            End If
        Next j
        Return buffer
    End Function
    Private Function IntToHex(ByVal n As Integer) As Char
        If (n <= 9) Then
            Return ChrW(n + &H30)
        End If
        Return ChrW((n - 10) + &H61)
    End Function



End Module

Module iniFile
    Public INIFILE As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location) & "\setting.ini"
    Private Declare Auto Function WritePrivateProfileString Lib "kernel32" (ByVal lpApplication As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer

    Private Declare Auto Function GetPrivateProfileString Lib "kernel32" _
    (ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, _
    ByVal lpDefault As String, _
    ByVal lpReturnedString As System.Text.StringBuilder, _
    ByVal nSize As Integer, _
    ByVal lpFileName As String) As Integer
    Public Function INIRead(ByVal Session As String, ByVal KeyValue As String, Optional ByVal isNum As Boolean = False) As String
        On Error Resume Next

        Dim strData As New System.Text.StringBuilder(255)
        Dim ReturnValue As Long

        ReturnValue = GetPrivateProfileString(Session, KeyValue, IIf(isNum, "0", ""), strData, strData.Capacity, INIFILE)

        Return strData.ToString
    End Function
    Public Function INIWrite(ByVal Session As String, ByVal KeyValue As String, ByVal DataValue As String) As String
        On Error Resume Next
        'INI 값 기록 
        Dim ReturnValue As Long
        ReturnValue = WritePrivateProfileString(Session, KeyValue, DataValue, INIFILE)
        Return ReturnValue
    End Function

End Module

Module modURL
    Public Sub AddLog(ByVal strLogtext As String)
        frmDebug.txtLog.AppendText(Format("hh:mm:ss", TimeOfDay()) & "> " & strLogtext & vbCrLf)

    End Sub
    Public Function ConvertSize(ByVal fileSize As Long) As String

        Dim sizeOfKB As Long = 1024              ' Actual size in bytes of 1KB
        Dim sizeOfMB As Long = 1048576           ' 1MB
        Dim sizeOfGB As Long = 1073741824        ' 1GB
        Dim sizeOfTB As Long = 1099511627776     ' 1TB
        Dim sizeofPB As Long = 1125899906842624  ' 1PB

        Dim tempFileSize As Double
        Dim tempFileSizeString As String

        Dim myArr() As Char = {CChar("0"), CChar(".")}  'Characters to strip off the end of our string after formating

        If fileSize < sizeOfKB Then 'Filesize is in Bytes
            tempFileSize = ConvertBytes(fileSize, convTo.B)
            If tempFileSize = -1 Then Return Nothing 'Invalid conversion attempted so exit
            tempFileSizeString = Format(fileSize, "Standard").TrimEnd(myArr) ' Strip the 0's and 1's off the end of the string
            Return Math.Round(tempFileSize) & " bytes" 'Return our converted value

        ElseIf fileSize >= sizeOfKB And fileSize < sizeOfMB Then 'Filesize is in Kilobytes
            tempFileSize = ConvertBytes(fileSize, convTo.KB)
            If tempFileSize = -1 Then Return Nothing 'Invalid conversion attempted so exit
            tempFileSizeString = Format(fileSize, "Standard").TrimEnd(myArr)
            Return Math.Round(tempFileSize) & " KB"

        ElseIf fileSize >= sizeOfMB And fileSize < sizeOfGB Then ' Filesize is in Megabytes
            tempFileSize = ConvertBytes(fileSize, convTo.MB)
            If tempFileSize = -1 Then Return Nothing 'Invalid conversion attempted so exit
            tempFileSizeString = Format(fileSize, "Standard").TrimEnd(myArr)
            Return Math.Round(tempFileSize, 1) & " MB"

        ElseIf fileSize >= sizeOfGB And fileSize < sizeOfTB Then 'Filesize is in Gigabytes
            tempFileSize = ConvertBytes(fileSize, convTo.GB)
            If tempFileSize = -1 Then Return Nothing
            tempFileSizeString = Format(fileSize, "Standard").TrimEnd(myArr)
            Return Math.Round(tempFileSize, 1) & " GB"

        ElseIf fileSize >= sizeOfTB And fileSize < sizeofPB Then 'Filesize is in Terabytes
            tempFileSize = ConvertBytes(fileSize, convTo.TB)
            If tempFileSize = -1 Then Return Nothing
            tempFileSizeString = Format(fileSize, "Standard").TrimEnd(myArr)
            Return Math.Round(tempFileSize, 1) & " TB"

            'Anything bigger than that is silly ;)

        Else

            Return Nothing 'Invalid filesize so return Nothing

        End If

    End Function

    Public Function ConvertBytes(ByVal bytes As Long, ByVal convertTo As convTo) As Double

        If convTo.IsDefined(GetType(convTo), convertTo) Then

            Return bytes / (1024 ^ convertTo)

        Else

            Return -1 'An invalid value was passed to this function so exit

        End If

    End Function

    Public Enum convTo
        B = 0
        KB = 1
        MB = 2
        GB = 3  'Enumerations for file size conversions
        TB = 4
        PB = 5
        EB = 6
        ZI = 7
        YI = 8
    End Enum
End Module
