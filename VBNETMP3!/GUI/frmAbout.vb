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
Namespace frmAbout
    Public Class frmAbout
        Inherits System.Windows.Forms.Form




#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            lblTitle.Text = "VB.NET MP3!"
            lblVersion.Text = "V1.0"
            lblDescription.Text = """VB.NET MP3!"" is an MP3 player written in Visual Basic .NET and use DirectShow 9."
            lblDisclaimer.Text = """VB.NET MP3!"" Copyright (C) 2009 Richard W. Allen  ""VB.NET MP3!"" Comes with ABSOLUTELY NO WARRANTY; for details see the license.txt include with this program."


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
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents lblDisclaimer As System.Windows.Forms.Label
        Friend WithEvents lblDescription As System.Windows.Forms.Label
        Friend WithEvents lblVersion As System.Windows.Forms.Label
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.lblDisclaimer = New System.Windows.Forms.Label()
            Me.lblDescription = New System.Windows.Forms.Label()
            Me.lblVersion = New System.Windows.Forms.Label()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'btnClose
            '
            Me.btnClose.Location = New System.Drawing.Point(19, 236)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(360, 40)
            Me.btnClose.TabIndex = 9
            Me.btnClose.Text = "Close"
            '
            'lblDisclaimer
            '
            Me.lblDisclaimer.Location = New System.Drawing.Point(14, 176)
            Me.lblDisclaimer.Name = "lblDisclaimer"
            Me.lblDisclaimer.Size = New System.Drawing.Size(360, 50)
            Me.lblDisclaimer.TabIndex = 8
            '
            'lblDescription
            '
            Me.lblDescription.Location = New System.Drawing.Point(14, 96)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(360, 36)
            Me.lblDescription.TabIndex = 7
            '
            'lblVersion
            '
            Me.lblVersion.AutoSize = True
            Me.lblVersion.Location = New System.Drawing.Point(104, 56)
            Me.lblVersion.Name = "lblVersion"
            Me.lblVersion.Size = New System.Drawing.Size(0, 13)
            Me.lblVersion.TabIndex = 6
            '
            'lblTitle
            '
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Location = New System.Drawing.Point(104, 16)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(0, 13)
            Me.lblTitle.TabIndex = 5
            '
            'frmAbout
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(392, 292)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClose, Me.lblDisclaimer, Me.lblDescription, Me.lblVersion, Me.lblTitle})
            Me.Name = "frmAbout"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub
    End Class
End Namespace
