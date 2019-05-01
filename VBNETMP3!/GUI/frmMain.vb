'***************************************************************
'**  Program Name:   VB.NET MP3!					          **
'**  Version Number: V1.0                                     **
'**  Copyright (C):  August 9, 2009 Richard W. Allen		  **
'**	 Date Started:   August 1, 2009                           **
'**  Date Ended:     August 9, 2009                           **
'**  Author:         Richardn W. Allen                        **
'**  Webpage:        http://richard-allen.homelinux.com		  **
'**  IDE:            Micosoft Visual Stuido .NET 2008         **
'**  Compiler:       VB.NET 2008                              **
'**  Langage:        VB.NET									  **
'**	 License:		 GNU GENERAL PUBLIC LICENSE Version 2	  **
'**					 see license.txt for for details	      **
'***************************************************************/
Imports System
Imports System.Windows.Forms    'Used the make this class a form.
Imports System.IO               'Used to access the files and folders.

Namespace frmMain

    Public Class frmMain
        Inherits System.Windows.Forms.Form

        '***  Programmer made objects/variables  ***'
        'Member objects/variables.
        'private.
        Private my_musicFile As AudioCode.AudioCode = New AudioCode.AudioCode()
        Private my_totalPlayTime As String = "\0"

        '***  Programmer made functions  ***'

        'Member functions.
        'public.

        'This function will get the name of the drives
        'and put it in the tree view control named "tvwFolders".
        'It is called by the constructor.
        Private Sub Drives()
            tvwFolders.Nodes.Clear() 'Clears the Tree View.

            'Gets the first drive Letter and puts it in the "drive" variable .
            For Each drive As String In Directory.GetLogicalDrives()
                'We add the name of the drive to the Tree View 
                'and a dummy child node to get a "+" to show
                'up next to the drive.
                tvwFolders.Nodes.Add(drive).Nodes.Add("DUMMY")
            Next
        End Sub

        'It is call by the "lstFiles_SelectedValueChanged" event.
        Private Sub FileLoaded()
            If my_musicFile.autorun = True Then
                lblStatus.Text = "Playing"
            Else
                lblStatus.Text = "Stopped"
            End If

            'We put the name of the file in the lable
            'add the forms title bar.
            lblFile.Text = lstFiles.Text
            Me.Text = "VB.NET MP3! " + lstFiles.Text

            'set up the PlayTime scroll bar.
            hsbPlayTime.Maximum = CType(my_musicFile.duration, Integer)
            'call the TotalPlayTime function.
            TotalPlayTime()

        End Sub

        'This function will calculate how much time is left.
        'It is call by the "tmrTimer_Tick" event.
        Private Sub PlayTimeUpdate()
            'if the mp3 is not load.
            If my_musicFile.loaded Then
                'variables
                Dim position As Integer = 0
                Dim minutes As Integer = 0
                Dim seconds As Integer = 0

                position = CType(my_musicFile.position, Integer)

                'The position is in seconds.
                minutes = Fix(position / 60)

                'Find out how many seconds are left.
                seconds = position - (minutes * 60)
                If seconds < 0 Then

                End If

                'If we displayed the elapsed time with out this
                'we would end up with this
                '"Play Time: 1:8 when it sould be "Play Time: 01:08".
                Dim playtime As String = "Play Time: "

                If minutes < 10 Then
                    playtime += "0"
                End If
                playtime += minutes.ToString() + ":"
                If seconds < 10 Then
                    playtime += "0"
                End If
                playtime += seconds.ToString() + " / " + my_totalPlayTime

                lblPlayTime.Text = playtime

                'We update the bar at this time.
                hsbPlayTime.Value = position
            End If
        End Sub

        'This function will calculate how much time is left.
        'It is call by the FileLoad() function.
        Private Sub TotalPlayTime()
            'if the mp3 is not load.
            If my_musicFile.loaded = True Then
                'Variables.
                Dim duration As Integer = 0
                Dim minutes As Integer = 0
                Dim seconds As Integer = 0

                duration = CType(my_musicFile.duration, Integer)

                'The position is in seconds.
                minutes = Fix(duration / 60)

                'Find out how many seconds are left.
                seconds = duration - (minutes * 60)

                'If we displayed the elapsed time with out this
                'we would end up with this
                '"Play Time: 1:8 when it sould be "Play Time: 01:08".
                If minutes < 10 Then
                    my_totalPlayTime = "0"
                End If
                my_totalPlayTime += minutes.ToString() + ":"
                If seconds < 10 Then
                    my_totalPlayTime += "0"
                End If
                my_totalPlayTime += seconds.ToString()

            End If
        End Sub

        Private Sub Play()
            my_musicFile.Play()
            lblStatus.Text = "Playing"
        End Sub

        Private Sub StopPlay()
            my_musicFile.StopPlay()
            lblStatus.Text = "Stopped"
        End Sub

        Private Sub Pause()
            my_musicFile.Pause()
            If my_musicFile.paused = True Then
                lblStatus.Text = "Paused"
            Else
                lblStatus.Text = "Playing"
            End If
        End Sub



