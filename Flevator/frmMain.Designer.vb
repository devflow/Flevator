<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lstFiles = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cFiles = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.파일추가FToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.폴더추가RToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.목록에서제거DToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.모두제거AToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.정렬하기SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.복사하기CToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.스마트정렬SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.오름차순정렬AToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.내림차순정렬DToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbList = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.목록스마트정렬SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SdfsdfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.설정저장SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.설정업로드UToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.설정다운로드DToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.변환CToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mp4분활업로드PToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MP4FLVFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.정보AToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Version0x0ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.rUser = New System.Windows.Forms.RadioButton()
        Me.r360 = New System.Windows.Forms.RadioButton()
        Me.r504 = New System.Windows.Forms.RadioButton()
        Me.r720 = New System.Windows.Forms.RadioButton()
        Me.r1080 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtContent = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chkAdvan = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rSSp = New System.Windows.Forms.RadioButton()
        Me.rJWP = New System.Windows.Forms.RadioButton()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cFull = New System.Windows.Forms.CheckBox()
        Me.txtOther = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cAuto = New System.Windows.Forms.CheckBox()
        Me.txtSkin = New System.Windows.Forms.TextBox()
        Me.txtSWF = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkLoop = New System.Windows.Forms.CheckBox()
        Me.cControl = New System.Windows.Forms.CheckBox()
        Me.txtEMBED = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtXML = New System.Windows.Forms.TextBox()
        Me.chkHJSP = New System.Windows.Forms.CheckBox()
        Me.chkRatio = New System.Windows.Forms.CheckBox()
        Me.chkNumber = New System.Windows.Forms.CheckBox()
        Me.lstFlash = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.track_set = New System.Windows.Forms.TextBox()
        Me.loadData = New System.Windows.Forms.Timer(Me.components)
        Me.lbNotice1 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tmrLVScroll = New System.Windows.Forms.Timer(Me.components)
        Me.txtAttach = New System.Windows.Forms.TextBox()
        Me.pPopup = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.fbd = New System.Windows.Forms.FolderBrowserDialog()
        Me.pAdavn = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tmScroll = New System.Windows.Forms.Timer(Me.components)
        Me.tmrRand = New System.Windows.Forms.Timer(Me.components)
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.labCal = New System.Windows.Forms.Label()
        Me.topAD = New System.Windows.Forms.WebBrowser()
        Me.cFiles.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pPopup.SuspendLayout()
        Me.pAdavn.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button1.Location = New System.Drawing.Point(581, 285)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(155, 59)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "플짤 생성"
        Me.ToolTip1.SetToolTip(Me.Button1, "포스팅의 이름과 제목 그리고 플레이어의 크기와  설정을 입력하시고 업로드 해주세요,")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lstFiles
        '
        Me.lstFiles.AllowDrop = True
        Me.lstFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lstFiles.ContextMenuStrip = Me.cFiles
        Me.lstFiles.FullRowSelect = True
        Me.lstFiles.GridLines = True
        Me.lstFiles.LabelWrap = False
        Me.lstFiles.Location = New System.Drawing.Point(10, 130)
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.Size = New System.Drawing.Size(749, 122)
        Me.lstFiles.SmallImageList = Me.imgList
        Me.lstFiles.TabIndex = 5
        Me.ToolTip2.SetToolTip(Me.lstFiles, "이 곳에 파일을 추가하세요. 드래그로 위치를 변경 할 수도있습니다." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "파일순서는 곧 재생순서이니 반드시 신경써주세요.")
        Me.lstFiles.UseCompatibleStateImageBehavior = False
        Me.lstFiles.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "파일 이름"
        Me.ColumnHeader1.Width = 268
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "크기"
        Me.ColumnHeader2.Width = 108
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "상태"
        Me.ColumnHeader3.Width = 139
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "주소"
        Me.ColumnHeader4.Width = 327
        '
        'cFiles
        '
        Me.cFiles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.파일추가FToolStripMenuItem, Me.폴더추가RToolStripMenuItem, Me.ToolStripMenuItem4, Me.목록에서제거DToolStripMenuItem, Me.모두제거AToolStripMenuItem, Me.ToolStripMenuItem2, Me.정렬하기SToolStripMenuItem, Me.ToolStripMenuItem3, Me.복사하기CToolStripMenuItem})
        Me.cFiles.Name = "cFiles"
        Me.cFiles.Size = New System.Drawing.Size(148, 154)
        '
        '파일추가FToolStripMenuItem
        '
        Me.파일추가FToolStripMenuItem.Name = "파일추가FToolStripMenuItem"
        Me.파일추가FToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.파일추가FToolStripMenuItem.Text = "파일 추가 (&F)"
        '
        '폴더추가RToolStripMenuItem
        '
        Me.폴더추가RToolStripMenuItem.Name = "폴더추가RToolStripMenuItem"
        Me.폴더추가RToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.폴더추가RToolStripMenuItem.Text = "폴더 추가 (&R)"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(144, 6)
        '
        '목록에서제거DToolStripMenuItem
        '
        Me.목록에서제거DToolStripMenuItem.Name = "목록에서제거DToolStripMenuItem"
        Me.목록에서제거DToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.목록에서제거DToolStripMenuItem.Text = "선택 제거 (&D)"
        '
        '모두제거AToolStripMenuItem
        '
        Me.모두제거AToolStripMenuItem.Name = "모두제거AToolStripMenuItem"
        Me.모두제거AToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.모두제거AToolStripMenuItem.Text = "모두 제거 (&A)"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(144, 6)
        '
        '정렬하기SToolStripMenuItem
        '
        Me.정렬하기SToolStripMenuItem.Name = "정렬하기SToolStripMenuItem"
        Me.정렬하기SToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.정렬하기SToolStripMenuItem.Text = "정렬 하기 (&S)"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(144, 6)
        '
        '복사하기CToolStripMenuItem
        '
        Me.복사하기CToolStripMenuItem.Name = "복사하기CToolStripMenuItem"
        Me.복사하기CToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.복사하기CToolStripMenuItem.Text = "주소 복사 (&C)"
        '
        'imgList
        '
        Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList.Images.SetKeyName(0, "0")
        Me.imgList.Images.SetKeyName(1, "1")
        Me.imgList.Images.SetKeyName(2, "3")
        '
        '스마트정렬SToolStripMenuItem
        '
        Me.스마트정렬SToolStripMenuItem.Name = "스마트정렬SToolStripMenuItem"
        Me.스마트정렬SToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.스마트정렬SToolStripMenuItem.Text = "스마트 정렬 (&S)"
        '
        '오름차순정렬AToolStripMenuItem
        '
        Me.오름차순정렬AToolStripMenuItem.Name = "오름차순정렬AToolStripMenuItem"
        Me.오름차순정렬AToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.오름차순정렬AToolStripMenuItem.Text = "오름차순 정렬 (&A)"
        '
        '내림차순정렬DToolStripMenuItem
        '
        Me.내림차순정렬DToolStripMenuItem.Name = "내림차순정렬DToolStripMenuItem"
        Me.내림차순정렬DToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.내림차순정렬DToolStripMenuItem.Text = "내림차순 정렬 (&D)"
        '
        'cmbList
        '
        Me.cmbList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbList.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.cmbList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.cmbList.FormattingEnabled = True
        Me.cmbList.Location = New System.Drawing.Point(132, 9)
        Me.cmbList.Name = "cmbList"
        Me.cmbList.Size = New System.Drawing.Size(606, 20)
        Me.cmbList.TabIndex = 9
        Me.ToolTip2.SetToolTip(Me.cmbList, "파일과 XML, 그리고 글을 업로드할 블로그를 선택합니다.")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "업로드 할 블로그  :"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.목록스마트정렬SToolStripMenuItem, Me.SdfsdfToolStripMenuItem, Me.변환CToolStripMenuItem, Me.정보AToolStripMenuItem, Me.Version0x0ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(767, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "mnu"
        '
        '목록스마트정렬SToolStripMenuItem
        '
        Me.목록스마트정렬SToolStripMenuItem.Name = "목록스마트정렬SToolStripMenuItem"
        Me.목록스마트정렬SToolStripMenuItem.Size = New System.Drawing.Size(102, 20)
        Me.목록스마트정렬SToolStripMenuItem.Text = "스마트 정렬 (&S)"
        '
        'SdfsdfToolStripMenuItem
        '
        Me.SdfsdfToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.설정저장SToolStripMenuItem, Me.ToolStripMenuItem1, Me.설정업로드UToolStripMenuItem, Me.설정다운로드DToolStripMenuItem})
        Me.SdfsdfToolStripMenuItem.Name = "SdfsdfToolStripMenuItem"
        Me.SdfsdfToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.SdfsdfToolStripMenuItem.Text = "설정 (&S)"
        '
        '설정저장SToolStripMenuItem
        '
        Me.설정저장SToolStripMenuItem.Name = "설정저장SToolStripMenuItem"
        Me.설정저장SToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.설정저장SToolStripMenuItem.Text = "설정 저장 (&V)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(168, 6)
        '
        '설정업로드UToolStripMenuItem
        '
        Me.설정업로드UToolStripMenuItem.Name = "설정업로드UToolStripMenuItem"
        Me.설정업로드UToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.설정업로드UToolStripMenuItem.Text = "설정 업로드 (&U)"
        '
        '설정다운로드DToolStripMenuItem
        '
        Me.설정다운로드DToolStripMenuItem.Name = "설정다운로드DToolStripMenuItem"
        Me.설정다운로드DToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.설정다운로드DToolStripMenuItem.Text = "설정 다운로드 (&D)"
        '
        '변환CToolStripMenuItem
        '
        Me.변환CToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Mp4분활업로드PToolStripMenuItem, Me.MP4FLVFToolStripMenuItem})
        Me.변환CToolStripMenuItem.Name = "변환CToolStripMenuItem"
        Me.변환CToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.변환CToolStripMenuItem.Text = "변환 (&C)"
        Me.변환CToolStripMenuItem.Visible = False
        '
        'Mp4분활업로드PToolStripMenuItem
        '
        Me.Mp4분활업로드PToolStripMenuItem.Name = "Mp4분활업로드PToolStripMenuItem"
        Me.Mp4분활업로드PToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.Mp4분활업로드PToolStripMenuItem.Text = "MP4 Split(&P)"
        '
        'MP4FLVFToolStripMenuItem
        '
        Me.MP4FLVFToolStripMenuItem.Name = "MP4FLVFToolStripMenuItem"
        Me.MP4FLVFToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.MP4FLVFToolStripMenuItem.Text = "MP4 -> FLV (&F)"
        '
        '정보AToolStripMenuItem
        '
        Me.정보AToolStripMenuItem.Name = "정보AToolStripMenuItem"
        Me.정보AToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.정보AToolStripMenuItem.Text = "정보 (&A)"
        '
        'Version0x0ToolStripMenuItem
        '
        Me.Version0x0ToolStripMenuItem.Name = "Version0x0ToolStripMenuItem"
        Me.Version0x0ToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.Version0x0ToolStripMenuItem.Text = "Version : 0x0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtHeight)
        Me.GroupBox1.Controls.Add(Me.txtWidth)
        Me.GroupBox1.Controls.Add(Me.rUser)
        Me.GroupBox1.Controls.Add(Me.r360)
        Me.GroupBox1.Controls.Add(Me.r504)
        Me.GroupBox1.Controls.Add(Me.r720)
        Me.GroupBox1.Controls.Add(Me.r1080)
        Me.GroupBox1.Location = New System.Drawing.Point(303, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(433, 77)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "플레이어 크기"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(211, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "x"
        '
        'txtHeight
        '
        Me.txtHeight.Location = New System.Drawing.Point(229, 44)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(86, 21)
        Me.txtHeight.TabIndex = 15
        '
        'txtWidth
        '
        Me.txtWidth.Location = New System.Drawing.Point(108, 44)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(93, 21)
        Me.txtWidth.TabIndex = 14
        '
        'rUser
        '
        Me.rUser.AutoSize = True
        Me.rUser.Location = New System.Drawing.Point(10, 47)
        Me.rUser.Name = "rUser"
        Me.rUser.Size = New System.Drawing.Size(95, 16)
        Me.rUser.TabIndex = 4
        Me.rUser.Text = "사용자 정의 :"
        Me.rUser.UseVisualStyleBackColor = True
        '
        'r360
        '
        Me.r360.AutoSize = True
        Me.r360.Location = New System.Drawing.Point(200, 22)
        Me.r360.Name = "r360"
        Me.r360.Size = New System.Drawing.Size(66, 16)
        Me.r360.TabIndex = 3
        Me.r360.Text = "640x360"
        Me.r360.UseVisualStyleBackColor = True
        '
        'r504
        '
        Me.r504.AutoSize = True
        Me.r504.Checked = True
        Me.r504.Location = New System.Drawing.Point(279, 22)
        Me.r504.Name = "r504"
        Me.r504.Size = New System.Drawing.Size(131, 16)
        Me.r504.TabIndex = 2
        Me.r504.TabStop = True
        Me.r504.Text = "896*504 (일베 최대)"
        Me.r504.UseVisualStyleBackColor = True
        '
        'r720
        '
        Me.r720.AutoSize = True
        Me.r720.Location = New System.Drawing.Point(104, 22)
        Me.r720.Name = "r720"
        Me.r720.Size = New System.Drawing.Size(72, 16)
        Me.r720.TabIndex = 1
        Me.r720.Text = "1280x720"
        Me.r720.UseVisualStyleBackColor = True
        '
        'r1080
        '
        Me.r1080.AutoSize = True
        Me.r1080.Location = New System.Drawing.Point(9, 22)
        Me.r1080.Name = "r1080"
        Me.r1080.Size = New System.Drawing.Size(78, 16)
        Me.r1080.TabIndex = 0
        Me.r1080.Text = "1920x1080"
        Me.r1080.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txtContent)
        Me.GroupBox2.Controls.Add(Me.txtTitle)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 34)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(297, 157)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "포스팅 이름과 제목"
        '
        'txtContent
        '
        Me.txtContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContent.Location = New System.Drawing.Point(6, 44)
        Me.txtContent.Multiline = True
        Me.txtContent.Name = "txtContent"
        Me.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtContent.Size = New System.Drawing.Size(285, 107)
        Me.txtContent.TabIndex = 19
        Me.ToolTip2.SetToolTip(Me.txtContent, "블로그에 게시될 글의 내용입니다. (HTML)")
        '
        'txtTitle
        '
        Me.txtTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTitle.Location = New System.Drawing.Point(6, 17)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(285, 21)
        Me.txtTitle.TabIndex = 17
        Me.ToolTip2.SetToolTip(Me.txtTitle, "블로그에 게시될 글의 제목입니다.")
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Controls.Add(Me.chkAdvan)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.rSSp)
        Me.GroupBox3.Controls.Add(Me.rJWP)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.cFull)
        Me.GroupBox3.Controls.Add(Me.txtOther)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.cAuto)
        Me.GroupBox3.Controls.Add(Me.txtSkin)
        Me.GroupBox3.Controls.Add(Me.txtSWF)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(303, 117)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(433, 162)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "플레이어 설정"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(15, 103)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(77, 16)
        Me.CheckBox1.TabIndex = 38
        Me.CheckBox1.Text = "SWF 내장"
        Me.ToolTip2.SetToolTip(Me.CheckBox1, "XML업로드 대신, 플레이어 내장으로 리스트를 저장하기 위한 변수를 생성합니다.")
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'chkAdvan
        '
        Me.chkAdvan.AutoSize = True
        Me.chkAdvan.Location = New System.Drawing.Point(302, 103)
        Me.chkAdvan.Name = "chkAdvan"
        Me.chkAdvan.Size = New System.Drawing.Size(15, 14)
        Me.chkAdvan.TabIndex = 37
        Me.ToolTip2.SetToolTip(Me.chkAdvan, "추가 설정을 사용할 여부입니다.")
        Me.chkAdvan.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(404, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 12)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "[?]"
        Me.ToolTip2.SetToolTip(Me.Label8, "선택하는 이유는 각 플레이어의 XML 지정 매개변수의 이름이 다르기 때문입니다.")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 12)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "플레이어 종류 :"
        '
        'rSSp
        '
        Me.rSSp.AutoSize = True
        Me.rSSp.Checked = True
        Me.rSSp.Location = New System.Drawing.Point(108, 20)
        Me.rSSp.Name = "rSSp"
        Me.rSSp.Size = New System.Drawing.Size(47, 16)
        Me.rSSp.TabIndex = 34
        Me.rSSp.TabStop = True
        Me.rSSp.Text = "쓰플"
        Me.rSSp.UseVisualStyleBackColor = True
        '
        'rJWP
        '
        Me.rJWP.AutoSize = True
        Me.rJWP.Location = New System.Drawing.Point(187, 20)
        Me.rJWP.Name = "rJWP"
        Me.rJWP.Size = New System.Drawing.Size(75, 16)
        Me.rJWP.TabIndex = 33
        Me.rJWP.Text = "JWPlayer"
        Me.rJWP.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(321, 97)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(106, 24)
        Me.Button4.TabIndex = 32
        Me.Button4.Text = "추가 설정"
        Me.ToolTip2.SetToolTip(Me.Button4, "플레이어 설정이지만 자주 사용하지 않는 옵션입니다.")
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(342, 43)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(83, 24)
        Me.Button3.TabIndex = 30
        Me.Button3.Text = "불러오기"
        Me.ToolTip2.SetToolTip(Me.Button3, "개발자가 온라인으로 제공해주는 플레이어의 주소입니다.")
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cFull
        '
        Me.cFull.AutoSize = True
        Me.cFull.Checked = True
        Me.cFull.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cFull.Location = New System.Drawing.Point(193, 102)
        Me.cFull.Name = "cFull"
        Me.cFull.Size = New System.Drawing.Size(104, 16)
        Me.cFull.TabIndex = 24
        Me.cFull.Text = "전체 화면 허용"
        Me.ToolTip2.SetToolTip(Me.cFull, "모든 플레이어에 해당되며, 전체화면을 허용할지 표시합니다. (단 일부 사이트에선 적용되지 않습니다.)")
        Me.cFull.UseVisualStyleBackColor = True
        '
        'txtOther
        '
        Me.txtOther.Location = New System.Drawing.Point(108, 126)
        Me.txtOther.Name = "txtOther"
        Me.txtOther.Size = New System.Drawing.Size(319, 21)
        Me.txtOther.TabIndex = 29
        Me.ToolTip2.SetToolTip(Me.txtOther, "Flahs의 다른 설정을 지정할 수 있습니다. 예) autoplay=true&hide=true")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(36, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 12)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "기타옵션 :"
        '
        'cAuto
        '
        Me.cAuto.AutoSize = True
        Me.cAuto.Checked = True
        Me.cAuto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cAuto.Location = New System.Drawing.Point(108, 102)
        Me.cAuto.Name = "cAuto"
        Me.cAuto.Size = New System.Drawing.Size(76, 16)
        Me.cAuto.TabIndex = 26
        Me.cAuto.Text = "자동 재생"
        Me.ToolTip2.SetToolTip(Me.cAuto, "모든 플레이어에 해당하며, 자동으로 영상을 재생합니다.")
        Me.cAuto.UseVisualStyleBackColor = True
        '
        'txtSkin
        '
        Me.txtSkin.Location = New System.Drawing.Point(108, 70)
        Me.txtSkin.Name = "txtSkin"
        Me.txtSkin.Size = New System.Drawing.Size(319, 21)
        Me.txtSkin.TabIndex = 20
        Me.ToolTip2.SetToolTip(Me.txtSkin, "JWPlayer에서만 사용되며, 스킨 SWF의 주소입니다.")
        '
        'txtSWF
        '
        Me.txtSWF.Location = New System.Drawing.Point(108, 45)
        Me.txtSWF.Name = "txtSWF"
        Me.txtSWF.Size = New System.Drawing.Size(228, 21)
        Me.txtSWF.TabIndex = 19
        Me.ToolTip2.SetToolTip(Me.txtSWF, "플레이어의 SWF 주소입니다.")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "스킨 주소 :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "플레이어 주소 :"
        '
        'chkLoop
        '
        Me.chkLoop.AutoSize = True
        Me.chkLoop.Location = New System.Drawing.Point(115, 30)
        Me.chkLoop.Name = "chkLoop"
        Me.chkLoop.Size = New System.Drawing.Size(76, 16)
        Me.chkLoop.TabIndex = 31
        Me.chkLoop.Text = "반복 재생"
        Me.ToolTip2.SetToolTip(Me.chkLoop, "모든 플레이어에서만 적용되며, 컨트롤바를 표시할지 여부입니다.")
        Me.chkLoop.UseVisualStyleBackColor = True
        '
        'cControl
        '
        Me.cControl.AutoSize = True
        Me.cControl.Checked = True
        Me.cControl.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cControl.Location = New System.Drawing.Point(12, 31)
        Me.cControl.Name = "cControl"
        Me.cControl.Size = New System.Drawing.Size(72, 16)
        Me.cControl.TabIndex = 27
        Me.cControl.Text = "컨트롤바"
        Me.ToolTip2.SetToolTip(Me.cControl, "모든 플레이어에서 적용되며, 컨트롤바를 표시할지 여부입니다.")
        Me.cControl.UseVisualStyleBackColor = True
        '
        'txtEMBED
        '
        Me.txtEMBED.Location = New System.Drawing.Point(-10, -99)
        Me.txtEMBED.Name = "txtEMBED"
        Me.txtEMBED.ReadOnly = True
        Me.txtEMBED.Size = New System.Drawing.Size(1547, 21)
        Me.txtEMBED.TabIndex = 19
        Me.txtEMBED.Text = resources.GetString("txtEMBED.Text")
        Me.txtEMBED.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Button5)
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.txtResult)
        Me.GroupBox4.Location = New System.Drawing.Point(0, 279)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(575, 67)
        Me.GroupBox4.TabIndex = 20
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "EMBED HTML"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(10, 39)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(82, 20)
        Me.Button5.TabIndex = 22
        Me.Button5.Text = "복사하기"
        Me.ToolTip2.SetToolTip(Me.Button5, "플레이어 설정 변경하고 누루면 embed코드가 재생성 됩니다.")
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(10, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(82, 20)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "재설정"
        Me.ToolTip2.SetToolTip(Me.Button2, "플레이어 설정 변경하고 누루면 embed코드가 재생성 됩니다.")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtResult
        '
        Me.txtResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtResult.Location = New System.Drawing.Point(100, 16)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResult.Size = New System.Drawing.Size(469, 43)
        Me.txtResult.TabIndex = 20
        Me.ToolTip2.SetToolTip(Me.txtResult, "완성된 EMBED 코드입니다.")
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 10
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 10
        Me.ToolTip1.ReshowDelay = 2
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.ToolTip1.ToolTipTitle = "업로드 하기전에!"
        '
        'ToolTip2
        '
        Me.ToolTip2.AutomaticDelay = 10
        Me.ToolTip2.AutoPopDelay = 10000
        Me.ToolTip2.InitialDelay = 10
        Me.ToolTip2.ReshowDelay = 2
        Me.ToolTip2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip2.ToolTipTitle = "도구설명"
        '
        'txtXML
        '
        Me.txtXML.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtXML.Location = New System.Drawing.Point(7, 15)
        Me.txtXML.Name = "txtXML"
        Me.txtXML.Size = New System.Drawing.Size(285, 21)
        Me.txtXML.TabIndex = 18
        Me.ToolTip2.SetToolTip(Me.txtXML, "블로그에 게시될 글의 제목입니다.")
        '
        'chkHJSP
        '
        Me.chkHJSP.AutoSize = True
        Me.chkHJSP.Location = New System.Drawing.Point(210, 8)
        Me.chkHJSP.Name = "chkHJSP"
        Me.chkHJSP.Size = New System.Drawing.Size(170, 16)
        Me.chkHJSP.TabIndex = 37
        Me.chkHJSP.Text = "HJSplit으로 자른 영상 재생"
        Me.ToolTip2.SetToolTip(Me.chkHJSP, "쓰플에서만 적용되며, HJSplit를 이용해 자른 영상을 재생할때 사용합니다.")
        Me.chkHJSP.UseVisualStyleBackColor = True
        '
        'chkRatio
        '
        Me.chkRatio.AutoSize = True
        Me.chkRatio.Location = New System.Drawing.Point(115, 8)
        Me.chkRatio.Name = "chkRatio"
        Me.chkRatio.Size = New System.Drawing.Size(76, 16)
        Me.chkRatio.TabIndex = 36
        Me.chkRatio.Text = "꽉찬 화면"
        Me.ToolTip2.SetToolTip(Me.chkRatio, "쓰플에서만 적용되며, 비율을 무시하고 꽉찬화면으로 영상을 재생합니다.")
        Me.chkRatio.UseVisualStyleBackColor = True
        '
        'chkNumber
        '
        Me.chkNumber.AutoSize = True
        Me.chkNumber.Checked = True
        Me.chkNumber.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNumber.Location = New System.Drawing.Point(12, 8)
        Me.chkNumber.Name = "chkNumber"
        Me.chkNumber.Size = New System.Drawing.Size(76, 16)
        Me.chkNumber.TabIndex = 35
        Me.chkNumber.Text = "숫자 표시"
        Me.ToolTip2.SetToolTip(Me.chkNumber, "쓰플에서만 적용되며, 상단에 파일 숫자를 표시할 여부입니다.")
        Me.chkNumber.UseVisualStyleBackColor = True
        '
        'lstFlash
        '
        Me.lstFlash.AllowDrop = True
        Me.lstFlash.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstFlash.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader9})
        Me.lstFlash.FullRowSelect = True
        Me.lstFlash.GridLines = True
        Me.lstFlash.LabelWrap = False
        Me.lstFlash.Location = New System.Drawing.Point(5, 5)
        Me.lstFlash.Name = "lstFlash"
        Me.lstFlash.Size = New System.Drawing.Size(417, 115)
        Me.lstFlash.SmallImageList = Me.imgList
        Me.lstFlash.TabIndex = 6
        Me.lstFlash.UseCompatibleStateImageBehavior = False
        Me.lstFlash.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "이름"
        Me.ColumnHeader5.Width = 117
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "설명"
        Me.ColumnHeader6.Width = 315
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "주소"
        '
        'track_set
        '
        Me.track_set.Location = New System.Drawing.Point(-909, -909)
        Me.track_set.Multiline = True
        Me.track_set.Name = "track_set"
        Me.track_set.ReadOnly = True
        Me.track_set.Size = New System.Drawing.Size(571, 131)
        Me.track_set.TabIndex = 21
        Me.track_set.Text = "<track>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<title>##_NUM_##</title>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<annotation>##_NUM_##</annotation>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<location>" & _
    "##_LOC_##</location>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<image />" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</track>"
        Me.track_set.Visible = False
        '
        'loadData
        '
        Me.loadData.Enabled = True
        Me.loadData.Interval = 1000
        '
        'lbNotice1
        '
        Me.lbNotice1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbNotice1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbNotice1.Font = New System.Drawing.Font("Gulim", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbNotice1.ForeColor = System.Drawing.Color.Gray
        Me.lbNotice1.Location = New System.Drawing.Point(6, 347)
        Me.lbNotice1.Name = "lbNotice1"
        Me.lbNotice1.Size = New System.Drawing.Size(734, 42)
        Me.lbNotice1.TabIndex = 22
        Me.lbNotice1.Text = "공지사항..."
        Me.lbNotice1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.txtXML)
        Me.GroupBox5.Location = New System.Drawing.Point(0, 197)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(297, 43)
        Me.GroupBox5.TabIndex = 23
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "XML 이름 (확장자 제외, 빈칸일시 랜덤)"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.lbNotice1)
        Me.Panel1.Controls.Add(Me.cmbList)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Location = New System.Drawing.Point(11, 264)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(748, 390)
        Me.Panel1.TabIndex = 24
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(0, 243)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(298, 34)
        Me.Panel2.TabIndex = 24
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Gulim", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.Location = New System.Drawing.Point(1, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(335, 11)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "이 곳에 10초 마다 팁이 생성됩니다.                                      "
        '
        'tmrLVScroll
        '
        '
        'txtAttach
        '
        Me.txtAttach.Location = New System.Drawing.Point(-69, 29)
        Me.txtAttach.Name = "txtAttach"
        Me.txtAttach.ReadOnly = True
        Me.txtAttach.Size = New System.Drawing.Size(391, 21)
        Me.txtAttach.TabIndex = 25
        Me.txtAttach.Text = "<p>[##_1N|##_URL_##|filename=""##_FILENAME_##"" filemime=""##_KIND_##""|_##] 크기 : ##_" & _
    "SIZE_##  </p>"
        Me.txtAttach.Visible = False
        '
        'pPopup
        '
        Me.pPopup.BackColor = System.Drawing.Color.Gray
        Me.pPopup.Controls.Add(Me.Label11)
        Me.pPopup.Controls.Add(Me.Label10)
        Me.pPopup.Controls.Add(Me.lstFlash)
        Me.pPopup.Controls.Add(Me.txtAttach)
        Me.pPopup.ForeColor = System.Drawing.Color.Silver
        Me.pPopup.Location = New System.Drawing.Point(69, 33)
        Me.pPopup.Name = "pPopup"
        Me.pPopup.Size = New System.Drawing.Size(428, 139)
        Me.pPopup.TabIndex = 26
        Me.pPopup.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 123)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(153, 12)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "작동하지 않을 수 있습니다."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(381, 123)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 12)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "[닫기]"
        '
        'ofd
        '
        Me.ofd.Multiselect = True
        Me.ofd.RestoreDirectory = True
        Me.ofd.Title = "업로드할 파일들을 선턱해세요"
        '
        'fbd
        '
        Me.fbd.Description = "업로드할 파일들이 있는 폴더를 선택하세요."
        Me.fbd.RootFolder = System.Environment.SpecialFolder.MyDocuments
        Me.fbd.ShowNewFolderButton = False
        '
        'pAdavn
        '
        Me.pAdavn.BackColor = System.Drawing.Color.Gray
        Me.pAdavn.Controls.Add(Me.Label9)
        Me.pAdavn.Controls.Add(Me.chkHJSP)
        Me.pAdavn.Controls.Add(Me.chkRatio)
        Me.pAdavn.Controls.Add(Me.chkNumber)
        Me.pAdavn.Controls.Add(Me.cControl)
        Me.pAdavn.Controls.Add(Me.chkLoop)
        Me.pAdavn.ForeColor = System.Drawing.Color.White
        Me.pAdavn.Location = New System.Drawing.Point(333, 99)
        Me.pAdavn.Name = "pAdavn"
        Me.pAdavn.Size = New System.Drawing.Size(434, 54)
        Me.pAdavn.TabIndex = 20
        Me.pAdavn.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label9.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label9.Location = New System.Drawing.Point(405, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(25, 12)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "[X]"
        '
        'tmScroll
        '
        Me.tmScroll.Enabled = True
        '
        'tmrRand
        '
        Me.tmrRand.Enabled = True
        Me.tmrRand.Interval = 10000
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(108, 20)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton1.TabIndex = 34
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "쓰플"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'labCal
        '
        Me.labCal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labCal.Location = New System.Drawing.Point(11, 255)
        Me.labCal.Name = "labCal"
        Me.labCal.Size = New System.Drawing.Size(747, 14)
        Me.labCal.TabIndex = 27
        Me.labCal.Text = "대기중"
        Me.labCal.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'topAD
        '
        Me.topAD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.topAD.Location = New System.Drawing.Point(10, 33)
        Me.topAD.MinimumSize = New System.Drawing.Size(20, 20)
        Me.topAD.Name = "topAD"
        Me.topAD.ScriptErrorsSuppressed = True
        Me.topAD.ScrollBarsEnabled = False
        Me.topAD.Size = New System.Drawing.Size(749, 92)
        Me.topAD.TabIndex = 1
        Me.topAD.Url = New System.Uri("", System.UriKind.Relative)
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(767, 654)
        Me.Controls.Add(Me.labCal)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.pAdavn)
        Me.Controls.Add(Me.pPopup)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.track_set)
        Me.Controls.Add(Me.txtEMBED)
        Me.Controls.Add(Me.lstFiles)
        Me.Controls.Add(Me.topAD)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Flevator (by re_game :: http://devflow.kr/)"
        Me.cFiles.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pPopup.ResumeLayout(False)
        Me.pPopup.PerformLayout()
        Me.pAdavn.ResumeLayout(False)
        Me.pAdavn.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents topAD As System.Windows.Forms.WebBrowser
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lstFiles As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmbList As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents imgList As System.Windows.Forms.ImageList
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SdfsdfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 정보AToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents r720 As System.Windows.Forms.RadioButton
    Friend WithEvents r1080 As System.Windows.Forms.RadioButton
    Friend WithEvents r360 As System.Windows.Forms.RadioButton
    Friend WithEvents r504 As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents rUser As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtContent As System.Windows.Forms.TextBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSkin As System.Windows.Forms.TextBox
    Friend WithEvents txtSWF As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEMBED As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cAuto As System.Windows.Forms.CheckBox
    Friend WithEvents cFull As System.Windows.Forms.CheckBox
    Friend WithEvents cControl As System.Windows.Forms.CheckBox
    Friend WithEvents 설정업로드UToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 설정다운로드DToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Version0x0ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents track_set As System.Windows.Forms.TextBox
    Friend WithEvents loadData As System.Windows.Forms.Timer
    Friend WithEvents lbNotice1 As System.Windows.Forms.Label
    Friend WithEvents txtOther As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtXML As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents 설정저장SToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tmrLVScroll As System.Windows.Forms.Timer
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtAttach As System.Windows.Forms.TextBox
    Friend WithEvents pPopup As System.Windows.Forms.Panel
    Friend WithEvents lstFlash As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents 변환CToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mp4분활업로드PToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkLoop As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents MP4FLVFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cFiles As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 목록에서제거DToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 모두제거AToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 정렬하기SToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 오름차순정렬AToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 내림차순정렬DToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 복사하기CToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 파일추가FToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 폴더추가RToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents fbd As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents 스마트정렬SToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 목록스마트정렬SToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rSSp As System.Windows.Forms.RadioButton
    Friend WithEvents rJWP As System.Windows.Forms.RadioButton
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents pAdavn As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkHJSP As System.Windows.Forms.CheckBox
    Friend WithEvents chkRatio As System.Windows.Forms.CheckBox
    Friend WithEvents chkNumber As System.Windows.Forms.CheckBox
    Friend WithEvents chkAdvan As System.Windows.Forms.CheckBox
    Friend WithEvents tmScroll As System.Windows.Forms.Timer
    Friend WithEvents tmrRand As System.Windows.Forms.Timer
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents labCal As System.Windows.Forms.Label

End Class