#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Drives()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents lblVolume As System.Windows.Forms.Label
        Friend WithEvents lblBalance As System.Windows.Forms.Label
        Friend WithEvents mnuAboutHelp As System.Windows.Forms.MenuItem
        Friend WithEvents hsbPlayTime As System.Windows.Forms.HScrollBar
        Friend WithEvents tmrTimer As System.Windows.Forms.Timer
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents mnuHyphenFile As System.Windows.Forms.MenuItem
        Friend WithEvents mnuExitFile As System.Windows.Forms.MenuItem
        Friend WithEvents btnPlay As System.Windows.Forms.Button
        Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
        Friend WithEvents mnuPlayFile As System.Windows.Forms.MenuItem
        Friend WithEvents mnuStopFile As System.Windows.Forms.MenuItem
        Friend WithEvents mnuPauseFile As System.Windows.Forms.MenuItem
        Friend WithEvents btnPause As System.Windows.Forms.Button
        Friend WithEvents lstFiles As System.Windows.Forms.ListBox
        Friend WithEvents mnuMainMenu As System.Windows.Forms.MainMenu
        Friend WithEvents mnuOptions As System.Windows.Forms.MenuItem
        Friend WithEvents mnuOptionsAutoPlay As System.Windows.Forms.MenuItem
        Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
        Friend WithEvents hsbVolume As System.Windows.Forms.HScrollBar
        Friend WithEvents hsbBalance As System.Windows.Forms.HScrollBar
        Friend WithEvents lblPlayTime As System.Windows.Forms.Label
        Friend WithEvents lblFile As System.Windows.Forms.Label
        Friend WithEvents btnExit As System.Windows.Forms.Button
        Friend WithEvents btnStop As System.Windows.Forms.Button
        Friend WithEvents tvwFolders As System.Windows.Forms.TreeView
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.lblVolume = New System.Windows.Forms.Label
            Me.lblBalance = New System.Windows.Forms.Label
            Me.mnuAboutHelp = New System.Windows.Forms.MenuItem
            Me.hsbPlayTime = New System.Windows.Forms.HScrollBar
            Me.tmrTimer = New System.Windows.Forms.Timer(Me.components)
            Me.lblStatus = New System.Windows.Forms.Label
            Me.mnuHyphenFile = New System.Windows.Forms.MenuItem
            Me.mnuExitFile = New System.Windows.Forms.MenuItem
            Me.btnPlay = New System.Windows.Forms.Button
            Me.mnuFile = New System.Windows.Forms.MenuItem
            Me.mnuPlayFile = New System.Windows.Forms.MenuItem
            Me.mnuStopFile = New System.Windows.Forms.MenuItem
            Me.mnuPauseFile = New System.Windows.Forms.MenuItem
            Me.btnPause = New System.Windows.Forms.Button
            Me.lstFiles = New System.Windows.Forms.ListBox
            Me.mnuMainMenu = New System.Windows.Forms.MainMenu(Me.components)
            Me.mnuOptions = New System.Windows.Forms.MenuItem
            Me.mnuOptionsAutoPlay = New System.Windows.Forms.MenuItem
            Me.mnuHelp = New System.Windows.Forms.MenuItem
            Me.hsbVolume = New System.Windows.Forms.HScrollBar
            Me.hsbBalance = New System.Windows.Forms.HScrollBar
            Me.lblPlayTime = New System.Windows.Forms.Label
            Me.lblFile = New System.Windows.Forms.Label
            Me.btnExit = New System.Windows.Forms.Button
            Me.btnStop = New System.Windows.Forms.Button
            Me.tvwFolders = New System.Windows.Forms.TreeView
            Me.SuspendLayout()
            '
            'lblVolume
            '
            Me.lblVolume.AutoSize = True
            Me.lblVolume.Location = New System.Drawing.Point(336, 248)
            Me.lblVolume.Name = "lblVolume"
            Me.lblVolume.Size = New System.Drawing.Size(74, 13)
            Me.lblVolume.TabIndex = 27
            Me.lblVolume.Text = "Volume: 100%"
            '
            'lblBalance
            '
            Me.lblBalance.AutoSize = True
            Me.lblBalance.Location = New System.Drawing.Point(336, 168)
            Me.lblBalance.Name = "lblBalance"
            Me.lblBalance.Size = New System.Drawing.Size(83, 13)
            Me.lblBalance.TabIndex = 25
            Me.lblBalance.Text = "Balance: Center"
            '
            'mnuAboutHelp
            '
            Me.mnuAboutHelp.Index = 0
            Me.mnuAboutHelp.Shortcut = System.Windows.Forms.Shortcut.CtrlA
            Me.mnuAboutHelp.Text = "&About"
            '
            'hsbPlayTime
            '
            Me.hsbPlayTime.Location = New System.Drawing.Point(336, 128)
            Me.hsbPlayTime.Name = "hsbPlayTime"
            Me.hsbPlayTime.Size = New System.Drawing.Size(344, 16)
            Me.hsbPlayTime.TabIndex = 23
            '
            'tmrTimer
            '
            Me.tmrTimer.Enabled = True
            '
            'lblStatus
            '
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Location = New System.Drawing.Point(336, 16)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(0, 13)
            Me.lblStatus.TabIndex = 22
            '
            'mnuHyphenFile
            '
            Me.mnuHyphenFile.Index = 3
            Me.mnuHyphenFile.Text = "-"
            '
            'mnuExitFile
            '
            Me.mnuExitFile.Index = 4
            Me.mnuExitFile.Shortcut = System.Windows.Forms.Shortcut.CtrlX
            Me.mnuExitFile.Text = "E&xit"
            '
            'btnPlay
            '
            Me.btnPlay.Location = New System.Drawing.Point(8, 432)
            Me.btnPlay.Name = "btnPlay"
            Me.btnPlay.Size = New System.Drawing.Size(96, 40)
            Me.btnPlay.TabIndex = 17
            Me.btnPlay.Text = "&Play"
            '
            'mnuFile
            '
            Me.mnuFile.Index = 0
            Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuPlayFile, Me.mnuStopFile, Me.mnuPauseFile, Me.mnuHyphenFile, Me.mnuExitFile})
            Me.mnuFile.Text = "&File"
            '
            'mnuPlayFile
            '
            Me.mnuPlayFile.Index = 0
            Me.mnuPlayFile.Shortcut = System.Windows.Forms.Shortcut.CtrlP
            Me.mnuPlayFile.Text = "&Play"
            '
            'mnuStopFile
            '
            Me.mnuStopFile.Index = 1
            Me.mnuStopFile.Shortcut = System.Windows.Forms.Shortcut.CtrlS
            Me.mnuStopFile.Text = "&Stop"
            '
            'mnuPauseFile
            '
            Me.mnuPauseFile.Index = 2
            Me.mnuPauseFile.Shortcut = System.Windows.Forms.Shortcut.CtrlU
            Me.mnuPauseFile.Text = "Pa&use"
            '
            'btnPause
            '
            Me.btnPause.Location = New System.Drawing.Point(216, 432)
            Me.btnPause.Name = "btnPause"
            Me.btnPause.Size = New System.Drawing.Size(96, 40)
            Me.btnPause.TabIndex = 19
            Me.btnPause.Text = "Pa&use"
            '
            'lstFiles
            '
            Me.lstFiles.Location = New System.Drawing.Point(5, 216)
            Me.lstFiles.Name = "lstFiles"
            Me.lstFiles.Size = New System.Drawing.Size(320, 199)
            Me.lstFiles.TabIndex = 16
            '
            'mnuMainMenu
            '
            Me.mnuMainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuOptions, Me.mnuHelp})
            '
            'mnuOptions
            '
            Me.mnuOptions.Index = 1
            Me.mnuOptions.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuOptionsAutoPlay})
            Me.mnuOptions.Text = "&Options"
            '
            'mnuOptionsAutoPlay
            '
            Me.mnuOptionsAutoPlay.Checked = True
            Me.mnuOptionsAutoPlay.Index = 0
            Me.mnuOptionsAutoPlay.Text = "Auto Play"
            '
            'mnuHelp
            '
            Me.mnuHelp.Index = 2
            Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAboutHelp})
            Me.mnuHelp.Text = "&Help"
            '
            'hsbVolume
            '
            Me.hsbVolume.LargeChange = 1
            Me.hsbVolume.Location = New System.Drawing.Point(336, 288)
            Me.hsbVolume.Maximum = 0
            Me.hsbVolume.Minimum = -100
            Me.hsbVolume.Name = "hsbVolume"
            Me.hsbVolume.Size = New System.Drawing.Size(344, 16)
            Me.hsbVolume.TabIndex = 28
            '
            'hsbBalance
            '
            Me.hsbBalance.LargeChange = 1
            Me.hsbBalance.Location = New System.Drawing.Point(336, 208)
            Me.hsbBalance.Maximum = 5000
            Me.hsbBalance.Minimum = -5000
            Me.hsbBalance.Name = "hsbBalance"
            Me.hsbBalance.Size = New System.Drawing.Size(344, 16)
            Me.hsbBalance.TabIndex = 26
            '
            'lblPlayTime
            '
            Me.lblPlayTime.AutoSize = True
            Me.lblPlayTime.Location = New System.Drawing.Point(336, 88)
            Me.lblPlayTime.Name = "lblPlayTime"
            Me.lblPlayTime.Size = New System.Drawing.Size(124, 13)
            Me.lblPlayTime.TabIndex = 24
            Me.lblPlayTime.Text = "Play Time: 00:00 / 00:00"
            '
            'lblFile
            '
            Me.lblFile.AutoSize = True
            Me.lblFile.Location = New System.Drawing.Point(336, 48)
            Me.lblFile.Name = "lblFile"
            Me.lblFile.Size = New System.Drawing.Size(0, 13)
            Me.lblFile.TabIndex = 21
            '
            'btnExit
            '
            Me.btnExit.Location = New System.Drawing.Point(592, 432)
            Me.btnExit.Name = "btnExit"
            Me.btnExit.Size = New System.Drawing.Size(96, 40)
            Me.btnExit.TabIndex = 20
            Me.btnExit.Text = "E&xit"
            '
            'btnStop
            '
            Me.btnStop.Location = New System.Drawing.Point(112, 432)
            Me.btnStop.Name = "btnStop"
            Me.btnStop.Size = New System.Drawing.Size(96, 40)
            Me.btnStop.TabIndex = 18
            Me.btnStop.Text = "&Stop"
            '
            'tvwFolders
            '
            Me.tvwFolders.Location = New System.Drawing.Point(5, 8)
            Me.tvwFolders.Name = "tvwFolders"
            Me.tvwFolders.Size = New System.Drawing.Size(320, 200)
            Me.tvwFolders.TabIndex = 15
            '
            'frmMain
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(692, 473)
            Me.Controls.Add(Me.hsbPlayTime)
            Me.Controls.Add(Me.lblStatus)
            Me.Controls.Add(Me.btnPlay)
            Me.Controls.Add(Me.btnPause)
            Me.Controls.Add(Me.lstFiles)
            Me.Controls.Add(Me.hsbVolume)
            Me.Controls.Add(Me.hsbBalance)
            Me.Controls.Add(Me.lblPlayTime)
            Me.Controls.Add(Me.lblFile)
            Me.Controls.Add(Me.btnExit)
            Me.Controls.Add(Me.btnStop)
            Me.Controls.Add(Me.tvwFolders)
            Me.Controls.Add(Me.lblVolume)
            Me.Controls.Add(Me.lblBalance)
            Me.MaximizeBox = False
            Me.Menu = Me.mnuMainMenu
            Me.MinimizeBox = False
            Me.Name = "frmMain"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "VBNET MP3!"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private Sub mnuPlayFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPlayFile.Click
            Me.Play()
        End Sub

        Private Sub mnuStopFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStopFile.Click
            Me.StopPlay()
        End Sub

        Private Sub mnuPauseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPauseFile.Click
            Me.Pause()
        End Sub

        Private Sub mnuExitFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExitFile.Click
            Me.Close()
        End Sub

        Private Sub mnuOptionsAutoPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOptionsAutoPlay.Click
            If mnuOptionsAutoPlay.Checked = True Then
                mnuOptionsAutoPlay.Checked = False
            Else
                mnuOptionsAutoPlay.Checked = True
            End If

            my_musicFile.autorun = mnuOptionsAutoPlay.Checked
        End Sub

        Private Sub mnuAboutHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAboutHelp.Click
            Dim AboutForm As frmAbout.frmAbout = New frmAbout.frmAbout()
            AboutForm.Show()
        End Sub

        Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay.Click
            Me.Play()
        End Sub

        Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
            Me.StopPlay()
        End Sub

        Private Sub btnPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPause.Click
            Me.Pause()
        End Sub

        Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
            Me.Close()
        End Sub

        Private Sub tmrTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTimer.Tick
            PlayTimeUpdate()
        End Sub

        Private Sub tvwFolders_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwFolders.AfterSelect
            lstFiles.Items.Clear()
            Dim path As String = e.Node.FullPath

            my_musicFile.dir = path

            Try
                For Each file As String In Directory.GetFiles(path)
                    Dim fi As FileInfo = New FileInfo(file)
                    If fi.Extension = ".mp3" Then
                        lstFiles.Items.Add(fi.Name)
                    End If
                Next
            Catch
                MessageBox.Show("There was an error! When try to Access Directory", "Directory Access error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub

        Private Sub lstFiles_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstFiles.SelectedIndexChanged
            my_musicFile.filename = "\\" + lstFiles.Text
            my_musicFile.StopPlay()
            my_musicFile.Load()
            FileLoaded()
        End Sub

        Private Sub hsbPlayTime_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles hsbPlayTime.Scroll
            my_musicFile.position = hsbPlayTime.Value
        End Sub

        Private Sub hsbBalance_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hsbBalance.ValueChanged
            my_musicFile.Balance(hsbBalance.Value)
            If hsbBalance.Value = 0 Then
                lblBalance.Text = "Balance: Center"
            Else
                If (hsbBalance.Value < 0) Then
                    lblBalance.Text = "Balance: Left " + CType(hsbBalance.Value / -50, String) + "%"
                Else
                    lblBalance.Text = "Balance: Right " + CType(hsbBalance.Value / 50, String) + "%"
                End If
            End If
        End Sub

        Private Sub hsbPlayTime_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hsbPlayTime.ValueChanged
            my_musicFile.Volume(hsbVolume.Value)
            lblVolume.Text = "Volume: " + CType(hsbVolume.Value + 100, String) + "%"
        End Sub

        Private Sub tvwFolders_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvwFolders.BeforeExpand
            Try
                Dim path As String = e.Node.FullPath

                e.Node.Nodes.Clear()

                For Each dir As String In Directory.GetDirectories(path)
                    e.Node.Nodes.Add(System.IO.Path.GetFileName(dir)).Nodes.Add("DUMMY")
                Next
            Catch ex As Exception
                MessageBox.Show("There was an error! When try to Expand that folder", "Folder Expand error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub
    End Class
End Namespace
